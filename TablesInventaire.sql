CREATE TABLE [dbo].[article] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Nom]         NVARCHAR (50) NULL,
    [Description] TEXT          NULL,
    [CategorieId] INT           NULL,
    [Quantite]    INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Categorie] (
    [Id]  INT          IDENTITY (1, 1) NOT NULL,
    [nom] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);