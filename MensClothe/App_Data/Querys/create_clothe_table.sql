CREATE TABLE [dbo].[Products]
(
	[ItemName] VARCHAR(50) NULL, 
    [ItemID] BIGINT NOT NULL, 
    [ItemImage] VARCHAR(120) NULL, 
    [Price] MONEY NOT NULL DEFAULT 0, 
    [QOH] SMALLINT NULL DEFAULT 0, 
    [Description] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([ItemID]) 
)
    