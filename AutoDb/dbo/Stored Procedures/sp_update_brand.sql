CREATE PROCEDURE [dbo].[sp_update_brand]
	@brandId char(14) output,
	@brandCodeId char (5),
	--@brandCodeDescr nvarchar (50),
	--@categoryId varchar (50),
	@brandName nvarchar (50),
	@brandDescr nvarchar (50),
	@establishment datetime,
	@headquarters nvarchar(50)

AS
BEGIN
	UPDATE tb_brand
	   SET brand_code_id    = @brandCodeId
		   --,brand_code_descr = @brandCodeDescr
		   ,brand_name       = @brandName
		   ,brand_descr		 = @brandDescr
		   ,founded_date     = @establishment
		   ,headquarter      = @headquarters
	 WHERE brand_id          = @brandId

END