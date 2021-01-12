CREATE PROCEDURE [dbo].[sp_search_auto]

AS
BEGIN
	SELECT
		auto_id     AS AutoId
		,auto_name  AS AutoName
		,auto_descr AS AutoDescr
		,brand_id   AS BrandId
		,[trim]     AS [Trim]
		,color      AS Color
		,price      AS price
		,[year]     AS [Year]
		,released	AS Released
		,auto_type  AS AutoType
	FROM tb_auto
END