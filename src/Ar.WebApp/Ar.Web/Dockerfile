#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build

#Install nodejs
RUN apt-get update -yq && apt-get upgrade -yq && apt-get install -yq curl git nano
RUN curl -sL https://deb.nodesource.com/setup_16.x | bash - && apt-get install -yq nodejs build-essential
RUN npm install -g npm

WORKDIR /src
COPY ["src/Ar.WebApp/Ar.Web/Ar.Web.csproj", "src/Ar.WebApp/Ar.Web/"]
COPY ["src/Ar.Common/Helpers/Common/Ar.Common.Helpers.csproj", "src/Ar.Common/Helpers/Common/"]
COPY ["src/Ar.Common/DataContracts/Architect.Dto/Architect.Dto.csproj", "src/Ar.Common/DataContracts/Architect.Dto/"]
COPY ["src/Ar.Messages/EventBus/EventBus/EventBus.csproj", "src/Ar.Messages/EventBus/EventBus/"]
RUN dotnet restore "src/Ar.WebApp/Ar.Web/Ar.Web.csproj"
COPY . .
WORKDIR "/src/src/Ar.WebApp/Ar.Web"
RUN dotnet build "Ar.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ar.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ar.Web.dll"]