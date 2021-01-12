CREATE PROCEDURE [dbo].[sp_delete_category]
	@categoryId varchar (50)
AS
BEGIN
	DELETE FROM tb_category
		  WHERE category_id = @categoryId
END

