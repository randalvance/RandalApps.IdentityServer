dotnet ef migrations add InitialMigration -c RandalApps.IdentityServer.Data.DbContexts.ApplicationDbContext -o Migrations/Application
dotnet ef migrations add InitialMigration -c IdentityServer4.EntityFramework.DbContexts.PersistedGrantDbContext  -o Migrations/PersistedGrant
dotnet ef migrations add InitialMigration -c IdentityServer4.EntityFramework.DbContexts.ConfigurationDbContext   -o Migrations/Configuration
dotnet ef database update -c RandalApps.IdentityServer.Data.DbContexts.ApplicationDbContext
dotnet ef database update -c IdentityServer4.EntityFramework.DbContexts.PersistedGrantDbContext
dotnet ef database update -c IdentityServer4.EntityFramework.DbContexts.ConfigurationDbContext
