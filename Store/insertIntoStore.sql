USE [Mall]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_into_storeproducts]    Script Date: 3/13/2022 10:22:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insert_into_storeproducts] 
	@ean nvarchar(20),
	@name nvarchar(150),
	@description nvarchar(200)
AS
BEGIN
	DECLARE @Exists INT
	IF EXISTS(SELECT ean
                FROM storeproducts
                WHERE ean = @ean)
		BEGIN
             UPDATE storeproducts 
				SET name = @name, 
				    description	= @description
			  WHERE ean = @ean
		END
	ELSE
		BEGIN
			 INSERT INTO storeproducts
                        (ean,
                         name,
                         description)
            VALUES     ( @ean,
                         @name,
                         @description)
		END
END
GO

