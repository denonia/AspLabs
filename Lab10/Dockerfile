FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Lab10/Lab10.csproj", "Lab10/"]
RUN dotnet restore "Lab10/Lab10.csproj"
COPY . .
WORKDIR "/src/Lab10"
RUN dotnet build "Lab10.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lab10.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab10.dll"]
