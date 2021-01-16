CREATE PROCEDURE [dbo].[sp_insert_review]
	@userId NVARCHAR (50),
	@reviewDescr NVARCHAR (2000),
	@autoId Char (14)
AS
BEGIN
	INSERT INTO tb_review
	(
		auto_id
		,[user_id]
		,review_date
		,review_descr
	)
	VALUES
	(
		@autoId
		,@userId
		,GETDATE()
		,@reviewDescr
	)
END