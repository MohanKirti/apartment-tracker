# Apartment Expense & Collection Tracker

A comprehensive web application for managing shared apartment expenses, collections inventory, and multi-resident billing for property managers and apartment dwellers.

## Features

- **Expense Management**: Track shared and individual expenses
- **Collection Inventory**: Manage apartment items and collections
- **Bill Splitting**: Automatic expense division among residents
- **Budget Planning**: Monitor and plan budget allocations
- **User Management**: Support for residents and property managers
- **Reporting**: Detailed expense and budget reports
- **Multi-Apartment Support**: Property managers can manage multiple apartments

## Technology Stack

- **Backend**: .NET 4.8 (ASP.NET MVC/WebAPI)
- **Database**: Microsoft SQL Server (MSSQL)
- **Frontend**: HTML5, CSS3, JavaScript (jQuery)
- **ORM**: Entity Framework 6.x
- **Authentication**: ASP.NET Identity

## Project Structure

```
apartment-tracker/
├── ApartmentTracker.Web/          # ASP.NET MVC Frontend
│   ├── Controllers/
│   ├── Views/
│   ├── Scripts/
│   └── Content/
├── ApartmentTracker.API/          # ASP.NET WebAPI Backend
│   ├── Controllers/
│   ├── Models/
│   ├── Services/
│   └── Filters/
├── ApartmentTracker.Data/         # Data Access Layer
│   ├── Models/
│   ├── Migrations/
│   ├── DbContext/
│   └── Repositories/
├── ApartmentTracker.Business/     # Business Logic Layer
│   ├── Services/
│   ├── DTOs/
│   └── Validators/
├── Database/                       # SQL Server Scripts
│   ├── Schema/
│   └── Seeds/
└── Documentation/                 # Project Documentation
```

## Prerequisites

- Visual Studio 2019 or later
- .NET Framework 4.8
- SQL Server 2016 or later
- IIS Express (included with Visual Studio)

## Quick Start

### 1. Clone the Repository
```bash
git clone https://github.com/MohanKirti/apartment-tracker.git
cd apartment-tracker
```

### 2. Database Setup
- Open SQL Server Management Studio
- Create a new database: `ApartmentTrackerDB`
- Run `Database/Schema/001_Initial_Schema.sql`
- Run `Database/Seeds/002_Seed_Data.sql`

### 3. Backend Setup
- Open `ApartmentTracker.sln` in Visual Studio
- Right-click solution → Restore NuGet Packages
- Update connection string in `Web.config`
- Set `ApartmentTracker.API` as startup project
- Press F5 to run

## Default Credentials

- **Admin Email**: admin@apartmenttracker.com
- **Admin Password**: Admin@123

## Documentation

- [Setup Guide](Documentation/SETUP.md)
- [API Documentation](Documentation/API.md)
- [Contributing Guidelines](CONTRIBUTING.md)

## Key Entities

### Users
- Admin, Property Manager, Resident roles
- Authentication and authorization

### Apartments
- Managed by property managers
- Multiple residents per apartment
- Capacity and details management

### Expenses
- Shared or individual
- Multiple split types: Equal, Custom, Percentage
- Payment tracking

### Collections
- Inventory tracking
- Category organization
- Condition and value tracking

### Budgets
- Monthly budget planning
- Category-based budgets
- Alert thresholds

## Contributing

Contributions are welcome! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for details.

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Support

For issues, questions, or suggestions, please open an issue on GitHub.