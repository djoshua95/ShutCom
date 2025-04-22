# build stage: for restoring, building, publishing
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app
COPY . .
RUN dotnet restore MysticMadness.WebService

# copy everything and build
WORKDIR /app/MysticMadness.WebService
RUN dotnet publish -c Debug -o /out

# install dotnet-ef tool for migrations
RUN dotnet tool install --global dotnet-ef

# runtime stage: uses the previously built binaries to run app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app
COPY --from=build /out .
ENTRYPOINT [ "dotnet", "MysticMadness.WebService.dll" ]
