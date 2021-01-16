CREATE PROCEDURE [dbo].[sp_search_auto]

AS
BEGIN
	SELECT
		auto_id     AS AutoId
		,auto_name  AS AutoName
		,auto_descr AS AutoDescr
		,A.brand_id   AS BrandId
		,[trim]     AS [Trim]
		,color      AS Color
		,price      AS price
		,[year]     AS [Year]
		,A.released	AS Released
		,c.code_descr  AS AutoType
		,brand_name AS BrandName
	FROM tb_auto A
	JOIN tb_brand B
	  ON A.brand_id = B.brand_id
	JOIN tb_code C
	  ON A.auto_type = C.code_id
   WHERE C.category_id = 'AutoType'
END