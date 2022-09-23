#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS publish
WORKDIR /src
COPY . ./Spotify.Api
COPY . ./Spotify.Domain
COPY . ./Spotify.CrossCutting
COPY . ./Spotify.Infrastructure
COPY . ./Spotify.Repository
COPY . ./Spotify.Application
WORKDIR "/src/Spotify.Api"
RUN dotnet publish "Spotify.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Spotify.Api.dll"]