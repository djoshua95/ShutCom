FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY ./*.sln .
COPY ./**/*.csproj .

RUN dotnet restore MysticMadness.WebService.csproj

# copy everything and build

COPY . .
WORKDIR /app/MysticMadness.WebService
RUN dotnet publish -c Debug -o /out

# use previously built binaries to run app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=build /out .

ENTRYPOINT [ "dotnet", "MysticMadness.WebService.dll" ]
