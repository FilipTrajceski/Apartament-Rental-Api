# Apartament-Rental-Api
ASP.NET Web Api about Apartement rental

The project is using these NuGet Packages:
```
- AutoMapper by JimmyBogard
- Microsoft.AspNetCore.Authentication
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.AspNetCore.Identity.EntityFramework.Core
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.Extenstions.Configuration.Binder
- Swashbuckle.AspNetCore
- Swashbuckle.AspNetCore.Filters
- System.IdentityModel.Tokens.Jwt
```

Users can now register,login.The login returns a JWT Bearer token,which you will need to login with,to access the other endpoints.
Type bearer {token} to login (In Swagger).

User Roles: 
```
0 - Admin
1 - Owner
3 - Renter
```
Admin can access users info through endpoints and delete users from the DB.In this stage of the development if you type "0" in User Role while registering the user will be admin.

Owner will be able to add Apartments to the DB,view them,update them,delete them.(this is not yet coded,will be further down the process)

Renter can only view the apartments and book them.(this is not yet coded,will be further down the process)

You can clone the repository,change the connection string (located in S&T.Rental.Api/Connected services/secrets.json) right-click on secrets.json,then go to manage secrets and change the connection string to your SMSSQL connection string.Make a migration and through the endpoints you can register/login users.If admin View the users you created or delete them.

Work in progress...
