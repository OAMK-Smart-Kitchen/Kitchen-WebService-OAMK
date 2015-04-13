
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/13/2015 09:36:29
-- Generated from EDMX file: C:\Users\Bernd\Documents\GitHub\Kitchen-WebService-OAMK\WebServiceSmartKitchen\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SmartKitchenDBv2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ShoppingBagsShoppingBagProducts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShoppingBagProductsSet] DROP CONSTRAINT [FK_ShoppingBagsShoppingBagProducts];
GO
IF OBJECT_ID(N'[dbo].[FK_KitchenShoppingBags]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShoppingBagsSet] DROP CONSTRAINT [FK_KitchenShoppingBags];
GO
IF OBJECT_ID(N'[dbo].[FK_KitchenDevices]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DevicesSet] DROP CONSTRAINT [FK_KitchenDevices];
GO
IF OBJECT_ID(N'[dbo].[FK_MembersMemberLength]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MemberLengthSet] DROP CONSTRAINT [FK_MembersMemberLength];
GO
IF OBJECT_ID(N'[dbo].[FK_MembersMemberWeight]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MemberWeightSet] DROP CONSTRAINT [FK_MembersMemberWeight];
GO
IF OBJECT_ID(N'[dbo].[FK_KitchenProductsFridge]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductsFridgeSet] DROP CONSTRAINT [FK_KitchenProductsFridge];
GO
IF OBJECT_ID(N'[dbo].[FK_KitchenMembers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MembersSet] DROP CONSTRAINT [FK_KitchenMembers];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DevicesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DevicesSet];
GO
IF OBJECT_ID(N'[dbo].[ExercisesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExercisesSet];
GO
IF OBJECT_ID(N'[dbo].[KitchenSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KitchenSet];
GO
IF OBJECT_ID(N'[dbo].[ShoppingBagsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShoppingBagsSet];
GO
IF OBJECT_ID(N'[dbo].[ShoppingBagProductsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShoppingBagProductsSet];
GO
IF OBJECT_ID(N'[dbo].[MembersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MembersSet];
GO
IF OBJECT_ID(N'[dbo].[MemberLengthSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MemberLengthSet];
GO
IF OBJECT_ID(N'[dbo].[MemberWeightSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MemberWeightSet];
GO
IF OBJECT_ID(N'[dbo].[ProductsFridgeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductsFridgeSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DevicesSet'
CREATE TABLE [dbo].[DevicesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Kitchen_Id] int  NULL
);
GO

-- Creating table 'ExercisesSet'
CREATE TABLE [dbo].[ExercisesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Calories] nvarchar(max)  NOT NULL,
    [Points] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KitchenSet'
CREATE TABLE [dbo].[KitchenSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [TemperatureFridge] nvarchar(max)  NULL
);
GO

-- Creating table 'ShoppingBagsSet'
CREATE TABLE [dbo].[ShoppingBagsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CreatedOn] nvarchar(max)  NOT NULL,
    [Kitchen_Id] int  NULL
);
GO

-- Creating table 'ShoppingBagProductsSet'
CREATE TABLE [dbo].[ShoppingBagProductsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Quantity] nvarchar(max)  NULL,
    [Category] nvarchar(max)  NULL,
    [Shop] nvarchar(max)  NULL,
    [ShoppingBags_Id] int  NULL
);
GO

-- Creating table 'MembersSet'
CREATE TABLE [dbo].[MembersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Firstname] nvarchar(max)  NOT NULL,
    [Lastname] nvarchar(max)  NOT NULL,
    [DateOfBirth] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NOT NULL,
    [PictureUrl] nvarchar(max)  NULL,
    [DefaultColor] nvarchar(max)  NULL,
    [Active] nvarchar(max)  NULL,
    [GameActivated] nvarchar(max)  NULL,
    [GameHealthLevel] nvarchar(max)  NULL,
    [GamePoints] nvarchar(max)  NULL,
    [Password] nvarchar(max)  NULL,
    [Admin] nvarchar(max)  NOT NULL,
    [Kitchen_Id] int  NOT NULL
);
GO

-- Creating table 'MemberLengthSet'
CREATE TABLE [dbo].[MemberLengthSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] nvarchar(max)  NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Members_Id] int  NULL
);
GO

-- Creating table 'MemberWeightSet'
CREATE TABLE [dbo].[MemberWeightSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] nvarchar(max)  NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Members_Id] int  NULL
);
GO

-- Creating table 'ProductsFridgeSet'
CREATE TABLE [dbo].[ProductsFridgeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [IdNFC] nvarchar(max)  NULL,
    [Category] nvarchar(max)  NULL,
    [Calories] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NULL,
    [Quantity] nvarchar(max)  NULL,
    [ExpirationDate] nvarchar(max)  NOT NULL,
    [Available] nvarchar(max)  NOT NULL,
    [Kitchen_Id] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'DevicesSet'
ALTER TABLE [dbo].[DevicesSet]
ADD CONSTRAINT [PK_DevicesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExercisesSet'
ALTER TABLE [dbo].[ExercisesSet]
ADD CONSTRAINT [PK_ExercisesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KitchenSet'
ALTER TABLE [dbo].[KitchenSet]
ADD CONSTRAINT [PK_KitchenSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShoppingBagsSet'
ALTER TABLE [dbo].[ShoppingBagsSet]
ADD CONSTRAINT [PK_ShoppingBagsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShoppingBagProductsSet'
ALTER TABLE [dbo].[ShoppingBagProductsSet]
ADD CONSTRAINT [PK_ShoppingBagProductsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MembersSet'
ALTER TABLE [dbo].[MembersSet]
ADD CONSTRAINT [PK_MembersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MemberLengthSet'
ALTER TABLE [dbo].[MemberLengthSet]
ADD CONSTRAINT [PK_MemberLengthSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MemberWeightSet'
ALTER TABLE [dbo].[MemberWeightSet]
ADD CONSTRAINT [PK_MemberWeightSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductsFridgeSet'
ALTER TABLE [dbo].[ProductsFridgeSet]
ADD CONSTRAINT [PK_ProductsFridgeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ShoppingBags_Id] in table 'ShoppingBagProductsSet'
ALTER TABLE [dbo].[ShoppingBagProductsSet]
ADD CONSTRAINT [FK_ShoppingBagsShoppingBagProducts]
    FOREIGN KEY ([ShoppingBags_Id])
    REFERENCES [dbo].[ShoppingBagsSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShoppingBagsShoppingBagProducts'
CREATE INDEX [IX_FK_ShoppingBagsShoppingBagProducts]
ON [dbo].[ShoppingBagProductsSet]
    ([ShoppingBags_Id]);
GO

-- Creating foreign key on [Kitchen_Id] in table 'ShoppingBagsSet'
ALTER TABLE [dbo].[ShoppingBagsSet]
ADD CONSTRAINT [FK_KitchenShoppingBags]
    FOREIGN KEY ([Kitchen_Id])
    REFERENCES [dbo].[KitchenSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KitchenShoppingBags'
CREATE INDEX [IX_FK_KitchenShoppingBags]
ON [dbo].[ShoppingBagsSet]
    ([Kitchen_Id]);
GO

-- Creating foreign key on [Kitchen_Id] in table 'DevicesSet'
ALTER TABLE [dbo].[DevicesSet]
ADD CONSTRAINT [FK_KitchenDevices]
    FOREIGN KEY ([Kitchen_Id])
    REFERENCES [dbo].[KitchenSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KitchenDevices'
CREATE INDEX [IX_FK_KitchenDevices]
ON [dbo].[DevicesSet]
    ([Kitchen_Id]);
GO

-- Creating foreign key on [Members_Id] in table 'MemberLengthSet'
ALTER TABLE [dbo].[MemberLengthSet]
ADD CONSTRAINT [FK_MembersMemberLength]
    FOREIGN KEY ([Members_Id])
    REFERENCES [dbo].[MembersSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MembersMemberLength'
CREATE INDEX [IX_FK_MembersMemberLength]
ON [dbo].[MemberLengthSet]
    ([Members_Id]);
GO

-- Creating foreign key on [Members_Id] in table 'MemberWeightSet'
ALTER TABLE [dbo].[MemberWeightSet]
ADD CONSTRAINT [FK_MembersMemberWeight]
    FOREIGN KEY ([Members_Id])
    REFERENCES [dbo].[MembersSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MembersMemberWeight'
CREATE INDEX [IX_FK_MembersMemberWeight]
ON [dbo].[MemberWeightSet]
    ([Members_Id]);
GO

-- Creating foreign key on [Kitchen_Id] in table 'ProductsFridgeSet'
ALTER TABLE [dbo].[ProductsFridgeSet]
ADD CONSTRAINT [FK_KitchenProductsFridge]
    FOREIGN KEY ([Kitchen_Id])
    REFERENCES [dbo].[KitchenSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KitchenProductsFridge'
CREATE INDEX [IX_FK_KitchenProductsFridge]
ON [dbo].[ProductsFridgeSet]
    ([Kitchen_Id]);
GO

-- Creating foreign key on [Kitchen_Id] in table 'MembersSet'
ALTER TABLE [dbo].[MembersSet]
ADD CONSTRAINT [FK_KitchenMembers]
    FOREIGN KEY ([Kitchen_Id])
    REFERENCES [dbo].[KitchenSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KitchenMembers'
CREATE INDEX [IX_FK_KitchenMembers]
ON [dbo].[MembersSet]
    ([Kitchen_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------