CREATE TABLE [dbo].[tb_code]
(
	[code_id] char(5) NOT NULL,
	[category_id] varchar (50) NOT NULL,
	[active_yn] BIT NULL,
	[code_descr] NVARCHAR (50) NULL,
	[create_dt] DATETIME NULL,
	PRIMARY KEY ([code_id], [category_id])
)
