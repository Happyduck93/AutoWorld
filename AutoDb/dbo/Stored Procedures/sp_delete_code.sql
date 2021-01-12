CREATE PROCEDURE [dbo].[sp_delete_code]
	@codeId char(5),
	@categoryId varchar (50)
AS
BEGIN
	DELETE FROM tb_code
	      WHERE code_id     = @codeId
			AND category_id = @categoryId
END
