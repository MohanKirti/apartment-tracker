-- Apartment Tracker Database Schema
-- Initial schema creation script

USE [ApartmentTrackerDB]
GO

-- Users Table
CREATE TABLE [dbo].[Users] (
    [UserId] INT PRIMARY KEY IDENTITY(1,1),
    [Username] NVARCHAR(100) NOT NULL UNIQUE,
    [Email] NVARCHAR(100) NOT NULL UNIQUE,
    [FirstName] NVARCHAR(100) NOT NULL,
    [LastName] NVARCHAR(100) NOT NULL,
    [PasswordHash] NVARCHAR(MAX) NOT NULL,
    [PhoneNumber] NVARCHAR(20) NULL,
    [UserType] NVARCHAR(50) NOT NULL, -- 'Resident', 'PropertyManager', 'Admin'
    [IsActive] BIT NOT NULL DEFAULT 1,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE()
)
GO

-- Apartments Table
CREATE TABLE [dbo].[Apartments] (
    [ApartmentId] INT PRIMARY KEY IDENTITY(1,1),
    [PropertyManagerId] INT NOT NULL,
    [ApartmentName] NVARCHAR(200) NOT NULL,
    [Address] NVARCHAR(500) NOT NULL,
    [City] NVARCHAR(100) NOT NULL,
    [State] NVARCHAR(50) NOT NULL,
    [ZipCode] NVARCHAR(20) NOT NULL,
    [MaxResidents] INT NOT NULL,
    [Description] NVARCHAR(500) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    CONSTRAINT FK_Apartments_PropertyManager FOREIGN KEY ([PropertyManagerId]) REFERENCES [dbo].[Users]([UserId])
)
GO

-- Apartment Residents Table (Junction Table)
CREATE TABLE [dbo].[ApartmentResidents] (
    [ResidentId] INT PRIMARY KEY IDENTITY(1,1),
    [ApartmentId] INT NOT NULL,
    [UserId] INT NOT NULL,
    [JoinDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [LeaveDate] DATETIME NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_ApartmentResidents_Apartment FOREIGN KEY ([ApartmentId]) REFERENCES [dbo].[Apartments]([ApartmentId]),
    CONSTRAINT FK_ApartmentResidents_User FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users]([UserId]),
    CONSTRAINT UQ_ApartmentResidents_ApartmentUser UNIQUE ([ApartmentId], [UserId])
)
GO

-- Collections/Items Table
CREATE TABLE [dbo].[Collections] (
    [CollectionId] INT PRIMARY KEY IDENTITY(1,1),
    [ApartmentId] INT NOT NULL,
    [ItemName] NVARCHAR(200) NOT NULL,
    [Category] NVARCHAR(100) NOT NULL, -- 'Furniture', 'Electronics', 'Kitchen', etc.
    [Description] NVARCHAR(500) NULL,
    [PurchaseDate] DATETIME NULL,
    [PurchasePrice] DECIMAL(10, 2) NULL,
    [CurrentValue] DECIMAL(10, 2) NULL,
    [Owner] NVARCHAR(200) NULL,
    [Condition] NVARCHAR(50) NOT NULL DEFAULT 'Good', -- 'Excellent', 'Good', 'Fair', 'Poor'
    [Location] NVARCHAR(200) NULL,
    [Notes] NVARCHAR(500) NULL,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    CONSTRAINT FK_Collections_Apartment FOREIGN KEY ([ApartmentId]) REFERENCES [dbo].[Apartments]([ApartmentId])
)
GO

-- Expenses Table
CREATE TABLE [dbo].[Expenses] (
    [ExpenseId] INT PRIMARY KEY IDENTITY(1,1),
    [ApartmentId] INT NOT NULL,
    [CreatedByUserId] INT NOT NULL,
    [ExpenseName] NVARCHAR(200) NOT NULL,
    [Category] NVARCHAR(100) NOT NULL, -- 'Rent', 'Utilities', 'Groceries', 'Maintenance', etc.
    [Amount] DECIMAL(10, 2) NOT NULL,
    [ExpenseDate] DATETIME NOT NULL,
    [Description] NVARCHAR(500) NULL,
    [IsShared] BIT NOT NULL DEFAULT 1, -- If true, split among residents
    [SplitType] NVARCHAR(50) NOT NULL DEFAULT 'Equal', -- 'Equal', 'Custom', 'Percentage'
    [PaymentStatus] NVARCHAR(50) NOT NULL DEFAULT 'Pending', -- 'Pending', 'Paid', 'PartiallyPaid'
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    CONSTRAINT FK_Expenses_Apartment FOREIGN KEY ([ApartmentId]) REFERENCES [dbo].[Apartments]([ApartmentId]),
    CONSTRAINT FK_Expenses_CreatedBy FOREIGN KEY ([CreatedByUserId]) REFERENCES [dbo].[Users]([UserId])
)
GO

-- Expense Splits Table
CREATE TABLE [dbo].[ExpenseSplits] (
    [SplitId] INT PRIMARY KEY IDENTITY(1,1),
    [ExpenseId] INT NOT NULL,
    [ResidentUserId] INT NOT NULL,
    [SplitAmount] DECIMAL(10, 2) NOT NULL,
    [SplitPercentage] DECIMAL(5, 2) NULL,
    [PaymentStatus] NVARCHAR(50) NOT NULL DEFAULT 'Pending', -- 'Pending', 'Paid'
    [PaidDate] DATETIME NULL,
    [PaymentMethod] NVARCHAR(100) NULL, -- 'Cash', 'Transfer', 'Card', etc.
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    CONSTRAINT FK_ExpenseSplits_Expense FOREIGN KEY ([ExpenseId]) REFERENCES [dbo].[Expenses]([ExpenseId]),
    CONSTRAINT FK_ExpenseSplits_Resident FOREIGN KEY ([ResidentUserId]) REFERENCES [dbo].[Users]([UserId])
)
GO

-- Budget Table
CREATE TABLE [dbo].[Budgets] (
    [BudgetId] INT PRIMARY KEY IDENTITY(1,1),
    [ApartmentId] INT NOT NULL,
    [BudgetMonth] INT NOT NULL,
    [BudgetYear] INT NOT NULL,
    [Category] NVARCHAR(100) NOT NULL,
    [PlannedAmount] DECIMAL(10, 2) NOT NULL,
    [AlertThreshold] DECIMAL(5, 2) NOT NULL DEFAULT 80, -- Alert when spending reaches 80%
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    CONSTRAINT FK_Budgets_Apartment FOREIGN KEY ([ApartmentId]) REFERENCES [dbo].[Apartments]([ApartmentId]),
    CONSTRAINT UQ_Budgets_ApartmentMonthCategory UNIQUE ([ApartmentId], [BudgetMonth], [BudgetYear], [Category])
)
GO

-- Payment Records Table
CREATE TABLE [dbo].[PaymentRecords] (
    [PaymentId] INT PRIMARY KEY IDENTITY(1,1),
    [SplitId] INT NOT NULL,
    [PaymentAmount] DECIMAL(10, 2) NOT NULL,
    [PaymentDate] DATETIME NOT NULL,
    [PaymentMethod] NVARCHAR(100) NOT NULL,
    [TransactionReference] NVARCHAR(200) NULL,
    [Notes] NVARCHAR(500) NULL,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    CONSTRAINT FK_PaymentRecords_Split FOREIGN KEY ([SplitId]) REFERENCES [dbo].[ExpenseSplits]([SplitId])
)
GO

-- Audit Log Table
CREATE TABLE [dbo].[AuditLogs] (
    [LogId] INT PRIMARY KEY IDENTITY(1,1),
    [UserId] INT NULL,
    [Action] NVARCHAR(200) NOT NULL,
    [TableName] NVARCHAR(100) NOT NULL,
    [RecordId] INT NULL,
    [OldValues] NVARCHAR(MAX) NULL,
    [NewValues] NVARCHAR(MAX) NULL,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    CONSTRAINT FK_AuditLogs_User FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users]([UserId])
)
GO

-- Create Indexes
CREATE INDEX IX_Expenses_ApartmentId ON [dbo].[Expenses]([ApartmentId])
GO
CREATE INDEX IX_Expenses_ExpenseDate ON [dbo].[Expenses]([ExpenseDate])
GO
CREATE INDEX IX_ExpenseSplits_ExpenseId ON [dbo].[ExpenseSplits]([ExpenseId])
GO
CREATE INDEX IX_ExpenseSplits_ResidentUserId ON [dbo].[ExpenseSplits]([ResidentUserId])
GO
CREATE INDEX IX_Collections_ApartmentId ON [dbo].[Collections]([ApartmentId])
GO
CREATE INDEX IX_ApartmentResidents_ApartmentId ON [dbo].[ApartmentResidents]([ApartmentId])
GO
CREATE INDEX IX_ApartmentResidents_UserId ON [dbo].[ApartmentResidents]([UserId])
GO
CREATE INDEX IX_Budgets_ApartmentId ON [dbo].[Budgets]([ApartmentId])
GO

PRINT 'Database schema created successfully!'