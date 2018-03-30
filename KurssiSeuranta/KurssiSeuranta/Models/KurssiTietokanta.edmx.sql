
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/29/2018 14:22:30
-- Generated from EDMX file: C:\Users\hurri\Source\Repos\KurssiSeuranta\KurssiSeuranta\KurssiSeuranta\Models\KurssiTietokanta.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Opiskelijarekisteri];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Kurssi__Opiskeli__571DF1D5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kurssi] DROP CONSTRAINT [FK__Kurssi__Opiskeli__571DF1D5];
GO
IF OBJECT_ID(N'[dbo].[FK__Kurssi__Rekister__5812160E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kurssi] DROP CONSTRAINT [FK__Kurssi__Rekister__5812160E];
GO
IF OBJECT_ID(N'[dbo].[FK__Lasnaolot__Opett__5441852A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Lasnaolotiedot] DROP CONSTRAINT [FK__Lasnaolot__Opett__5441852A];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Kurssi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kurssi];
GO
IF OBJECT_ID(N'[dbo].[Lasnaolotiedot]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lasnaolotiedot];
GO
IF OBJECT_ID(N'[dbo].[Opettaja]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Opettaja];
GO
IF OBJECT_ID(N'[dbo].[Opiskelija]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Opiskelija];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Kurssi'
CREATE TABLE [dbo].[Kurssi] (
    [Kurssinimi] varchar(50)  NULL,
    [Kurssikoodi] int  NULL,
    [Luokka] varchar(50)  NULL,
    [KurssiID] int IDENTITY(1,1) NOT NULL,
    [RekisteriID] int  NULL,
    [OpiskelijaID] int  NULL
);
GO

-- Creating table 'Lasnaolotiedot'
CREATE TABLE [dbo].[Lasnaolotiedot] (
    [Kirjautuminen_sisaan] datetime  NULL,
    [Kirjautuminen_ulos] datetime  NULL,
    [Luokkanumero] int  NULL,
    [OpettajaID] int  NULL,
    [RekisteriID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Opettaja'
CREATE TABLE [dbo].[Opettaja] (
    [OpettajaID] int IDENTITY(1,1) NOT NULL,
    [Etunimi] varchar(50)  NULL,
    [Sukunimi] varchar(50)  NULL,
    [Opettajanro] int  NOT NULL
);
GO

-- Creating table 'Opiskelija'
CREATE TABLE [dbo].[Opiskelija] (
    [Etunimi] varchar(50)  NULL,
    [Sukunimi] varchar(50)  NULL,
    [Opiskelijanro] int  NOT NULL,
    [OpiskelijaID] int IDENTITY(1,1) NOT NULL,
    [Tutkinto] varchar(50)  NULL
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

-- Creating primary key on [RekisteriID] in table 'Lasnaolotiedot'
ALTER TABLE [dbo].[Lasnaolotiedot]
ADD CONSTRAINT [PK_Lasnaolotiedot]
    PRIMARY KEY CLUSTERED ([RekisteriID] ASC);
GO

-- Creating primary key on [OpettajaID] in table 'Opettaja'
ALTER TABLE [dbo].[Opettaja]
ADD CONSTRAINT [PK_Opettaja]
    PRIMARY KEY CLUSTERED ([OpettajaID] ASC);
GO

-- Creating primary key on [OpiskelijaID] in table 'Opiskelija'
ALTER TABLE [dbo].[Opiskelija]
ADD CONSTRAINT [PK_Opiskelija]
    PRIMARY KEY CLUSTERED ([OpiskelijaID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [OpiskelijaID] in table 'Kurssi'
ALTER TABLE [dbo].[Kurssi]
ADD CONSTRAINT [FK__Kurssi__Opiskeli__571DF1D5]
    FOREIGN KEY ([OpiskelijaID])
    REFERENCES [dbo].[Opiskelija]
        ([OpiskelijaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Kurssi__Opiskeli__571DF1D5'
CREATE INDEX [IX_FK__Kurssi__Opiskeli__571DF1D5]
ON [dbo].[Kurssi]
    ([OpiskelijaID]);
GO

-- Creating foreign key on [RekisteriID] in table 'Kurssi'
ALTER TABLE [dbo].[Kurssi]
ADD CONSTRAINT [FK__Kurssi__Rekister__5812160E]
    FOREIGN KEY ([RekisteriID])
    REFERENCES [dbo].[Lasnaolotiedot]
        ([RekisteriID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Kurssi__Rekister__5812160E'
CREATE INDEX [IX_FK__Kurssi__Rekister__5812160E]
ON [dbo].[Kurssi]
    ([RekisteriID]);
GO

-- Creating foreign key on [OpettajaID] in table 'Lasnaolotiedot'
ALTER TABLE [dbo].[Lasnaolotiedot]
ADD CONSTRAINT [FK__Lasnaolot__Opett__5441852A]
    FOREIGN KEY ([OpettajaID])
    REFERENCES [dbo].[Opettaja]
        ([OpettajaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Lasnaolot__Opett__5441852A'
CREATE INDEX [IX_FK__Lasnaolot__Opett__5441852A]
ON [dbo].[Lasnaolotiedot]
    ([OpettajaID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------