CREATE PROCEDURE [dbo].[sp_search_category_by_id]
	@categoryId varchar(50)
AS
BEGIN
	SELECT
		   category_id			as CategoryId
		   ,category_descr		as CategoryDescr
		   ,active_yn			as ActiveYn
		   ,abbr_cd				as AbbrCd
		   ,create_dt			as CreateDt
	  FROM tb_category
	 WHERE category_id = @categoryId
	 --if expression is null return replacement value.
	-- WHERE category_id = ISNULL (@categoryId, category_id)
END