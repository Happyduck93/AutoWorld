CREATE PROCEDURE [dbo].[sp_insert_brand]
	@brandId char(14) output,
	@brandCodeId char (5),
	@brandCodeDescr nvarchar (50),
	--@categoryId varchar (50),
	@brandName nvarchar (50),
	@brandDescr nvarchar (50),
	@establishment datetime,
	@headquarters nvarchar(50)

AS
BEGIN
	DECLARE @newId char(14) = dbo.fn_get_brand_id(@establishment);
	INSERT INTO tb_brand
	(
		brand_id
		,brand_code_id
		,brand_code_descr
		--,category_id
		,brand_name
		,brand_descr
		,founded_date
		,headquarter
	
	)
	VALUES 
	(
		-- same order as tb_brand
		
		@newId
		,@brandCodeId
		,@brandCodeDescr
		--,@categoryId
		,@brandName
		,@brandDescr
		,@establishment
		,@headquarters
	)
	SET @brandId = @newId
END