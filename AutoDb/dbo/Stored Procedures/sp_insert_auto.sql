CREATE PROCEDURE [dbo].[sp_insert_auto]
	@autoId char (14) output,
	@autoName varchar (100),
	@autoDescr nvarchar (50),
	@released datetime,
	@brandId varchar (50),
	@trim Nvarchar (10),
	@color nvarchar (100),
	@price money,
	@year numeric (4,0),
	@autoType char(5)
AS
BEGIN
	DECLARE @newId char (14) = dbo.fn_get_auto_id(@released);
	INSERT INTO tb_auto
	(
		auto_id
		,auto_name
		,auto_descr
		,released
		,brand_id
		,[trim]
		,price
		,color
		,[year]
		,auto_type
		
	)
	VALUES
	(
		@newId
		,@autoName
		,@autoDescr
		,@released
		,@brandId
		,@trim
		,@price
		,@color
		,@year
		,@autoType
	)
	SET @autoId = @newId
	
END