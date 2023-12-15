#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["test/TestAllThemesUnitTest/TestAllThemesUnitTest.csproj", "test/TestAllThemesUnitTest/"]
COPY ["src/TestAllThemes.Application/TestAllThemes.Application.csproj", "src/TestAllThemes.Application/"]
COPY ["src/TestAllThemes.Domain/TestAllThemes.Domain.csproj", "src/TestAllThemes.Domain/"]
COPY ["src/TestAllThemess.Api/TestAllThemess.Api.csproj", "src/TestAllThemess.Api/"]
COPY ["src/TestAllThemes.Infrastructure/TestAllThemes.Infrastructure.csproj", "src/TestAllThemes.Infrastructure/"]
RUN dotnet restore "./test/TestAllThemesUnitTest/./TestAllThemesUnitTest.csproj"
COPY . .
WORKDIR "/src/test/TestAllThemesUnitTest"
RUN dotnet build "./TestAllThemesUnitTest.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TestAllThemesUnitTest.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestAllThemesUnitTest.dll"]