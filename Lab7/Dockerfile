﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Lab7/Lab7.csproj", "Lab7/"]
RUN dotnet restore "Lab7/Lab7.csproj"
COPY . .
WORKDIR "/src/Lab7"
RUN dotnet build "Lab7.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lab7.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab7.dll"]
