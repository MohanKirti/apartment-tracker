# Setup Guide

## Prerequisites

Before you begin, ensure you have the following installed:

1. **Visual Studio 2019** or later
2. **.NET Framework 4.8**
3. **SQL Server 2016** or later (or SQL Server Express)
4. **SQL Server Management Studio (SSMS)**

## Step 1: Clone the Repository

```bash
git clone https://github.com/MohanKirti/apartment-tracker.git
cd apartment-tracker
```

## Step 2: Create the Database

### Using SQL Server Management Studio:

1. Open SSMS
2. Connect to your SQL Server instance
3. Right-click on "Databases" and select "New Database"
4. Enter database name: `ApartmentTrackerDB`
5. Click OK

### Execute Database Schema:

1. Open a new Query window in SSMS
2. Open `Database/Schema/001_Initial_Schema.sql`
3. Execute the script (F5)
4. Open `Database/Seeds/002_Seed_Data.sql`
5. Execute the script (F5)

## Step 3: Configure Connection String

### For ApartmentTracker.API (Web.config):

1. Open `ApartmentTracker.API/Web.config`
2. Update the connection string:

```xml
<connectionStrings>
  <add name="ApartmentTrackerContext" 
       connectionString="Server=YOUR_SERVER_NAME;Database=ApartmentTrackerDB;Trusted_Connection=true;" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

Replace `YOUR_SERVER_NAME` with your SQL Server instance name (e.g., `localhost`, `DESKTOP-ABC123\SQLEXPRESS`)

### For ApartmentTracker.Web (Web.config):

Apply the same connection string configuration.

## Step 4: Install NuGet Packages

1. Open Visual Studio
2. Open Package Manager Console (Tools → NuGet Package Manager → Package Manager Console)
3. Run the following commands:

```powershell
Install-Package EntityFramework -Version 6.4.4
Install-Package Microsoft.AspNet.Identity.Core
Install-Package Microsoft.AspNet.Identity.EntityFramework
Install-Package Microsoft.AspNet.Mvc -Version 5.2.7
Install-Package Microsoft.AspNet.WebApi -Version 5.2.7
Install-Package Newtonsoft.Json -Version 13.0.1
```

## Step 5: Update Web.config

Ensure your `Web.config` files contain necessary bindings:

```xml
<runtime>
  <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
    <dependentAssembly>
      <assemblyIdentity name="Newtonsoft.Json" publicKeyToken="30ad4fe6b2a6aeed" />
      <bindingRedirect oldVersion="0.0.0.0-13.0.0.0" newVersion="13.0.0.0" />
    </dependentAssembly>
  </assemblyBinding>
</runtime>
```

## Step 6: Build the Solution

1. Open `ApartmentTracker.sln` in Visual Studio
2. Build → Build Solution (Ctrl+Shift+B)
3. Ensure no build errors

## Step 7: Set Startup Project

1. Right-click on `ApartmentTracker.API` in Solution Explorer
2. Select "Set as Startup Project"

## Step 8: Run the Application

1. Press F5 or click the "Start" button
2. The API should launch at `https://localhost:44300`
3. Web interface will be available at the configured URL

## Step 9: Verify Setup

### Test API:
1. Open browser and navigate to: `https://localhost:44300/api/apartments/manager/2`
2. You should see apartment data (may require authentication)

### Default Credentials:
- **Email**: admin@apartmenttracker.com
- **Password**: Admin@123

## Troubleshooting

### Connection String Issues:
- Verify SQL Server is running
- Check instance name using: `sqlcmd -L`
- Try: `Server=(localdb)\\mssqllocaldb` for LocalDB

### Build Errors:
- Clean Solution (Build → Clean Solution)
- Delete `bin` and `obj` folders manually
- Restore NuGet packages (Tools → NuGet → Restore Packages)

### Database Issues:
- Check SQL Server is running: `Services` → search "SQL Server"
- Verify database was created in SSMS
- Check error logs in SQL Server Management Studio

### Port Already in Use:
- Change port in project properties (Project → Properties → Web → Start URL)
- Or stop the process using the port

## Next Steps

- Review [API Documentation](API.md)
- Implement business logic in Service layer
- Create frontend views
- Set up authentication system