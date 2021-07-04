
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/22/2020 15:58:21
-- Generated from EDMX file: D:\лабы\ПWС\Lab6\Lab6Service\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WSSPAA];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Marks_Student]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Marks] DROP CONSTRAINT [FK_Marks_Student];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Marks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Marks];
GO
IF OBJECT_ID(N'[dbo].[Students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Students];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Marks'
CREATE TABLE [dbo].[Marks] (
    [id] int  NOT NULL,
    [subject] nvarchar(50)  NOT NULL,
    [mark1] int  NOT NULL
);
GO

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id], [subject], [mark1] in table 'Marks'
ALTER TABLE [dbo].[Marks]
ADD CONSTRAINT [PK_Marks]
    PRIMARY KEY CLUSTERED ([id], [subject], [mark1] ASC);
GO

-- Creating primary key on [id] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id] in table 'Marks'
ALTER TABLE [dbo].[Marks]
ADD CONSTRAINT [FK_Marks_Student]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[Students]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------