CREATE TABLE [dbo].[tb_brand]
(
	--[category_id] varchar (50) NULL,
	[brand_id] char(14) NOT NULL PRIMARY KEY, 
	[brand_code_id] char(5),
	[brand_code_descr] nvarchar (50) NULL,
	[brand_name] NVARCHAR (50) NOT NULL,
	[brand_descr] NVARCHAR (50) NULL,
	[founded_date] DATETIME NOT NULL, 
	[headquarter] NVARCHAR (50) NULL
)
