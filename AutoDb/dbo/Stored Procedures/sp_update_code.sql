CREATE PROCEDURE [dbo].[sp_update_code]
	@codeId char(5) output,
	@categoryId varchar (50),
	@codeDescr nvarchar (50),
	@activeYn bit
AS
BEGIN
	UPDATE tb_code
	   SET code_descr  = @codeDescr,
		   active_yn   = @activeYn
	 WHERE code_id     = @codeId
	   AND category_id = @categoryId
END