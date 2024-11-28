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
2 - Renter
```
Admin can access users info through endpoints and delete users from the DB.
Admin can now change user roles between renter and owner.If a admin changes a user role to "0" making the user an admin, he can't change it back.Has to delete the account

Owner will be able to add Apartments to the DB,view them,update them,delete them.(this is not yet coded,will be further down the process)

Renter can only view the apartments and book them.(this is not yet coded,will be further down the process)

You can clone the repository,change the connection string (located in S&T.Rental.Api/Connected services/secrets.json) right-click on secrets.json,then go to manage secrets and change the connection string to your SMSSQL connection string.Make a migration,then update the database and through the endpoints you can register/login users.

When you register a user the role will be Renter-2.To change roles there is a already created admin user in the DB.First you need to make the migration,after making the migration you may have to restart your IDE or Code editor.After doing that you can run the api and log in with the admin role.
The credentials for the admin user are: 
```
UserName : Admin,
Password : Admin123!
```
With the admin role you can change other users roles,view user data,delete users.

Apartments- Apartments can only be created by users with the role owner.Apartments can  be deleted or updated by users that have created that same exact apartment.
Renters can view the apartments that are avalivle,occupied,under maintenance or other.

Apartment Sizes: 
```
0-Small,
1-Medium,
2-Large,
3-Duplex,
4-PentHouse
```

Apartment Statuses:
```
0-Available,
1-Occupied,
2-Under_Maintenance,
3-Renovating
```

If you want to use the apartment feature,after you make the migration you need to register another user,make him a owner(through the admin user(already created)),and enjoy the feature.

Apartment feature need some minor updates...
Work in progress...
