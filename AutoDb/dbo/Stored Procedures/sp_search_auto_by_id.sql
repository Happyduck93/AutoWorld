CREATE PROCEDURE [dbo].[sp_search_auto_by_id]
	@autoId char (14) 

AS
BEGIN
	SELECT
		auto_id       AS AutoId
		,auto_name    AS AutoName
		,auto_descr   AS AutoDescr
		,A.brand_id   AS BrandId
		,[trim]       AS [Trim]
		,color        AS Color
		,price        AS price
		,[year]       AS [Year]
		,released	  AS Released
		,auto_type    AS AutoType
		,brand_name   AS BrandName
		,C.code_descr AS AutoTypeName
	FROM tb_auto A
	JOIN tb_brand B
      ON A.brand_id = B.brand_id
	JOIN tb_code C
	  ON C.category_id = 'AutoType'
   Where A.auto_id = @autoId

END