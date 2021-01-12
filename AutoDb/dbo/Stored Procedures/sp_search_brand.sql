CREATE PROCEDURE [dbo].[sp_search_brand]

AS
BEGIN
	SELECT
		-- set name same as model's property name 
		brand_id          as BrandId
		,brand_code_id    as BrandCodeId
		,brand_code_descr as BrandCodeDescr
		--,category_id      as CategoryId
		,brand_name       as BrandName
		,brand_descr      as BrandDescr
		,founded_date     as EstablishmentDate
		,headquarter      as Headquarters
	FROM tb_brand
END