USE [Mall]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_custom_product_cdn_url]    Script Date: 3/13/2022 10:22:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_get_custom_product_cdn_url] 
	
AS
BEGIN
	SELECT sto.name, sto.ean, pro.cdnurl
	from [dbo].[StoreProducts] as sto
	inner join [dbo].[ProductCDNUrl] as pro
	on sto.ean = pro.ean
END
GO

