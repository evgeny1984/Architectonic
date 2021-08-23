#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Ar.Services/Generator.Service/Ar.Generator.Api/Ar.Generator.Api.csproj", "src/Ar.Services/Generator.Service/Ar.Generator.Api/"]
COPY ["src/Ar.Services/Generator.Service/Ar.Generator.Service/Ar.Generator.Service.csproj", "src/Ar.Services/Generator.Service/Ar.Generator.Service/"]
COPY ["src/Ar.Services/Generator.Service/Ar.Generator.Repository/Ar.Generator.Repository.csproj", "src/Ar.Services/Generator.Service/Ar.Generator.Repository/"]
COPY ["src/Ar.Services/Generator.Service/Ar.Generator.Data/Ar.Generator.Data.csproj", "src/Ar.Services/Generator.Service/Ar.Generator.Data/"]
RUN dotnet restore "src/Ar.Services/Generator.Service/Ar.Generator.Api/Ar.Generator.Api.csproj"
COPY . .
WORKDIR "/src/src/Ar.Services/Generator.Service/Ar.Generator.Api"
RUN dotnet build "Ar.Generator.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ar.Generator.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ar.Generator.Api.dll"]