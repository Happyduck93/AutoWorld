CREATE PROCEDURE [dbo].[sp_search_code]
	
AS
BEGIN
	SELECT 
		   code_id		as CodeId
		   ,code_descr  as CodeDescr
		   ,category_id as CategoryId
		   ,active_yn   as ActiveYn
		   ,create_dt	as CreateDt
	  FROM tb_code 
    

END
