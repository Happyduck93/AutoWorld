CREATE TABLE [dbo].[tb_category]
(
	[category_id] VARCHAR(50) NOT NULL PRIMARY KEY,
	[category_descr] nvarchar (50) NOT NULL,
	[active_yn] BIT NULL,
	[abbr_cd] CHAR(3) NULL,
	[create_dt] DATETIME NULL
)
