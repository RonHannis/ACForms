IF OBJECT_ID(N'[uipath].[__migrations]') IS NULL
BEGIN
    IF SCHEMA_ID(N'uipath') IS NULL EXEC(N'CREATE SCHEMA [uipath];');
    CREATE TABLE [uipath].[__migrations] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___migrations] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [uipath].[__migrations] WHERE [MigrationId] = N'20201030125220_Init')
BEGIN
    IF SCHEMA_ID(N'uipath') IS NULL EXEC(N'CREATE SCHEMA [uipath];');
END;

GO

IF NOT EXISTS(SELECT * FROM [uipath].[__migrations] WHERE [MigrationId] = N'20201030125220_Init')
BEGIN
    CREATE TABLE [uipath].[Submissions] (
        [Id] bigint NOT NULL IDENTITY,
        [FormEntryId] uniqueidentifier NOT NULL,
        [Processed] bit NOT NULL,
        [SubmissionDate] datetime2 NOT NULL,
        [ProcessedDate] datetime2 NULL,
        [MemberFirstName] varchar(100) NULL,
        [MemberLastName] varchar(100) NULL,
        [MemberDOB] datetime2 NOT NULL,
        [DiagnosisCodes] varchar(1000) NULL,
        [CPTCodes] varchar(1000) NULL,
        [NPIReferTo] varchar(10) NULL,
        [NPIReferFrom] varchar(10) NULL,
        [PDFPath] varchar(1000) NULL,
        CONSTRAINT [PK_Submissions] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [uipath].[__migrations] WHERE [MigrationId] = N'20201030125220_Init')
BEGIN
    INSERT INTO [uipath].[__migrations] ([MigrationId], [ProductVersion])
    VALUES (N'20201030125220_Init', N'3.1.9');
END;

GO

