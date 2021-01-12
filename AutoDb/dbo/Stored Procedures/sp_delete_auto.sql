CREATE PROCEDURE [dbo].[sp_delete_auto]
	@autoId char(14)
AS
BEGIN
	DELETE FROM tb_auto
	      WHERE auto_id = @autoId
END