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

CREATE TABLE [Genres] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(24) NOT NULL,
    CONSTRAINT [PK_Genres] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Movies] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(512) NOT NULL,
    [Overview] nvarchar(max) NOT NULL,
    [Tagline] nvarchar(512) NOT NULL,
    [Budget] decimal(18,4) NULL DEFAULT 9.9,
    [Revenue] decimal(18,4) NULL DEFAULT 9.9,
    [ImdbUrl] nvarchar(2084) NOT NULL,
    [TmdbUrl] nvarchar(2084) NOT NULL,
    [PosterUrl] nvarchar(2084) NOT NULL,
    [BackdropUrl] nvarchar(2084) NOT NULL,
    [OriginalLanguage] nvarchar(64) NOT NULL,
    [ReleaseDate] datetime2 NULL,
    [RunTime] int NULL,
    [Price] decimal(5,2) NULL DEFAULT 9.9,
    [CreatedDate] datetime2 NULL DEFAULT (getdate()),
    [UpdatedDate] datetime2 NULL,
    [UpdatedBy] nvarchar(512) NULL,
    [CreatedBy] nvarchar(512) NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [MovieGenres] (
    [MovieId] int NOT NULL,
    [GenreId] int NOT NULL,
    CONSTRAINT [PK_MovieGenres] PRIMARY KEY ([MovieId], [GenreId]),
    CONSTRAINT [FK_MovieGenres_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MovieGenres_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_MovieGenres_GenreId] ON [MovieGenres] ([GenreId]);
GO

CREATE INDEX [IX_Movies_Budget] ON [Movies] ([Budget]);
GO

CREATE INDEX [IX_Movies_Price] ON [Movies] ([Price]);
GO

CREATE INDEX [IX_Movies_Revenue] ON [Movies] ([Revenue]);
GO

CREATE INDEX [IX_Movies_Title] ON [Movies] ([Title]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220829104006_InitialTables', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Trailers] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(2084) NOT NULL,
    [TrailerUrl] nvarchar(2084) NOT NULL,
    [MovieId] int NOT NULL,
    CONSTRAINT [PK_Trailers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Trailers_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Trailers_MovieId] ON [Trailers] ([MovieId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220829104444_TrailerTable', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Cast] (
    [Id] int NOT NULL IDENTITY,
    [Gender] nvarchar(max) NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    [ProfilePath] nvarchar(2084) NOT NULL,
    [TmdbUrl] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Cast] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [MovieCast] (
    [CastId] int NOT NULL,
    [Character] nvarchar(450) NOT NULL,
    [MovieId] int NOT NULL,
    CONSTRAINT [PK_MovieCast] PRIMARY KEY ([MovieId], [Character], [CastId]),
    CONSTRAINT [FK_MovieCast_Cast_CastId] FOREIGN KEY ([CastId]) REFERENCES [Cast] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MovieCast_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_MovieCast_CastId] ON [MovieCast] ([CastId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220829105009_CastMovieCastTable', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [DateOfBirth] datetime2 NULL,
    [Email] nvarchar(256) NOT NULL,
    [FirstName] nvarchar(128) NOT NULL,
    [HashedPassword] nvarchar(1024) NOT NULL,
    [IsLocked] int NOT NULL,
    [LastName] nvarchar(128) NOT NULL,
    [PhoneNumber] nvarchar(16) NOT NULL,
    [ProfilePictureUrl] nvarchar(max) NOT NULL,
    [Salt] nvarchar(1024) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220829105512_UsersTable', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Favorites] (
    [MovieId] int NOT NULL,
    [UserId] int NOT NULL,
    [UsersId] int NOT NULL,
    CONSTRAINT [PK_Favorites] PRIMARY KEY ([MovieId], [UserId]),
    CONSTRAINT [FK_Favorites_Genres_UsersId] FOREIGN KEY ([UsersId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Favorites_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Favorites_UsersId] ON [Favorites] ([UsersId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220829105828_FavoritesTable', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Roles] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(20) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [UserRoles] (
    [RoleId] int NOT NULL,
    [UserId] int NOT NULL,
    [RolesId] int NOT NULL,
    [UsersId] int NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([RoleId], [UserId]),
    CONSTRAINT [FK_UserRoles_Genres_UsersId] FOREIGN KEY ([UsersId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRoles_Movies_RolesId] FOREIGN KEY ([RolesId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_UserRoles_RolesId] ON [UserRoles] ([RolesId]);
GO

CREATE INDEX [IX_UserRoles_UsersId] ON [UserRoles] ([UsersId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220829110338_RolesUserRolesTable', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Reviews] (
    [MovieId] int NOT NULL,
    [UserId] int NOT NULL,
    [CreatedDate] datetime2 NULL DEFAULT (getdate()),
    [Rating] decimal(3,2) NULL DEFAULT 9.9,
    [ReviewText] nvarchar(max) NOT NULL,
    [UsersId] int NOT NULL,
    CONSTRAINT [PK_Reviews] PRIMARY KEY ([MovieId], [UserId]),
    CONSTRAINT [FK_Reviews_Genres_UsersId] FOREIGN KEY ([UsersId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Reviews_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Reviews_UsersId] ON [Reviews] ([UsersId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220829110625_ReviewsTable', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Purchases] (
    [MovieId] int NOT NULL,
    [UserId] int NOT NULL,
    [PurchaseDateTime] datetime2 NULL,
    [PurchaseNumber] int NOT NULL,
    [TotalPrice] decimal(5,2) NOT NULL DEFAULT 9.9,
    [UsersId] int NOT NULL,
    CONSTRAINT [PK_Purchases] PRIMARY KEY ([MovieId], [UserId]),
    CONSTRAINT [FK_Purchases_Genres_UsersId] FOREIGN KEY ([UsersId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Purchases_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Purchases_UsersId] ON [Purchases] ([UsersId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220829110904_PurchasesTable', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [MovieCast] DROP CONSTRAINT [FK_MovieCast_Cast_CastId];
GO

ALTER TABLE [MovieCast] DROP CONSTRAINT [FK_MovieCast_Movies_MovieId];
GO

ALTER TABLE [MovieCast] DROP CONSTRAINT [PK_MovieCast];
GO

EXEC sp_rename N'[MovieCast]', N'MovieCasts';
GO

EXEC sp_rename N'[MovieCasts].[IX_MovieCast_CastId]', N'IX_MovieCasts_CastId', N'INDEX';
GO

ALTER TABLE [MovieCasts] ADD CONSTRAINT [PK_MovieCasts] PRIMARY KEY ([MovieId], [Character], [CastId]);
GO

ALTER TABLE [MovieCasts] ADD CONSTRAINT [FK_MovieCasts_Cast_CastId] FOREIGN KEY ([CastId]) REFERENCES [Cast] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [MovieCasts] ADD CONSTRAINT [FK_MovieCasts_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220829152920_ChangeMovieCastname', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220829153909_ChangedCastName', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [MovieCasts] DROP CONSTRAINT [FK_MovieCasts_Cast_CastId];
GO

ALTER TABLE [Cast] DROP CONSTRAINT [PK_Cast];
GO

EXEC sp_rename N'[Cast]', N'Casts';
GO

ALTER TABLE [Casts] ADD CONSTRAINT [PK_Casts] PRIMARY KEY ([Id]);
GO

ALTER TABLE [MovieCasts] ADD CONSTRAINT [FK_MovieCasts_Casts_CastId] FOREIGN KEY ([CastId]) REFERENCES [Casts] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220829154102_ChangedCastName2', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220829180723_EditedMovies', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'PhoneNumber');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Users] ALTER COLUMN [PhoneNumber] nvarchar(64) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'IsLocked');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Users] ALTER COLUMN [IsLocked] int NOT NULL;
ALTER TABLE [Users] ADD DEFAULT 0 FOR [IsLocked];
GO

CREATE UNIQUE INDEX [IX_Users_Email] ON [Users] ([Email]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220830171520_EditedUsers', N'6.0.8');
GO

COMMIT;
GO

