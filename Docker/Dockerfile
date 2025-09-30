# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src

COPY *.sln .
COPY SimpleApi.Api/SimpleApi.Api.csproj SimpleApi.Api/
COPY SimpleApi.Services/SimpleApi.Services.csproj SimpleApi.Services/
RUN dotnet restore

COPY . .
WORKDIR /src/SimpleApi.Api
RUN dotnet publish -c Release -o /app/publish /p:DebugType=None /p:DebugSymbols=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "SimpleApi.Api.dll"]
