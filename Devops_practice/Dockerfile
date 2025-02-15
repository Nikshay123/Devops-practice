# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy and restore project
COPY ["Devops_practice.csproj", "."]
RUN dotnet restore "./Devops_practice.csproj"

# Copy everything and build
COPY . .
WORKDIR "/src"
RUN dotnet build "./Devops_practice.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage (includes Swagger static files)
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Devops_practice.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Production runtime stage
FROM base AS final
WORKDIR /app

# ✅ Copy published files (including Swagger)
COPY --from=publish /app/publish .

# ✅ Set ASP.NET Core URLs
ENV ASPNETCORE_URLS="http://+:80"
ENV ASPNETCORE_ENVIRONMENT=Development

# Start the application
ENTRYPOINT ["dotnet", "Devops_practice.dll"]
