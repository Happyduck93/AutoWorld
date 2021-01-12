CREATE FUNCTION [dbo].[fn_get_brand_id](@establishment Datetime)

RETURNS char(14)
AS
BEGIN
	DECLARE @idsuffix int;
	        --use built in function to count number of rows
	 SELECT @idsuffix = count(*)
	   FROM tb_brand
	        --Where formatted dates match
	  WHERE FORMAT(founded_date, 'yyyyMMdd') = FORMAT(@establishment, 'yyyyMMdd')

	     IF @idsuffix > 0
	        SELECT @idsuffix = SUBSTRING(MAX(brand_id), 13 ,2)	
			  FROM tb_brand
		     where FORMAT(founded_date, 'yyyyMMdd') = FORMAT(@establishment, 'yyyyMMdd')

	   ELSE 
			SELECT @idsuffix = 0

 	 RETURN FORMAT(@establishment, 'yyyyMMddHHmm') + format(@idsuffix +1, '0#' )
END
