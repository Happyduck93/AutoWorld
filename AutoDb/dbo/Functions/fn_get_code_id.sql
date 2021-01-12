CREATE FUNCTION [dbo].[fn_get_code_id]
(
	@categoryId varchar (50)
)
RETURNS char (5)
AS
BEGIN
	DECLARE @abbrDescr char(3);
	DECLARE @codeSeq char(2);

	SELECT @abbrDescr = abbr_cd
	  FROM tb_category
	 WHERE category_id = @categoryId

	SELECT @codeSeq = FORMAT(ISNULL(MAX(SUBSTRING(code_id, 4, 2)),0)+ 1, '0#')
	  FROM tb_code
     WHERE code_id LIKE @abbrDescr + '%'
	   AND SUBSTRING(code_id, 4, 2) < 90
	RETURN @abbrDescr + @codeSeq
END
