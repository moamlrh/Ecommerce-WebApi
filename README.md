# Ecommerce-WebApi
#### Ecommerce Application has been made using Asp.net core 8 WebApi with Clean Architecture and best practices


## Features 
 - Asp.net core webapi 8
 - Entity framewrok 
 - SqlServer 
 - Identity/Jwt (json web tokens) and Refresh token for Auth
 - AutoMapper
 - Clean Architecture
 - Repository Pattern
 - Options Pattern
 - UoW pattern
 - Others

## To Run 
```
git clone git@github.com:moamlrh/Ecommerce-WebApi.git
```
- Open `appsettings.json` file to configure your `ConnectionStrings`
- Setup the Environmet variables `SECRET_KEY` for your **JWT** secret key.
- Then you're ready to GOOO
- But first you have to make the migrations
- So for that you have to run
```
dotnet ef migrations add initMigration
```
```
dotnet ef database update 
```
- Now you're ready
- just run the following command
```
dotnet run --project Ecommerce.Api
```
