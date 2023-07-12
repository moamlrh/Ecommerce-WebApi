# Ecommerce WebApi 

#### Ecommerce Application has been made using Asp.net core 8 WebApi with Clean Architecture and The Best Practices.

## Technologies / Principles, Patterns and external libraries used  

- Asp.net core webapi 8
- Entity framewrok 8
- SqlServer
- Identity/Jwt Tokens and Refresh Tokens for Auth
- AutoMapper
- AspNetCoreRateLimit (Rate Limit)
- Testing using `xunit`
- Clean Architecture (Onion Architecture)
- Repository Pattern & Separation of Concerns (SoC)
- Dependency Injection (IoC)
- Unit of Work pattern (UoW)
- Options Pattern
- Others

## Run / Test The API

### I suggest, using `Postman` or `Swagger` (has been implemented by default with the API) They're very helpfull!

```
git clone git@github.com:moamlrh/Ecommerce-WebApi.git
```

- Open `appsettings.json` file to configure your `ConnectionStrings`
- Go to `Ecommerce.Api/Extensions/SerivcesExtensions.cs` & Edit the `ConfigureSqlServer` extension.
- Setup the Environmet variables `SECRET_KEY` for your **JWT** secret key.
- You have to make the migrations for creating DataBase with Tables.

```
dotnet ef migrations add initMigration
```
```
dotnet ef database update
```

- Now you're ready to GOOO
- Run the following command to start the API.

```
dotnet run --project Ecommerce.Api
```
