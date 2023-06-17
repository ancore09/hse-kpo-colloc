FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ./HealthTracker.Api/*.csproj ./HealthTracker.Api/
COPY ./HealthTracker.Core/*.csproj ./HealthTracker.Core/
COPY ./HealthTracker.Infrastructure/*.csproj ./HealthTracker.Infrastructure/

RUN dotnet restore ./HealthTracker.sln

# copy everything else and build app
COPY . .
RUN dotnet publish -c Release -o /app/build-dll

FROM base AS final
WORKDIR /app
COPY --from=build /app/build-dll .
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "HealthTracker.Api.dll"]