FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine as build
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine
RUN apk add --no-cache bash
WORKDIR /app
COPY --from=build /app/out .
