CREATE PROCEDURE [dbo].[sp_search_code_by_id]
	@categoryId varchar (50),
	@codeId char(5)
AS
BEGIN
		SELECT 
			   code_id		as CodeId
			   ,category_id as CategoryId
			   ,code_descr  as CodeDescr
			   ,active_yn   as ActiveYn
			   ,create_dt   as CreateDt
		  FROM tb_code
		 WHERE code_id      = @codeId
		   AND category_id  = @categoryId
END
