Create DATABASE [WTO_DB]
GO
USE [WTO_DB]
GO
/****** Object:  Table [dbo].[Classifications]    Script Date: 30/04/2020 05:10:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classifications](
	[code] [nvarchar](50) NOT NULL,
	[name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Classifications] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Economic_groups]    Script Date: 30/04/2020 05:10:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Economic_groups](
	[code] [nvarchar](255) NULL,
	[name] [nvarchar](255) NULL,
	[displayOrder] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Frequencies]    Script Date: 30/04/2020 05:10:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Frequencies](
	[code] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Geographical_regions]    Script Date: 30/04/2020 05:10:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Geographical_regions](
	[code] [nvarchar](50) NULL,
	[name] [nvarchar](100) NULL,
	[displayOrder] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Indicator_categories]    Script Date: 30/04/2020 05:10:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Indicator_categories](
	[code] [nvarchar](50) NULL,
	[name] [nvarchar](100) NULL,
	[parentCode] [varchar](100) NOT NULL,
	[sortOrder] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partner_economies]    Script Date: 30/04/2020 05:10:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partner_economies](
	[code] [nvarchar](255) NULL,
	[iso3A] [nvarchar](255) NULL,
	[name] [nvarchar](255) NULL,
	[displayOrder] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Periods]    Script Date: 30/04/2020 05:10:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Periods](
	[code] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[description] [nvarchar](50) NULL,
	[frequencyCode] [nvarchar](50) NULL,
	[displayOrder] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products_sectors]    Script Date: 30/04/2020 05:10:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products_sectors](
	[code] [nvarchar](50) NULL,
	[name] [nvarchar](255) NULL,
	[note] [nvarchar](255) NULL,
	[productClassification] [nvarchar](255) NULL,
	[codeUnique] [nvarchar](255) NULL,
	[displayOrder] [int] NULL,
	[hierarchy] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reporting_economies]    Script Date: 30/04/2020 05:10:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reporting_economies](
	[code] [nvarchar](255) NULL,
	[iso3A] [nvarchar](255) NULL,
	[name] [nvarchar](255) NULL,
	[displayOrder] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TADF_Enquiry_points]    Script Date: 30/04/2020 05:10:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TADF_Enquiry_points](
	[id] [nvarchar](50) NULL,
	[title] [nvarchar](max) NULL,
	[description] [nvarchar](max) NOT NULL,
	[email] [nvarchar](255) NULL,
	[telephone] [nvarchar](255) NULL,
	[fax] [nvarchar](255) NULL,
	[websites] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TADF_import_export_and_transit_procedures]    Script Date: 30/04/2020 05:10:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TADF_import_export_and_transit_procedures](
	[id] [nvarchar](50) NULL,
	[title] [nvarchar](max) NULL,
	[description] [nvarchar](max) NOT NULL,
	[email] [nvarchar](255) NULL,
	[telephone] [nvarchar](255) NULL,
	[fax] [nvarchar](255) NULL,
	[websites] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TADFCountryName]    Script Date: 30/04/2020 05:10:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TADFCountryName](
	[name] [nvarchar](255) NULL,
	[id] [nvarchar](50) NULL,
	[single_window] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topics]    Script Date: 30/04/2020 05:10:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topics](
	[ID] [int] NULL,
	[name] [nvarchar](255) NULL,
	[sortOrder] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Units]    Script Date: 30/04/2020 05:10:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Units](
	[code] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Value_flags]    Script Date: 30/04/2020 05:10:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Value_flags](
	[code] [nvarchar](255) NULL,
	[description] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WTOIndicators]    Script Date: 30/04/2020 05:10:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WTOIndicators](
	[code] [nvarchar](255) NULL,
	[name] [nvarchar](255) NULL,
	[categoryCode] [nvarchar](255) NULL,
	[categoryLabel] [nvarchar](255) NULL,
	[subcategoryCode] [nvarchar](255) NULL,
	[subcategoryLabel] [nvarchar](255) NULL,
	[unitCode] [nvarchar](255) NULL,
	[unitLabel] [nvarchar](255) NULL,
	[startYear] [int] NULL,
	[endYear] [int] NULL,
	[frequencyCode] [nvarchar](255) NULL,
	[frequencyLabel] [nvarchar](255) NULL,
	[numberReporters] [int] NULL,
	[numberPartners] [int] NULL,
	[productSectorClassificationCode] [nvarchar](255) NULL,
	[productSectorClassificationLabel] [nvarchar](255) NULL,
	[hasMetadata] [nvarchar](255) NULL,
	[numberDecimals] [int] NULL,
	[numberDatapoints] [int] NULL,
	[updateFrequency] [nvarchar](255) NULL,
	[description] [nvarchar](255) NULL,
	[sortOrder] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WTOTimeseries_datapoints]    Script Date: 30/04/2020 05:10:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WTOTimeseries_datapoints](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[indicatorCategoryCode] [nvarchar](255) NULL,
	[indicatorCategory] [nvarchar](255) NULL,
	[indicatorCode] [nvarchar](255) NULL,
	[indicator] [nvarchar](255) NULL,
	[reportingEconomyCode] [nvarchar](255) NULL,
	[reportingEconomy] [nvarchar](255) NULL,
	[partnerEconomyCode] [nvarchar](255) NULL,
	[partnerEconomy] [nvarchar](255) NULL,
	[productOrSectorClassificationCode] [nvarchar](255) NULL,
	[productOrSectorClassification] [nvarchar](255) NULL,
	[productOrSectorCode] [nvarchar](255) NULL,
	[productOrSector] [nvarchar](255) NULL,
	[periodCode] [nvarchar](255) NULL,
	[period] [nvarchar](255) NULL,
	[frequencyCode] [nvarchar](255) NULL,
	[frequency] [nvarchar](255) NULL,
	[unitCode] [nvarchar](255) NULL,
	[unit] [nvarchar](255) NULL,
	[year] [int] NULL,
	[valueFlagCode] [nvarchar](255) NULL,
	[valueFlag] [nvarchar](255) NULL,
	[textValue] [nvarchar](255) NULL,
	[value] [float] NULL,
	[DateKey]  AS (concat(CONVERT([nvarchar],datepart(year,getdate())),case when len(CONVERT([nvarchar],datepart(month,getdate())))=(1) then '0'+CONVERT([nvarchar],datepart(month,getdate())) else CONVERT([nvarchar],datepart(month,getdate())) end,case when len(CONVERT([nvarchar],datepart(day,getdate())))=(1) then '0'+CONVERT([nvarchar],datepart(day,getdate())) else CONVERT([nvarchar],datepart(day,getdate())) end)),
 CONSTRAINT [PK_WTOTimeseries_datapoints] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Years]    Script Date: 30/04/2020 05:10:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Years](
	[Years] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[WTO_SP_DataAccess]    Script Date: 30/04/2020 05:10:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[WTO_SP_DataAccess]
	-- Add the parameters for the stored procedure here
@categoryCode	nvarchar(255) = null ,
@categoryLabel	nvarchar(255) = null ,
@code	nvarchar(255) = null ,
@codeUnique	nvarchar(255) = null ,
@description	nvarchar(4000) = null ,
@displayOrder	int = null ,
@email	nvarchar(255) = null ,
@endYear	int = null ,
@fax	nvarchar(255) = null ,
@frequency	nvarchar(255) = null ,
@frequencyCode	nvarchar(255) = null ,
@frequencyLabel	nvarchar(255) = null ,
@hasMetadata	nvarchar(255) = null ,
@hierarchy	nvarchar(255) = null ,
@ID	int = null ,
@indicator	nvarchar(255) = null ,
@indicatorCategory	nvarchar(255) = null ,
@indicatorCategoryCode	nvarchar(255) = null ,
@indicatorCode	nvarchar(255) = null ,
@iso3A	nvarchar(255)= null ,
@name	nvarchar(255)= null ,
@note	nvarchar(255)= null ,
@numberDatapoints	int = null ,
@numberDecimals	int = null ,
@numberPartners	int = null ,
@numberReporters	int = null ,
@parentCode	varchar(255) = null ,
@partnerEconomy	nvarchar(255)= null ,
@partnerEconomyCode	nvarchar(255)= null ,
@period	nvarchar(255)= null ,
@periodCode	nvarchar(255)= null ,
@productClassification	nvarchar(255)= null ,
@productOrSector	nvarchar(255)= null ,
@productOrSectorClassification	nvarchar(255)= null ,
@productOrSectorClassificationCode	nvarchar(255)= null ,
@productOrSectorCode	nvarchar(255)= null ,
@productSectorClassificationCode	nvarchar(255)= null ,
@productSectorClassificationLabel	nvarchar(255)= null ,
@reportingEconomy	nvarchar(255)= null ,
@reportingEconomyCode	nvarchar(255)= null ,
@single_window	nvarchar(4000)= null ,
@sortOrder	int = null ,
@startYear	int = null ,
@subcategoryCode	nvarchar(255)= null ,
@subcategoryLabel	nvarchar(255)= null ,
@telephone	nvarchar(255)= null ,
@textValue	nvarchar(255)= null ,
@title	nvarchar(4000)= null ,
@unit	nvarchar(255)= null ,
@unitCode	nvarchar(255)= null ,
@unitLabel	nvarchar(255)= null ,
@updateFrequency	nvarchar(255)= null ,
@value	float = null ,
@valueFlag	nvarchar(255)= null ,
@valueFlagCode	nvarchar(255)= null ,
@websites	nvarchar(500)= null ,
@year	int = null ,
@TableName nvarchar(255)= null 
AS
BEGIN

if @TableName='WTOTimeseries_datapoints'
BEGIN
if NOT EXISTS  (select 1 from INFORMATION_SCHEMA.TABLES where TABLE_NAME='WTOTimeseries_datapoints')
BEGIN
CREATE TABLE [dbo].[WTOTimeseries_datapoints](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[indicatorCategoryCode] [nvarchar](255) NULL,
	[indicatorCategory] [nvarchar](255) NULL,
	[indicatorCode] [nvarchar](255) NULL,
	[indicator] [nvarchar](255) NULL,
	[reportingEconomyCode] [nvarchar](255) NULL,
	[reportingEconomy] [nvarchar](255) NULL,
	[partnerEconomyCode] [nvarchar](255) NULL,
	[partnerEconomy] [nvarchar](255) NULL,
	[productOrSectorClassificationCode] [nvarchar](255) NULL,
	[productOrSectorClassification] [nvarchar](255) NULL,
	[productOrSectorCode] [nvarchar](255) NULL,
	[productOrSector] [nvarchar](255) NULL,
	[periodCode] [nvarchar](255) NULL,
	[period] [nvarchar](255) NULL,
	[frequencyCode] [nvarchar](255) NULL,
	[frequency] [nvarchar](255) NULL,
	[unitCode] [nvarchar](255) NULL,
	[unit] [nvarchar](255) NULL,
	[year] [int] NULL,
	[valueFlagCode] [nvarchar](255) NULL,
	[valueFlag] [nvarchar](255) NULL,
	[textValue] [nvarchar](255) NULL,
	[value] [float] NULL,
	[DateKey]  AS (concat(CONVERT([nvarchar],datepart(year,getdate())),case when len(CONVERT([nvarchar],datepart(month,getdate())))=(1) then '0'+CONVERT([nvarchar],datepart(month,getdate())) else CONVERT([nvarchar],datepart(month,getdate())) end,case when len(CONVERT([nvarchar],datepart(day,getdate())))=(1) then '0'+CONVERT([nvarchar],datepart(day,getdate())) else CONVERT([nvarchar],datepart(day,getdate())) end)),
 CONSTRAINT [PK_WTOTimeseries_datapoints] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

insert into WTOTimeseries_datapoints values(@indicatorCategoryCode,
                     @indicatorCategory,
                    @indicatorCode,
                    @indicator,
                    @reportingEconomyCode,
                    @reportingEconomy,
                    @partnerEconomyCode,
                    @partnerEconomy,
                    @productOrSectorClassificationCode,
                    @productOrSectorClassification,
                    @productOrSectorCode,
                    @productOrSector,
                    @periodCode,
                    @period,
                    @frequencyCode,
                    @frequency,
                    @unitCode,
                    @unit,
                    @year,
                    @valueFlagCode,
                    @valueFlag,
                    @textValue,
                    @value)
END

if @TableName='Classifications'
BEGIN
if NOT EXISTS  (select 1 from INFORMATION_SCHEMA.TABLES where TABLE_NAME='Classifications')
BEGIN
CREATE TABLE [dbo].[Classifications](
	[code] [nvarchar](50) NOT NULL,
	[name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Classifications] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

END

MERGE Classifications AS TARGET
USING (Select @code as code ,@name as name ) AS SOURCE 
ON (TARGET.code = SOURCE.code and TARGET.name=SOURCE.name) 
WHEN NOT MATCHED
THEN INSERT (code, name) VALUES (SOURCE.code, SOURCE.name);
END
GO
