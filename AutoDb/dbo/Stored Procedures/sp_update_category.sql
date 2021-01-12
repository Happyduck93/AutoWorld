CREATE PROCEDURE [dbo].[sp_update_category]
	--variables to take input
	@categoryId varchar (50) output,
	@categoryDescr nvarchar (50),
	@abbrCd char (3),
	@activeYn bit
AS
BEGIN
	UPDATE tb_category
	   SET category_descr = @categoryDescr
		   ,abbr_cd = @abbrCd
		   ,active_yn = @activeYn
	 WHERE category_id = @categoryId
END