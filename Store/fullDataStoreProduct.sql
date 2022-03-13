USE [Mall]
GO

/****** Object:  StoredProcedure [dbo].[sp_full_data_store_procedure]    Script Date: 3/13/2022 10:21:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_full_data_store_procedure] 
 AS
BEGIN
    SELECT 
        ean,
        name,
		description
    FROM StoreProducts
END;
GO

