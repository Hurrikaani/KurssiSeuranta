
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/14/2018 18:24:11
-- Generated from EDMX file: C:\Users\h0k5\Source\Repos\KurssiSeuranta\KurssiSeuranta\KurssiSeuranta\Models\KurssiKanta.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [KurssiRekisteri];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Läsnäolot__Kurss__5070F446]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Läsnäolotiedot] DROP CONSTRAINT [FK__Läsnäolot__Kurss__5070F446];
GO
IF OBJECT_ID(N'[dbo].[FK__Läsnäolot__Luokk__4D94879B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Läsnäolotiedot] DROP CONSTRAINT [FK__Läsnäolot__Luokk__4D94879B];
GO
IF OBJECT_ID(N'[dbo].[FK__Läsnäolot__Opett__534D60F1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Läsnäolotiedot] DROP CONSTRAINT [FK__Läsnäolot__Opett__534D60F1];
GO
IF OBJECT_ID(N'[dbo].[FK__Läsnäolot__Opisk__5629CD9C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Läsnäolotiedot] DROP CONSTRAINT [FK__Läsnäolot__Opisk__5629CD9C];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Kurssi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kurssi];
GO
IF OBJECT_ID(N'[dbo].[Läsnäolotiedot]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Läsnäolotiedot];
GO
IF OBJECT_ID(N'[dbo].[Opettaja]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Opettaja];
GO
IF OBJECT_ID(N'[dbo].[OpetusTila]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OpetusTila];
GO
IF OBJECT_ID(N'[dbo].[Opiskelija]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Opiskelija];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Kurssi'
CREATE TABLE [dbo].[Kurssi] (
    [Kurssinimi] nvarchar(50)  NULL,
    [Kurssikoodi] nvarchar(50)  NULL,
    [KurssiID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Läsnäolotiedot'
CREATE TABLE [dbo].[Läsnäolotiedot] (
    [Kirjautuminen_sisään] datetime  NULL,
    [Kirjautuminen_ulos] datetime  NULL,
    [Luokkanumero] nvarchar(25)  NULL,
    [RekisteriID] int IDENTITY(1,1) NOT NULL,
    [OpettajaID] int  NULL,
    [KurssiID] int  NULL,
    [OpiskelijaID] int  NULL,
    [LuokkaID] int  NULL,
    [KirjattuID] int  NULL,
    [KurssiRekisteriID] int  NULL,
    [KirjattuUlosID] int  NULL,
    [KurssiUlosID] int  NULL
);
GO

-- Creating table 'Opettaja'
CREATE TABLE [dbo].[Opettaja] (
    [OpettajaID] int IDENTITY(1,1) NOT NULL,
    [Etunimi] nvarchar(50)  NULL,
    [Sukunimi] nvarchar(50)  NULL,
    [Opettajanro] nvarchar(25)  NULL
);
GO

-- Creating table 'OpetusTila'
CREATE TABLE [dbo].[OpetusTila] (
    [LuokkaID] int IDENTITY(1,1) NOT NULL,
    [LuokanNimi] nvarchar(50)  NULL,
    [LuokkaKoodi] nchar(100)  NULL
);
GO

-- Creating table 'Opiskelija'
CREATE TABLE [dbo].[Opiskelija] (
    [Etunimi] nvarchar(50)  NULL,
    [Sukunimi] nvarchar(50)  NULL,
    [Opiskelijanro] nvarchar(25)  NULL,
    [OpiskelijaID] int IDENTITY(1,1) NOT NULL,
    [Tutkinto] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [KurssiID] in table 'Kurssi'
ALTER TABLE [dbo].[Kurssi]
ADD CONSTRAINT [PK_Kurssi]
    PRIMARY KEY CLUSTERED ([KurssiID] ASC);
GO

-- Creating primary key on [RekisteriID] in table 'Läsnäolotiedot'
ALTER TABLE [dbo].[Läsnäolotiedot]
ADD CONSTRAINT [PK_Läsnäolotiedot]
    PRIMARY KEY CLUSTERED ([RekisteriID] ASC);
GO

-- Creating primary key on [OpettajaID] in table 'Opettaja'
ALTER TABLE [dbo].[Opettaja]
ADD CONSTRAINT [PK_Opettaja]
    PRIMARY KEY CLUSTERED ([OpettajaID] ASC);
GO

-- Creating primary key on [LuokkaID] in table 'OpetusTila'
ALTER TABLE [dbo].[OpetusTila]
ADD CONSTRAINT [PK_OpetusTila]
    PRIMARY KEY CLUSTERED ([LuokkaID] ASC);
GO

-- Creating primary key on [OpiskelijaID] in table 'Opiskelija'
ALTER TABLE [dbo].[Opiskelija]
ADD CONSTRAINT [PK_Opiskelija]
    PRIMARY KEY CLUSTERED ([OpiskelijaID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [KurssiID] in table 'Läsnäolotiedot'
ALTER TABLE [dbo].[Läsnäolotiedot]
ADD CONSTRAINT [FK__Läsnäolot__Kurss__5070F446]
    FOREIGN KEY ([KurssiID])
    REFERENCES [dbo].[Kurssi]
        ([KurssiID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Läsnäolot__Kurss__5070F446'
CREATE INDEX [IX_FK__Läsnäolot__Kurss__5070F446]
ON [dbo].[Läsnäolotiedot]
    ([KurssiID]);
GO

-- Creating foreign key on [LuokkaID] in table 'Läsnäolotiedot'
ALTER TABLE [dbo].[Läsnäolotiedot]
ADD CONSTRAINT [FK__Läsnäolot__Luokk__4D94879B]
    FOREIGN KEY ([LuokkaID])
    REFERENCES [dbo].[OpetusTila]
        ([LuokkaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Läsnäolot__Luokk__4D94879B'
CREATE INDEX [IX_FK__Läsnäolot__Luokk__4D94879B]
ON [dbo].[Läsnäolotiedot]
    ([LuokkaID]);
GO

-- Creating foreign key on [OpettajaID] in table 'Läsnäolotiedot'
ALTER TABLE [dbo].[Läsnäolotiedot]
ADD CONSTRAINT [FK__Läsnäolot__Opett__534D60F1]
    FOREIGN KEY ([OpettajaID])
    REFERENCES [dbo].[Opettaja]
        ([OpettajaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Läsnäolot__Opett__534D60F1'
CREATE INDEX [IX_FK__Läsnäolot__Opett__534D60F1]
ON [dbo].[Läsnäolotiedot]
    ([OpettajaID]);
GO

-- Creating foreign key on [OpiskelijaID] in table 'Läsnäolotiedot'
ALTER TABLE [dbo].[Läsnäolotiedot]
ADD CONSTRAINT [FK__Läsnäolot__Opisk__5629CD9C]
    FOREIGN KEY ([OpiskelijaID])
    REFERENCES [dbo].[Opiskelija]
        ([OpiskelijaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Läsnäolot__Opisk__5629CD9C'
CREATE INDEX [IX_FK__Läsnäolot__Opisk__5629CD9C]
ON [dbo].[Läsnäolotiedot]
    ([OpiskelijaID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------