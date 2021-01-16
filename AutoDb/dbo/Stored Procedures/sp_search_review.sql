CREATE PROCEDURE [dbo].[sp_search_review]
	@autoId CHAR (14)
AS
BEGIN
	SELECT 
			R.auto_id     AS AutoId
			,review_date  AS ReviewDate
			,review_descr AS ReviewDescr
			,[user_id]    AS UserId
			,A.auto_name  AS AutoName
			,C.code_descr AS AutoType
			,B.brand_name AS BrandName

	  

	  FROM tb_review R
	  JOIN tb_auto A
	    ON A.auto_id = R.auto_id
	  JOIN tb_code C
	    ON A.auto_type = C.code_id
	  JOIN tb_brand B
	    ON B.brand_id = A.brand_id
	 WHERE R.auto_id = @autoId
  
END