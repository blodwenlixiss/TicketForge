FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TicketForge.WebApi/TicketForge.WebApi.csproj", "TicketForge.WebApi/"]
COPY ["Modules/Catalog/Catalog.Module/Catalog.Module.csproj", "Modules/Catalog/Catalog.Module/"]
COPY ["Modules/Catalog/Catalog.Application/Catalog.Application.csproj", "Modules/Catalog/Catalog.Application/"]
COPY ["Modules/Catalog/Catalog.Domain/Catalog.Domain.csproj", "Modules/Catalog/Catalog.Domain/"]
COPY ["Modules/Catalog/Catalog.Contracts/Catalog.Contracts.csproj", "Modules/Catalog/Catalog.Contracts/"]
COPY ["Modules/Catalog/Catalog.Infrastructure/Catalog.Infrastructure.csproj", "Modules/Catalog/Catalog.Infrastructure/"]
RUN dotnet restore "TicketForge.WebApi/TicketForge.WebApi.csproj"
COPY . .
WORKDIR "/src/TicketForge.WebApi"
RUN dotnet build "./TicketForge.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TicketForge.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicketForge.WebApi.dll"]
