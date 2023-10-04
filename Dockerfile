FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine as build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine
RUN apk add --no-cache bash
WORKDIR /app
COPY --from=build /app .
