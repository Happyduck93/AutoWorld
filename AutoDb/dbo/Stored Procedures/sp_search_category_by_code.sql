CREATE PROCEDURE [dbo].[sp_search_category_by_code]
	@codeId char(5),
	@category nvarchar(50) output
AS
BEGIN
	SELECT 
		  category_id as CategoryId
	 FROM tb_code
	WHERE code_id = @codeId
END