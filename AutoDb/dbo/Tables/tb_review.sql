CREATE TABLE [dbo].[tb_review]
(
	[auto_id] CHAR(14) NOT NULL,
	[user_id] nvarchar(50) NOT NULL,
	[review_date] datetime,
	[review_descr] Nvarchar(2000) NOT NULL
	PRIMARY KEY ([auto_id], [user_id])
)
