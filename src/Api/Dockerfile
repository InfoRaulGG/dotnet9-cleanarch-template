FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Instalar herramientas necesarias e instalar vsdbg
RUN apt-get update && apt-get install -y unzip curl \
    && curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "dotnet9-cleanarch-template.sln"
RUN dotnet publish "src/Api/Api.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

COPY entrypoint.sh /app/entrypoint.sh
ENTRYPOINT ["/app/entrypoint.sh"]