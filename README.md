# LabLedger

LabLedger is an ASP.NET Core MVC application for managing laboratory equipment, reservations, returns, maintenance requests, and user access. The project is currently organized around three operational views:

- **Students**: browse equipment, view reservations and borrowed equipment, manage a profile, and report damage.
- **Lab assistants**: review reservation requests, issue and return equipment, and handle maintenance requests.
- **Administrators**: manage laboratories, equipment, categories, users, and reports.
- **Accounts**: register and sign in using ASP.NET Core Identity.

## Technology Stack

- .NET 10 / ASP.NET Core MVC
- C# with nullable reference types enabled
- Entity Framework Core 10
- SQL Server / SQL Server Express
- ASP.NET Core Identity
- Razor views, Bootstrap, and jQuery validation

## Prerequisites

Install the following before running the project:

- .NET 10 SDK
- SQL Server Express or another SQL Server instance
- A development environment such as Visual Studio or VS Code

The default configuration expects a local SQL Server Express instance named `SQLEXPRESS`.

## Getting Started

1. Clone the repository and move into the project directory:

   ```powershell
   git clone <repository-url>
   cd LabLedger
   ```

2. Confirm the connection string in `appsettings.json`:

   ```json
   "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=LabLedgerDB;Trusted_Connection=True;TrustServerCertificate=True;"
   ```

   Update it if SQL Server is running under a different instance name or server.

3. Restore dependencies and build the application:

   ```powershell
   dotnet restore
   dotnet build
   ```

4. Install the Entity Framework Core CLI tool if it is not already available, then apply the migrations:

   ```powershell
   dotnet tool install --global dotnet-ef
   dotnet ef database update
   ```

5. Start the application:

   ```powershell
   dotnet run
   ```

   The configured development URLs are:

   - `http://localhost:5007`
   - `https://localhost:7144`

## Database Notes

The repository contains an initial migration for ASP.NET Core Identity tables. The student equipment catalog is queried from `dbo.EquipmentCatalog` by `StudentRepo`, so that table must also exist in `LabLedgerDB` before the student equipment page can load data.

For local development, create or provision the equipment table with these columns:

| Column | Type | Purpose |
| --- | --- | --- |
| `Id` | `int` | Equipment identifier |
| `Category` | `nvarchar` | Equipment category |
| `EquipmentName` | `nvarchar` | Display name |
| `Location` | `nvarchar` | Laboratory location |
| `Status` | `nvarchar` | Availability or condition |
| `Quantity` | `int` | Number of items available |

Do not commit production connection strings or credentials. Prefer user secrets or environment-specific configuration for shared and deployed environments.

## Project Structure

```text
LabLedger/
├── Areas/Identity/          ASP.NET Core Identity Razor Pages
├── Controllers/             MVC controllers for accounts and user roles
├── Data/                    Entity Framework Core DbContext
├── Migrations/              EF Core database migrations
├── Models/                  Application models and repository contracts
├── Views/                   Razor views and shared layouts
├── wwwroot/                 CSS, JavaScript, and frontend libraries
├── Program.cs               Application and dependency-injection setup
├── appsettings.json         Database and application configuration
└── LabLedger.csproj         Project dependencies and target framework
```

## Useful Commands

```powershell
# Run with the Development environment
dotnet run --environment Development

# Create a migration after changing the EF model
dotnet ef migrations add <MigrationName>

# Apply pending migrations
dotnet ef database update

# Remove the latest migration if it has not been applied
dotnet ef migrations remove
```

## Current Implementation Notes

- Identity is configured with email confirmation disabled for local development.
- The default route is `{controller=Home}/{action=Index}/{id?}`.
- The application currently uses a direct SQL query in `StudentRepo` for equipment catalog data.
- Role-specific pages and workflows are scaffolded in the MVC views and controllers; authorization policies and complete database-backed workflows can be added as the application evolves.
