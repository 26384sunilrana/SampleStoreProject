USE [Mall]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_into_product_cdn]    Script Date: 3/13/2022 10:22:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insert_into_product_cdn] 
	@ean nvarchar(20),
	@cdnUrl nvarchar(150),
	@latestUpdated nvarchar(20)
AS
BEGIN
	DECLARE @Exists INT
	IF EXISTS(SELECT ean
                FROM productCDNUrl
                WHERE ean = @ean)
		BEGIN
             UPDATE productCDNUrl 
				SET cdnUrl = @cdnUrl, 
				    latestUpdated	= @latestUpdated
			  WHERE ean = @ean
		END
	ELSE
		BEGIN
			 INSERT INTO productCDNUrl
                        (ean,
                         cdnUrl,
                         latestUpdated)
            VALUES     ( @ean,
                         @cdnUrl,
                         @latestUpdated)
		END
END
GO

