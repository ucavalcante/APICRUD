IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Seguros] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [VigenciaLimite] datetime2 NOT NULL,
    [DtContratacao] datetime2 NOT NULL,
    [Abrangencia] int NOT NULL,
    CONSTRAINT [PK_Seguros] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191107024558_InitialCreate', N'3.0.0');

GO

