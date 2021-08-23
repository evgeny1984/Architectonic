#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/Ar.Services/Notification.Service/Ar.Notification.Api/Ar.Notification.Api.csproj", "src/Ar.Services/Notification.Service/Ar.Notification.Api/"]
RUN dotnet restore "src/Ar.Services/Notification.Service/Ar.Notification.Api/Ar.Notification.Api.csproj"
COPY . .
WORKDIR "/src/src/Ar.Services/Notification.Service/Ar.Notification.Api"
RUN dotnet build "Ar.Notification.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ar.Notification.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ar.Notification.Api.dll"]