** Run

dotnet ef database update
dotnet run


** SQL TABLE

CREATE DATABASE MedicationDB;
GO

USE MedicationDB;
GO

CREATE TABLE Medications (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NULL,
    Dosage NVARCHAR(100) NULL,
    ImageUrl NVARCHAR(200) NULL
);