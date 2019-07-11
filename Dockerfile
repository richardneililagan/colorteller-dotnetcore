FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o build

# :: ---

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app

EXPOSE 80 443

COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "colorteller-dotnet.dll"]