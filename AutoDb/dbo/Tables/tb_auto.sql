CREATE TABLE [dbo].[tb_auto]
(
	[auto_id] VARCHAR (50) NOT NULL,
	[auto_type] char (5) NOT NULL,
	[brand_id] varchar (50) NOT NULL,
	[auto_name] varchar(100) NOT NULL,
	[price] MONEY NOT NULL,
	[auto_descr] NVARCHAR (50) NULL,
	[trim] NVARCHAR (10) NOT NULL,
	[year] NUMERIC (4,0) NOT NULL,
	[color] nvarchar(100) NULL,
	[released] datetime NOt Null
	PRIMARY KEY ([auto_id], [auto_type], [brand_id])


)
