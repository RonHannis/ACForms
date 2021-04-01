IF OBJECT_ID(N'[registration].[__migrations]') IS NULL
BEGIN
    IF SCHEMA_ID(N'registration') IS NULL EXEC(N'CREATE SCHEMA [registration];');
    CREATE TABLE [registration].[__migrations] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___migrations] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [registration].[__migrations] WHERE [MigrationId] = N'20210205190717_InitializeRegistrationSchema')
BEGIN
    IF SCHEMA_ID(N'registration') IS NULL EXEC(N'CREATE SCHEMA [registration];');
END;

GO

IF NOT EXISTS(SELECT * FROM [registration].[__migrations] WHERE [MigrationId] = N'20210205190717_InitializeRegistrationSchema')
BEGIN
    CREATE TABLE [registration].[Providers] (
        [Id] bigint NOT NULL IDENTITY,
        [FormEntryId] uniqueidentifier NOT NULL,
        [Processed] bit NOT NULL,
        [SubmissionDate] datetime2 NOT NULL,
        [ProcessedDate] datetime2 NULL,
        [PDFPath] varchar(1000) NULL,
        [Username] varchar(100) NULL,
        [FirstName] varchar(100) NULL,
        [LastName] varchar(100) NULL,
        [MiddleInitial] varchar(1) NULL,
        [Email] varchar(100) NULL,
        [Phone] varchar(20) NULL,
        [Position] varchar(100) NULL,
        [ProviderNPI] varchar(10) NULL,
        [ProviderTaxId] varchar(10) NULL,
        [ProviderPhysician] varchar(100) NULL,
        [ProviderCompany] varchar(500) NULL,
        [ProviderPhone] varchar(20) NULL,
        [ProviderAddress1] varchar(500) NULL,
        [ProviderAddress2] varchar(500) NULL,
        [ProviderCity] varchar(500) NULL,
        [ProviderState] varchar(50) NULL,
        [ProviderZip] varchar(10) NULL,
        [AccessNeeds] nvarchar(max) NULL,
        [AccessReason] nvarchar(max) NULL,
        [AccessComments] nvarchar(max) NULL,
        [NeedsECPA] bit NOT NULL,
        [NeedsEE] bit NOT NULL,
        [NeedsQPP] bit NOT NULL,
        [NeedsFTP] bit NOT NULL,
        [IPAddresses] varchar(1000) NULL,
        CONSTRAINT [PK_Providers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [registration].[__migrations] WHERE [MigrationId] = N'20210205190717_InitializeRegistrationSchema')
BEGIN
    INSERT INTO [registration].[__migrations] ([MigrationId], [ProductVersion])
    VALUES (N'20210205190717_InitializeRegistrationSchema', N'3.1.9');
END;

GO

