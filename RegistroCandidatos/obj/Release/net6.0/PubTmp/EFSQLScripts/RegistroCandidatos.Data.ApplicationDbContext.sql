IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221112194601_CreandoTablaCandidatoYGeneroConSuRelacion')
BEGIN
    CREATE TABLE [Genero] (
        [ID_Genero] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NULL,
        CONSTRAINT [PK_Genero] PRIMARY KEY ([ID_Genero])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221112194601_CreandoTablaCandidatoYGeneroConSuRelacion')
BEGIN
    CREATE TABLE [Candidato] (
        [ID_Candidato] int NOT NULL IDENTITY,
        [Cedula] nvarchar(max) NOT NULL,
        [Nombres] nvarchar(max) NOT NULL,
        [Apellidos] nvarchar(max) NOT NULL,
        [FechaDeNacimiento] datetime2 NOT NULL,
        [ID_Genero] int NOT NULL,
        [TrabajoActual] nvarchar(max) NULL,
        [ExpectativaSalarial] nvarchar(max) NULL,
        CONSTRAINT [PK_Candidato] PRIMARY KEY ([ID_Candidato]),
        CONSTRAINT [FK_Candidato_Genero_ID_Genero] FOREIGN KEY ([ID_Genero]) REFERENCES [Genero] ([ID_Genero]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221112194601_CreandoTablaCandidatoYGeneroConSuRelacion')
BEGIN
    CREATE INDEX [IX_Candidato_ID_Genero] ON [Candidato] ([ID_Genero]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221112194601_CreandoTablaCandidatoYGeneroConSuRelacion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221112194601_CreandoTablaCandidatoYGeneroConSuRelacion', N'6.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221112200423_ConvirtiendoCampoCedulaEnValorUnicoEnBaseDeDatos')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Candidato]') AND [c].[name] = N'Cedula');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Candidato] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Candidato] ALTER COLUMN [Cedula] nvarchar(450) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221112200423_ConvirtiendoCampoCedulaEnValorUnicoEnBaseDeDatos')
BEGIN
    CREATE UNIQUE INDEX [IX_Candidato_Cedula] ON [Candidato] ([Cedula]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221112200423_ConvirtiendoCampoCedulaEnValorUnicoEnBaseDeDatos')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221112200423_ConvirtiendoCampoCedulaEnValorUnicoEnBaseDeDatos', N'6.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221114182944_quitandoForeignKeyDeTablaCandidato')
BEGIN
    ALTER TABLE [Candidato] DROP CONSTRAINT [FK_Candidato_Genero_ID_Genero];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221114182944_quitandoForeignKeyDeTablaCandidato')
BEGIN
    DROP INDEX [IX_Candidato_ID_Genero] ON [Candidato];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221114182944_quitandoForeignKeyDeTablaCandidato')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Candidato]') AND [c].[name] = N'ID_Genero');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Candidato] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Candidato] DROP COLUMN [ID_Genero];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221114182944_quitandoForeignKeyDeTablaCandidato')
BEGIN
    EXEC sp_rename N'[Genero].[Nombre]', N'NombreGenero', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221114182944_quitandoForeignKeyDeTablaCandidato')
BEGIN
    ALTER TABLE [Candidato] ADD [GeneroID_Genero] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221114182944_quitandoForeignKeyDeTablaCandidato')
BEGIN
    CREATE INDEX [IX_Candidato_GeneroID_Genero] ON [Candidato] ([GeneroID_Genero]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221114182944_quitandoForeignKeyDeTablaCandidato')
BEGIN
    ALTER TABLE [Candidato] ADD CONSTRAINT [FK_Candidato_Genero_GeneroID_Genero] FOREIGN KEY ([GeneroID_Genero]) REFERENCES [Genero] ([ID_Genero]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221114182944_quitandoForeignKeyDeTablaCandidato')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221114182944_quitandoForeignKeyDeTablaCandidato', N'6.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221114183226_quitandotablaGenero')
BEGIN
    ALTER TABLE [Candidato] DROP CONSTRAINT [FK_Candidato_Genero_GeneroID_Genero];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221114183226_quitandotablaGenero')
BEGIN
    DROP TABLE [Genero];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221114183226_quitandotablaGenero')
BEGIN
    DROP INDEX [IX_Candidato_GeneroID_Genero] ON [Candidato];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221114183226_quitandotablaGenero')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Candidato]') AND [c].[name] = N'GeneroID_Genero');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Candidato] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Candidato] DROP COLUMN [GeneroID_Genero];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221114183226_quitandotablaGenero')
BEGIN
    ALTER TABLE [Candidato] ADD [Genero] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221114183226_quitandotablaGenero')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221114183226_quitandotablaGenero', N'6.0.11');
END;
GO

COMMIT;
GO

