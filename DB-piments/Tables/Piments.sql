CREATE TABLE [dbo].[Piments]
(
	[Id] INT NOT NULL IDENTITY, 
    [Name] VARCHAR(50) UNIQUE NOT NULL,
    [Picture] VARCHAR(250),
    [Category] VARCHAR(50) NOT NULL,
    [Description] VARCHAR(250) NOT NULL,
    [Price] DECIMAL(5,2) NOT NULL,
    [ScovilleScale] VARCHAR(100) NOT NULL,

    CONSTRAINT [PK_Piments] PRIMARY KEY ([Id]) 
)
