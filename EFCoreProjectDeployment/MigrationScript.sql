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

CREATE TABLE [Products] (
    [Id] bigint NOT NULL IDENTITY,
    [ItemCount] int NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ItemDetails] (
    [Id] bigint NOT NULL IDENTITY,
    [ItemName] nvarchar(max) NOT NULL,
    [UnitPrice] decimal(18,2) NOT NULL,
    [ProductId] bigint NOT NULL,
    CONSTRAINT [PK_ItemDetails] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ItemDetails_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_ItemDetails_ProductId] ON [ItemDetails] ([ProductId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240912140049_init', N'6.0.10');
GO

COMMIT;
GO

