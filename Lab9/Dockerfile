FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Lab9/Lab9.csproj", "Lab9/"]
RUN dotnet restore "Lab9/Lab9.csproj"
COPY . .
WORKDIR "/src/Lab9"
RUN dotnet build "Lab9.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lab9.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab9.dll"]
