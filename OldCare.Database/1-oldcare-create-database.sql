/* CREATE DATABASE AND TABLES */

CREATE DATABASE [oldcare]
GO

USE [oldcare]

BEGIN TRANSACTION

    CREATE TABLE [Person] (
        [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
        [Address] VARCHAR(255) NOT NULL,
        [BirthDate] DATETIME NULL,
        [Citizenship] VARCHAR(180) NULL,
        [CEP] INT NOT NULL,
        [City] VARCHAR(180) NOT NULL,
        [CPF] BIGINT NULL,
        [District] VARCHAR(180) NOT NULL,
        [Gender] BIT,
        [Name] VARCHAR(255) NOT NULL,
        [Note] VARCHAR(255) NULL,
        [Photo] VARCHAR(180) NULL,
        [RG] BIGINT NULL,
        [UF] NVARCHAR(2)
    )
    GO

    CREATE TABLE [Bedroom] (
        [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
        [Capacity] INT NOT NULL,
        [Gender] BIT NOT NULL,
        [Number] INT NOT NULL
    )
    GO

    CREATE TABLE [Resident] (
        [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
        [PersonId] UNIQUEIDENTIFIER NOT NULL,
        [BedroomId] UNIQUEIDENTIFIER NULL,
        [AdmissionDate] DATETIME NOT NULL,
        [DepartureDate] DATETIME NULL,
        [Father] VARCHAR(180) NULL,
        [HealthInsurance] VARCHAR(180),
        [MaritalStatus] INT NOT NULL,
        [Mobility] INT NOT NULL,
        [Mother] VARCHAR(180) NULL,
        [Note] VARCHAR(255) NULL,
        [Profession] VARCHAR(100),
        [EducationLevel] INT NOT NULL,
        [SUS] BIGINT NULL,
        [VoterRegCardNumber] BIGINT NULL
    )
    GO

    CREATE TABLE [Responsible] (
        [Id] UNIQUEIDENTIFIER PRIMARY KEY,
        [PersonId] UNIQUEIDENTIFIER NOT NULL,
        [Kinship] INT NOT NULL,
        [PhoneNumber] BIGINT NULL,
    )
    GO

    CREATE TABLE [ResidentResponsible]
    (
        [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
        [ResidentId] UNIQUEIDENTIFIER NOT NULL,
        [ResponsibleId] UNIQUEIDENTIFIER NOT NULL,
        [Forwarder] BIT NOT NULL DEFAULT 1,
        [EndDate] DATETIME NULL,
        [Primary] BIT NOT NULL DEFAULT 1,
        [StartDate] DATETIME NOT NULL
    )

    CREATE TABLE [Occurrence] (
        [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
        [ResidentId] UNIQUEIDENTIFIER NOT NULL,
        [Description] VARCHAR(255) NULL,
        [OccurrenceDate] DATETIME NOT NULL,
        [OccurrenceType] INT NOT NULL
    )
    GO

    CREATE TABLE [Prescription] (
        [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
        [ResidentId] UNIQUEIDENTIFIER NOT NULL,
        [PrescriptionAuthor] VARCHAR(200) NOT NULL,
        [PrescriptionDate] DATETIME NOT NULL,
    )
    GO

    CREATE TABLE [Product](
        [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
        [Name] VARCHAR(150) NOT NULL,
        [UnitOfMeasurement] VARCHAR NULL
    )
    GO

    CREATE TABLE [PrescriptionItem]
    (
        [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
        [PrescriptionId] UNIQUEIDENTIFIER NOT NULL,
        [ProductId] UNIQUEIDENTIFIER NOT NULL,
        [Amount] DECIMAL NOT NULL,
        [Frequency] INT NOT NULL,
        [Interval] INT NOT NULL,
        [Note] VARCHAR(255) NULL,
        [Presentation] VARCHAR(180) NULL
    )
    GO

    CREATE TABLE [Medication] (
        [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
        [PrescriptionItemId] UNIQUEIDENTIFIER NOT NULL,
        [COREN] VARCHAR(10) NOT NULL,
        [MedicationDate] DATETIME NOT NULL,
        [Note] VARCHAR(255) NULL
    )
    GO
ROLLBACK
GO

