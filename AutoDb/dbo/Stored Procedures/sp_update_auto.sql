CREATE PROCEDURE [dbo].[sp_update_auto]

	@autoId char (14) output,
	@autoName varchar (100),
	@autoDescr nvarchar (50),
	@released datetime,
	@brandId varchar (50),
	@trim Nvarchar (10),
	@color nvarchar (100),
	@price money,
	@year numeric (4,0),
	@autoType char (5)
AS
BEGIN
	UPDATE tb_auto
	   SET 
			auto_name = @autoName
			,auto_descr = @autoDescr
			,brand_id = @brandId
			,[trim] = @trim
			,color = @color
			,price = @price
			,[year] = @year
			,auto_type = @autoType
	 WHERE auto_id = @autoId
	
END