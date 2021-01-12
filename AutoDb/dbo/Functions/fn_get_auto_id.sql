CREATE FUNCTION [dbo].[fn_get_auto_id]
(
	@released Datetime
)
RETURNS char(14)
AS
BEGIN
	DECLARE @idsuffix int;
		   -- built in function, count all	
	SELECT @idsuffix = count(*)
	FROM tb_auto
	WHERE FORMAT(released, 'yyyyMMdd') = FORMAT(@released, 'yyyyMMdd')
		   -- if there are some entries in the auto table
		IF @idsuffix >0
		    --select last two digits of max-id (latest id created on a specific day)
			SELECT @idsuffix = SUBSTRING(MAX(auto_id),13, 2)
			FROM tb_auto
			WHERE FORMAT(released, 'yyyyMMdd') = FORMAT (@released, 'yyyyMMdd')
			-- if this is a first entry
		ELSE
			SELECT @idsuffix = 0

	RETURN FORMAT(@released, 'yyyyMMddHHmm') + FORMAT(@idsuffix +1, '0#')
END
