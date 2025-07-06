# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["KinderConnect.Web/KinderConnect.Web.csproj", "KinderConnect.Web/"]
COPY ["KinderConnect.Common/KinderConnect.Common.csproj", "KinderConnect.Common/"]
COPY ["KinderConnect.Data.Models/KinderConnect.Data.Models.csproj", "KinderConnect.Data.Models/"]
COPY ["KinderConnect.Data/KinderConnect.Data.csproj", "KinderConnect.Data/"]
COPY ["KinderConnect.Services.Data.Models/KinderConnect.Services.Data.Models.csproj", "KinderConnect.Services.Data.Models/"]
COPY ["KinderConnect.Web.ViewModels/KinderConnect.Web.ViewModels.csproj", "KinderConnect.Web.ViewModels/"]
COPY ["KinderConnect.Services.Data/KinderConnect.Services.Data.csproj", "KinderConnect.Services.Data/"]
COPY ["KinderConnect.Web.Infrastructure/KinderConnect.Web.Infrastructure.csproj", "KinderConnect.Web.Infrastructure/"]
RUN dotnet restore "./KinderConnect.Web/KinderConnect.Web.csproj"
COPY . .
WORKDIR "/src/KinderConnect.Web"
RUN dotnet build "./KinderConnect.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./KinderConnect.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KinderConnect.Web.dll"]