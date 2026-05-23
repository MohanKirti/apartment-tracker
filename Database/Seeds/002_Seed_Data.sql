-- Apartment Tracker Database Seed Data
-- Sample data for testing and development

USE [ApartmentTrackerDB]
GO

-- Disable identity insert to use identity values
SET IDENTITY_INSERT [dbo].[Users] ON
GO

-- Insert sample users
INSERT INTO [dbo].[Users] ([UserId], [Username], [Email], [FirstName], [LastName], [PasswordHash], [PhoneNumber], [UserType], [IsActive], [CreatedDate])
VALUES 
(1, 'admin', 'admin@apartmenttracker.com', 'Admin', 'User', 'AQAAAAEAAYagAAAAEJ+CY2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2=', '1234567890', 'Admin', 1, GETUTCDATE()),
(2, 'propertymanager1', 'pm1@apartmenttracker.com', 'John', 'Manager', 'AQAAAAEAAYagAAAAEJ+CY2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2=', '1234567891', 'PropertyManager', 1, GETUTCDATE()),
(3, 'resident1', 'resident1@apartmenttracker.com', 'Alice', 'Johnson', 'AQAAAAEAAYagAAAAEJ+CY2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2=', '1234567892', 'Resident', 1, GETUTCDATE()),
(4, 'resident2', 'resident2@apartmenttracker.com', 'Bob', 'Smith', 'AQAAAAEAAYagAAAAEJ+CY2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2=', '1234567893', 'Resident', 1, GETUTCDATE()),
(5, 'resident3', 'resident3@apartmenttracker.com', 'Carol', 'Davis', 'AQAAAAEAAYagAAAAEJ+CY2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2Z3Z2=', '1234567894', 'Resident', 1, GETUTCDATE())
GO

SET IDENTITY_INSERT [dbo].[Users] OFF
GO

-- Insert sample apartments
SET IDENTITY_INSERT [dbo].[Apartments] ON
GO

INSERT INTO [dbo].[Apartments] ([ApartmentId], [PropertyManagerId], [ApartmentName], [Address], [City], [State], [ZipCode], [MaxResidents], [Description], [IsActive], [CreatedDate])
VALUES 
(1, 2, 'Downtown Apartment A', '123 Main St', 'New York', 'NY', '10001', 3, 'Modern 3-bedroom apartment in downtown', 1, GETUTCDATE()),
(2, 2, 'Uptown Apartment B', '456 Park Ave', 'New York', 'NY', '10002', 4, 'Spacious 4-bedroom apartment', 1, GETUTCDATE())
GO

SET IDENTITY_INSERT [dbo].[Apartments] OFF
GO

-- Insert apartment residents
SET IDENTITY_INSERT [dbo].[ApartmentResidents] ON
GO

INSERT INTO [dbo].[ApartmentResidents] ([ResidentId], [ApartmentId], [UserId], [JoinDate], [IsActive])
VALUES 
(1, 1, 3, '2025-01-01', 1),
(2, 1, 4, '2025-01-01', 1),
(3, 2, 5, '2025-01-01', 1)
GO

SET IDENTITY_INSERT [dbo].[ApartmentResidents] OFF
GO

-- Insert sample collections
SET IDENTITY_INSERT [dbo].[Collections] ON
GO

INSERT INTO [dbo].[Collections] ([CollectionId], [ApartmentId], [ItemName], [Category], [Description], [PurchaseDate], [PurchasePrice], [CurrentValue], [Owner], [Condition], [Location], [CreatedDate])
VALUES 
(1, 1, 'Dining Table', 'Furniture', 'Oak wood dining table for 6', '2024-06-15', 800.00, 750.00, 'Shared', 'Good', 'Dining Room', GETUTCDATE()),
(2, 1, 'Samsung TV', 'Electronics', '55-inch Smart TV', '2024-08-20', 600.00, 550.00, 'Shared', 'Excellent', 'Living Room', GETUTCDATE()),
(3, 1, 'Refrigerator', 'Kitchen', 'Stainless steel refrigerator', '2024-07-10', 1200.00, 1100.00, 'Shared', 'Good', 'Kitchen', GETUTCDATE()),
(4, 2, 'Sofa Set', 'Furniture', 'Leather sofa set', '2025-01-05', 2000.00, 1900.00, 'Shared', 'Excellent', 'Living Room', GETUTCDATE())
GO

SET IDENTITY_INSERT [dbo].[Collections] OFF
GO

-- Insert sample expenses
SET IDENTITY_INSERT [dbo].[Expenses] ON
GO

INSERT INTO [dbo].[Expenses] ([ExpenseId], [ApartmentId], [CreatedByUserId], [ExpenseName], [Category], [Amount], [ExpenseDate], [Description], [IsShared], [SplitType], [PaymentStatus], [CreatedDate])
VALUES 
(1, 1, 3, 'Monthly Rent', 'Rent', 3000.00, '2025-05-01', 'May 2025 rent payment', 1, 'Equal', 'Pending', GETUTCDATE()),
(2, 1, 3, 'Electricity Bill', 'Utilities', 150.00, '2025-05-15', 'May electricity', 1, 'Equal', 'Pending', GETUTCDATE()),
(3, 1, 4, 'Grocery Shopping', 'Groceries', 250.00, '2025-05-18', 'Weekly groceries', 1, 'Equal', 'Paid', GETUTCDATE()),
(4, 1, 3, 'Maintenance - Fix Sink', 'Maintenance', 100.00, '2025-05-20', 'Plumbing repair', 1, 'Equal', 'Pending', GETUTCDATE())
GO

SET IDENTITY_INSERT [dbo].[Expenses] OFF
GO

-- Insert expense splits
SET IDENTITY_INSERT [dbo].[ExpenseSplits] ON
GO

INSERT INTO [dbo].[ExpenseSplits] ([SplitId], [ExpenseId], [ResidentUserId], [SplitAmount], [SplitPercentage], [PaymentStatus], [PaidDate], [CreatedDate])
VALUES 
-- Rent splits (3 residents, so 1000 each)
(1, 1, 3, 1000.00, 33.33, 'Pending', NULL, GETUTCDATE()),
(2, 1, 4, 1000.00, 33.33, 'Pending', NULL, GETUTCDATE()),
(3, 1, 5, 1000.00, 33.34, 'Pending', NULL, GETUTCDATE()),
-- Electricity splits
(4, 2, 3, 50.00, 33.33, 'Pending', NULL, GETUTCDATE()),
(5, 2, 4, 50.00, 33.33, 'Pending', NULL, GETUTCDATE()),
(6, 2, 5, 50.00, 33.34, 'Pending', NULL, GETUTCDATE()),
-- Grocery splits
(7, 3, 3, 125.00, 50.00, 'Paid', '2025-05-19', GETUTCDATE()),
(8, 3, 4, 125.00, 50.00, 'Paid', '2025-05-19', GETUTCDATE()),
-- Maintenance splits
(9, 4, 3, 50.00, 50.00, 'Pending', NULL, GETUTCDATE()),
(10, 4, 4, 50.00, 50.00, 'Pending', NULL, GETUTCDATE())
GO

SET IDENTITY_INSERT [dbo].[ExpenseSplits] OFF
GO

-- Insert sample budgets
SET IDENTITY_INSERT [dbo].[Budgets] ON
GO

INSERT INTO [dbo].[Budgets] ([BudgetId], [ApartmentId], [BudgetMonth], [BudgetYear], [Category], [PlannedAmount], [AlertThreshold], [CreatedDate])
VALUES 
(1, 1, 5, 2025, 'Rent', 3000.00, 100.00, GETUTCDATE()),
(2, 1, 5, 2025, 'Utilities', 200.00, 80.00, GETUTCDATE()),
(3, 1, 5, 2025, 'Groceries', 400.00, 80.00, GETUTCDATE()),
(4, 1, 5, 2025, 'Maintenance', 150.00, 80.00, GETUTCDATE())
GO

SET IDENTITY_INSERT [dbo].[Budgets] OFF
GO

PRINT 'Seed data inserted successfully!'