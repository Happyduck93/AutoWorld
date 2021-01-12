CREATE PROCEDURE [dbo].[sp_insert_category]
	--variables to take input
	@categoryId varchar (50) output,
	@categoryDescr nvarchar (50),
	@abbrCd char (3)
AS
BEGIN
	INSERT INTO tb_category
	VALUES (
				-- order should be same as the tb_category
				@categoryId
				,@categoryDescr
				,1
				,@abbrCd
				,GETDATE()
			)
END