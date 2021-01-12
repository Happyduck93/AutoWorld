CREATE PROCEDURE [dbo].[sp_search_code_by_category]
	@categoryId varchar(50)
AS
BEGIN
	SELECT 
		   code_id		as CodeId
		   ,code_descr  as CodeDescr
		   ,category_id as CategoryId
		   ,active_yn   as ActiveYn
		   ,create_dt	as CreateDt
	  FROM tb_code 
     WHERE category_id = @categoryId

END
