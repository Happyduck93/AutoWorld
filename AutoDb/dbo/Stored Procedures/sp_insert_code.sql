CREATE PROCEDURE [dbo].[sp_insert_code]
	@codeId char(5) output,
	@categoryId varchar (50),
	@codeDescr nvarchar (50)
AS
BEGIN
		 DECLARE @newId char (5) = dbo.fn_get_code_id (@categoryId);
	     INSERT INTO tb_code
		 VALUES(
					--should be same order as tb_code
					@newId
					,@categoryId
					,1
					,@codeDescr
					,GETDATE()
		 
		       )
		    SET @codeId = @newId 
END
