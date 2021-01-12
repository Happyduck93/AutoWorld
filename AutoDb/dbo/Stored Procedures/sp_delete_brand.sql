CREATE PROCEDURE [dbo].[sp_delete_brand]
	@brandId char (14)
	
AS
BEGIN
	DELETE FROM tb_brand
		  WHERE brand_id = @brandId

END