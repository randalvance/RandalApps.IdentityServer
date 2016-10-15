dotnet ef migrations add InitialMigration -c CentBucket.IdentityServer.Data.DbContexts.ApplicationDbContext -o Migrations/Application
dotnet ef migrations add InitialMigration -c CentBucket.IdentityServer.Data.DbContexts.IdentityServerDbContext -o Migrations/IdentityServer
dotnet ef database update -c CentBucket.IdentityServer.Data.DbContexts.ApplicationDbContext
dotnet ef database update -c CentBucket.IdentityServer.Data.DbContexts.IdentityServerDbContext