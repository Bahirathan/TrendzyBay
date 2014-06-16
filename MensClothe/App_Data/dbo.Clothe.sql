CREATE TABLE [dbo].[Products] (
    [ItemName]    VARCHAR (50)   NOT NULL,
    [ItemID]      BIGINT         IDENTITY (1, 1) NOT NULL,
    [ItemImage]   VARCHAR (120)  NULL,
    [Price]       MONEY          DEFAULT ((0)) NOT NULL,
    [QOH]         SMALLINT       DEFAULT ((0)) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Size]        NCHAR(10)       NULL,
    CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED ([ItemID] ASC)
);

