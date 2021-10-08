# Coffee Store

## Packages Installed
## Web


## Infrastructure

Install-Package Microsoft.EntityFrameworkCore
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL
Install-Package Ardalis.Specification.EntityFrameworkCore
Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore

## ApplicationCore

Install-Package Ardalis.Specification

## EF Commands

Add-Migration InitialIdentity -Context AppIdentityDbContext -OutputDir "Identity/Migrations"

Update-Database -Context AppIdentityDbContext

Add-Migration InitialApp -Context ApplicationDbContext -OutputDir "Data/Migrations"

Update-Database -Context ApplicationDbContext 

Add-Migration BasketAndBasketItem -Context ApplicationDbContext -OutputDir "Data/Migrations"

Update-Database -Context ApplicationDbContext 