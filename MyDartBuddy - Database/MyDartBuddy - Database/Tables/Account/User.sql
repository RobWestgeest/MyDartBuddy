CREATE TABLE [Account].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Account].[User] ADD  CONSTRAINT [DF_Account_RecUID]  DEFAULT (newid()) FOR [Id]
GO
