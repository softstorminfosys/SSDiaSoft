USE [master]
GO
/****** Object:  Database [DiamondPro]    Script Date: 04/27/2017 00:02:15 ******/
CREATE DATABASE [DiamondPro] ON  PRIMARY 
( NAME = N'DiamondPro', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\DiamondPro.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DiamondPro_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\DiamondPro_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DiamondPro] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DiamondPro].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DiamondPro] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [DiamondPro] SET ANSI_NULLS OFF
GO
ALTER DATABASE [DiamondPro] SET ANSI_PADDING OFF
GO
ALTER DATABASE [DiamondPro] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [DiamondPro] SET ARITHABORT OFF
GO
ALTER DATABASE [DiamondPro] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [DiamondPro] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [DiamondPro] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [DiamondPro] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [DiamondPro] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [DiamondPro] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [DiamondPro] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [DiamondPro] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [DiamondPro] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [DiamondPro] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [DiamondPro] SET  DISABLE_BROKER
GO
ALTER DATABASE [DiamondPro] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [DiamondPro] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [DiamondPro] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [DiamondPro] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [DiamondPro] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [DiamondPro] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [DiamondPro] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [DiamondPro] SET  READ_WRITE
GO
ALTER DATABASE [DiamondPro] SET RECOVERY SIMPLE
GO
ALTER DATABASE [DiamondPro] SET  MULTI_USER
GO
ALTER DATABASE [DiamondPro] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [DiamondPro] SET DB_CHAINING OFF
GO
USE [DiamondPro]
GO
/****** Object:  User [ssi]    Script Date: 04/27/2017 00:02:15 ******/
CREATE USER [ssi] FOR LOGIN [ssi] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[MST_Dalal]    Script Date: 04/27/2017 00:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MST_Dalal](
	[DalalId] [int] IDENTITY(1,1) NOT NULL,
	[PartyId] [int] NOT NULL,
	[DalalType] [varchar](50) NOT NULL,
	[DalalName] [varchar](200) NOT NULL,
	[Mobile] [varchar](10) NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MST_Dalal] PRIMARY KEY CLUSTERED 
(
	[DalalId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[Karkhana_IssueReturn_GetDataForGrid]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Karkhana_IssueReturn_GetDataForGrid]
	@SearchParam VARCHAR(MAX) = ''
AS
BEGIN

DECLARE @SqlString VARCHAR(MAX)

SET @SqlString = '
	SELECT 
	KIR.Id,
	KarkhanaId,
	KarkhanaName AS [KARKHANA NAME],
	IssueDate AS [ISSUE DATE],
	Returndate AS [REURN DATE],
	NotNo AS [NOT NO],
	KatNo AS [KAT NO],
	KharidiDate AS [KHARIDI DATE],
	Vajan AS [VAJAN],
	Rate AS [RATE],
	Amount AS [AMOUNT],
	BanvaChadeluCts AS [BANAVA CHADELU],
	VajanLoss AS [VAJAN LOSS],
	VajanGhatt AS [VAJAN GHATT],
	PalsuVajan AS [PALSU VAJAN],
	PalsuRate AS [PALSU RATE],
	PalsuAmount AS [PALSU AMOUNT],
	ChokiVajan AS [CHOKI VAJAN],
	ChokiRate AS [CHOKI RATE],
	ChokiAmount AS [CHOKI AMOUNT],
	DblVajan AS [DOUBLE VAJAN],
	DblRate AS [DOUBLE RATE],
	DblAmount AS [DOUBLE AMOUNT],
	PCDAmount AS [PCD AMOUNT],
	Than AS THAN,
	ThanTotal AS [THAN TOTAL],
	TaiyarVajan AS [TAIYAR VAJAN],
	TaiyarPadatar AS [TAIYAR PADATAR],
	CommPadatar AS [COMISSION PADATAR],
	FinalPadatar AS [FINAL PADATAR],
	STaka AS [S-TAKA],
	RafTaka AS [RAF TAKA],
	[Status] AS STATUS
	FROM dbo.TRN_Karkhana_IssueReturn KIR
	LEFT JOIN dbo.MST_Karkhana_Master ON MST_Karkhana_Master.Id = KIR.KarkhanaId
'

IF @SearchParam <> ''
BEGIN
    EXEC(@SqlString + ' WHERE ' + @SearchParam)
END
ELSE
BEGIN
    EXEC(@SqlString)
END

END
GO
/****** Object:  StoredProcedure [dbo].[Get_NotNo_For_Search]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Get_NotNo_For_Search]
	@SearchParam varchar(MAX)='',
	@IsKharidi int = 0
AS
begin
	declare @SqlString varchar(MAX)
	if	@IsKharidi = 1
	begin
		set @SqlString = '
		select NotNo,KatNo,KharidiDate,PaymentDate,Cts,Rate,FinalTotal 
		from MST_Kharidi With(Nolock)
		'
	end
	else
	begin
	set @SqlString = '
		select NotNo,KatNo,KharidiDate,PaymentDate,Cts,Rate,FinalTotal 
		from MST_Polish_Kharidi with(nolock)
		'
	end
	
	if	@SearchParam <> ''
	begin
		EXEC(@SqlString + ' WHERE ' + @SearchParam)
	end
	else
	begin
		EXEC(@SqlString)
	end
end
GO
/****** Object:  StoredProcedure [dbo].[MST_Dalal_GetDataForGrid]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MST_Dalal_GetDataForGrid]
	@SearchParam VARCHAR(MAX) = ''
AS
BEGIN

DECLARE @SqlString VARCHAR(MAX)

SET @SqlString = '
    SELECT DalalId,
			dbo.MST_Dalal.PartyId,
			PartyName AS [PARTY NAME],
			DalalType AS [DALAL TYPE],
			DalalName AS [DALAL NAME],
			dbo.MST_Dalal.Mobile AS [MOBILE],
			dbo.MST_Dalal.Address AS  [ADDRESS],
			dbo.MST_Dalal.Active AS ACTIVE
    FROM dbo.MST_Dalal WITH(NOLOCK)
    LEFT JOIN dbo.MST_Party WITH(NOLOCK) ON dbo.MST_Party.PartyId = MST_Dalal.PartyId
    '
    
  IF @SearchParam <> ''
  BEGIN
      EXEC(@SqlString + ' WHERE ' + @SearchParam)
  END	  
  ELSE	
  BEGIN
      EXEC(@SqlString)
  END
END
GO
/****** Object:  Table [dbo].[MST_Kharidi]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MST_Kharidi](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NotNo] [varchar](50) NOT NULL,
	[KatNo] [varchar](50) NOT NULL,
	[KharidiDate] [datetime] NOT NULL,
	[PaymentTerm] [int] NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[PartyId] [int] NOT NULL,
	[BrokerId] [int] NOT NULL,
	[Cts] [float] NOT NULL,
	[Rate] [float] NOT NULL,
	[RafPercentage] [float] NOT NULL,
	[BasicTotal] [float] NOT NULL,
	[AngadiyaKharchPer] [float] NOT NULL,
	[AngadiyaKharch] [float] NOT NULL,
	[FinalTotal] [float] NOT NULL,
	[PaymentStatus] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MST_Kharidi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MST_Karkhana_Master]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MST_Karkhana_Master](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KarkhanaName] [varchar](50) NOT NULL,
	[Owner] [varchar](50) NOT NULL,
	[Mobile] [varchar](10) NOT NULL,
	[Address] [varchar](5000) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MST_Karkhana_Master] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[MST_Karkhana_GetDataForGrid]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MST_Karkhana_GetDataForGrid]
	@SearchParam varchar(MAX) = ''
As
begin

declare @SqlString varchar(MAX)

set @SqlString = '
	select Id,
		KarkhanaName AS [KARKHANA NAME],
		[Owner] AS [OWNER],
		Mobile AS [MOBILE],
		[Address] AS [ADDRESS],
		Active AS ACTIVE   
	from MST_Karkhana_Master with(nolock) 
	'
	
	if	@SearchParam <> ''
	begin
		EXEC(@SqlString + ' WHERE ' + @SearchParam)
	end
	else
	begin
		EXEC(@SqlString)
	end
end
GO
/****** Object:  StoredProcedure [dbo].[MST_Kharidi_GetDataForGrid]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MST_Kharidi_GetDataForGrid]
	@SearchParam VARCHAR(MAX) = ''
AS
BEGIN
DECLARE @SqlString VARCHAR(MAX)

SET @SqlString = '
SELECT ID,
	   NotNo AS [NOT NO],
	   KatNo AS [KAT NO],
	   KharidiDate AS [KHARIDI DATE],
	   PaymentTerm AS [PAYMENT TERM],
	   PaymentDate AS [PAYMENT DATE],
	   MST_Kharidi.PartyId,
	   PartyName AS [PARTY NAME],
	   BrokerId,
	   DalalName AS [DALAL NAME],
	   Cts AS CTS,
	   Rate AS RATE,
	   RafPercentage AS PERCENTAGE,
	   BasicTotal AS [BASIC TOTAL],
	   AngadiyaKharchPer AS [ANGADIYA PER],
	   AngadiyaKharch AS [ANGADIYA AMT],
	   FinalTotal AS [FINAL TOTAL] 
FROM MST_Kharidi WITH(NOLOCK)
LEFT JOIN MST_Party with(nolock) on MST_Kharidi.PartyId = MST_Party.PartyId
LEFt JOIN MST_Dalal With(Nolock) on MST_Kharidi.BrokerId = MST_Dalal.DalalId
'

IF	@SearchParam <> ''
BEGIN	
	EXEC(@SqlString + ' WHERE ' + @SearchParam)
END
ELSE	
BEGIN
    EXEC(@SqlString)
END


END
GO
/****** Object:  StoredProcedure [dbo].[MST_ParameterType_GetDataForGrid]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MST_ParameterType_GetDataForGrid]
	@SearchParam varchar(MAX) = ''
AS
begin
	declare @SqlString varchar(MAX)
	
	set @SqlString = '
		SELECT ParameterTypeId,ParameterType [PARAMETER TYPE],Remark AS [REMARK],Active AS [ACTIVE]
		FROM MST_Parameter_Type with(nolock)
	'
	
	if	@SearchParam <> ''
	begin
		EXEC(@SqlString + ' WHERE ' + @SearchParam)
	end
	else
	begin
		EXEC(@SqlString)
	end
end
GO
/****** Object:  Table [dbo].[MST_Parameter_Type]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MST_Parameter_Type](
	[ParameterTypeId] [int] IDENTITY(1,1) NOT NULL,
	[ParameterType] [varchar](50) NOT NULL,
	[Remark] [varchar](500) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MST_Parameter_Type] PRIMARY KEY CLUSTERED 
(
	[ParameterTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[MST_ParameterValue_GetDataForGrid]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[MST_ParameterValue_GetDataForGrid]
	@SearchParam varchar(MAX) = ''
AS
begin
	declare @SqlString varchar(MAX)
	
	set @SqlString = '
		SELECT ParaValueId,
				ParaTypeId,
				ParameterType [PARAMETER TYPE],
				ParaCode AS [PARAMETER CODE],
				ParaValue AS [PARAMETER VALUE],
				Remark AS [REMARK],
				Active AS [ACTIVE]
		FROM MST_ParameterValue with(nolock)
		LEFT JOIN MST_Parameter_Type with(nolock) on MST_ParameterValue.ParaTypeId = MST_Parameter_Type.ParameterTypeId
	'
	
	if	@SearchParam <> ''
	begin
		EXEC(@SqlString + ' WHERE ' + @SearchParam)
	end
	else
	begin
		EXEC(@SqlString)
	end
end
GO
/****** Object:  Table [dbo].[MST_ParameterValue]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MST_ParameterValue](
	[ParaValueId] [int] IDENTITY(1,1) NOT NULL,
	[ParaTypeId] [int] NOT NULL,
	[ParaCode] [varchar](50) NOT NULL,
	[ParaValue] [varchar](50) NOT NULL,
	[Remark] [varchar](5000) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MST_ParameterValue] PRIMARY KEY CLUSTERED 
(
	[ParaValueId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MST_Party]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MST_Party](
	[PartyId] [int] IDENTITY(1,1) NOT NULL,
	[PartyType] [varchar](50) NOT NULL,
	[PartyName] [varchar](500) NOT NULL,
	[Mobile] [varchar](10) NOT NULL,
	[Address] [varchar](5000) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MST_Party] PRIMARY KEY CLUSTERED 
(
	[PartyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MST_Polish_Kharidi]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MST_Polish_Kharidi](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NotNo] [varchar](50) NOT NULL,
	[KatNo] [varchar](50) NOT NULL,
	[KharidiDate] [datetime] NOT NULL,
	[PaymentTerm] [int] NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[PartyId] [int] NOT NULL,
	[BrokerId] [int] NOT NULL,
	[Cts] [float] NOT NULL,
	[Rate] [float] NOT NULL,
	[RafPercentage] [float] NOT NULL,
	[BasicTotal] [float] NOT NULL,
	[AngadiyaKharchPer] [float] NOT NULL,
	[AngadiyaKharch] [float] NOT NULL,
	[FinalTotal] [float] NOT NULL,
	[PaymentStatus] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MST_Polish_Kharidi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[MST_Party_GetDataForGrid]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MST_Party_GetDataForGrid]
	@SearchParam VARCHAR(MAX) = ' Active = 1'
AS
BEGIN

DECLARE @SqlString VARCHAR(MAX)

SET @SqlString = '
    SELECT PartyId,
			PartyType AS [PARTY TYPE],
			PartyName AS [PARTY NAME],
			Mobile AS [MOBILE],
			Address AS  [ADDRESS],
			Active AS ACTIVE
    FROM dbo.MST_Party WITH(NOLOCK)
    '
    
  IF @SearchParam <> ''
  BEGIN
      EXEC(@SqlString + ' WHERE ' + @SearchParam)
  END	  
  ELSE	
  BEGIN
      EXEC(@SqlString)
  END
END
GO
/****** Object:  StoredProcedure [dbo].[MST_Polish_Kharidi_GetDataForGrid]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MST_Polish_Kharidi_GetDataForGrid]
	@SearchParam VARCHAR(MAX) = ''
AS
BEGIN
DECLARE @SqlString VARCHAR(MAX)

SET @SqlString = '
SELECT ID,
	   NotNo AS [NOT NO],
	   KatNo AS [KAT NO],
	   KharidiDate AS [KHARIDI DATE],
	   PaymentTerm AS [PAYMENT TERM],
	   PaymentDate AS [PAYMENT DATE],
	   MST_Polish_Kharidi.PartyId,
	   PartyName AS [PARTY NAME],
	   BrokerId,
	   DalalName AS [DALAL NAME],
	   Cts AS CTS,
	   Rate AS RATE,
	   RafPercentage AS PERCENTAGE,
	   BasicTotal AS [BASIC TOTAL],
	   AngadiyaKharchPer AS [ANGADIYA PER],
	   AngadiyaKharch AS [ANGADIYA AMT],
	   FinalTotal AS [FINAL TOTAL] 
FROM MST_Polish_Kharidi WITH(NOLOCK)
LEFT JOIN MST_Party with(nolock) on MST_Polish_Kharidi.PartyId = MST_Party.PartyId
LEFt JOIN MST_Dalal With(Nolock) on MST_Polish_Kharidi.BrokerId = MST_Dalal.DalalId

'

IF	@SearchParam <> ''
BEGIN	
	EXEC(@SqlString + ' WHERE ' + @SearchParam)
END
ELSE	
BEGIN
    EXEC(@SqlString)
END


END
GO
/****** Object:  Table [dbo].[TRN_Payment_Detail]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRN_Payment_Detail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionId] [varchar](50) NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[PaymentType] [varchar](50) NOT NULL,
	[PartyId] [int] NOT NULL,
	[NotNo] [varchar](50) NOT NULL,
	[KatNo] [varchar](50) NOT NULL,
	[KharidiDate] [datetime] NOT NULL,
	[vajan] [float] NOT NULL,
	[Rate] [float] NOT NULL,
	[Amount] [float] NOT NULL,
	[PaidAmount] [float] NOT NULL,
	[DueAmount] [float] NOT NULL,
 CONSTRAINT [PK_TRN_Payment_Detail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRN_Kat_Master]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRN_Kat_Master](
	[TransId] [int] NOT NULL,
	[PartyId] [int] NOT NULL,
	[KatNo] [varchar](50) NOT NULL,
	[NotNo] [int] NOT NULL,
	[BoxNo] [varchar](50) NOT NULL,
	[Carat] [float] NOT NULL,
	[Rate] [float] NOT NULL,
	[Amount] [float] NOT NULL,
 CONSTRAINT [PK_TRN_Kat_Master] PRIMARY KEY CLUSTERED 
(
	[TransId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRN_Karkhana_IssueReturn]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRN_Karkhana_IssueReturn](
	[Id] [int] NOT NULL,
	[KarkhanaId] [int] NOT NULL,
	[IssueDate] [datetime] NOT NULL,
	[Returndate] [datetime] NOT NULL,
	[NotNo] [varchar](50) NOT NULL,
	[KatNo] [varchar](50) NOT NULL,
	[KharidiDate] [datetime] NOT NULL,
	[Vajan] [float] NOT NULL,
	[Rate] [float] NOT NULL,
	[Amount] [float] NOT NULL,
	[BanvaChadeluCts] [float] NOT NULL,
	[VajanLoss] [float] NOT NULL,
	[VajanGhatt] [float] NOT NULL,
	[PalsuVajan] [float] NOT NULL,
	[PalsuRate] [float] NOT NULL,
	[PalsuAmount] [float] NOT NULL,
	[ChokiVajan] [float] NOT NULL,
	[ChokiRate] [float] NOT NULL,
	[ChokiAmount] [float] NOT NULL,
	[DblVajan] [float] NOT NULL,
	[DblRate] [float] NOT NULL,
	[DblAmount] [float] NOT NULL,
	[PCDAmount] [float] NOT NULL,
	[Than] [int] NOT NULL,
	[ThanTotal] [float] NOT NULL,
	[TaiyarVajan] [float] NOT NULL,
	[TaiyarPadatar] [float] NOT NULL,
	[CommPadatar] [float] NOT NULL,
	[FinalPadatar] [float] NOT NULL,
	[STaka] [float] NOT NULL,
	[RafTaka] [float] NOT NULL,
	[Status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TRN_Karkhana_Issue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[TRN_Box_GetDataForMerging]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[TRN_Box_GetDataForMerging]
	@SearchParam varchar(MAX) = ''
AS
begin

declare @SqlString varchar(MAX)

set @SqlString = '
	
	select * from (
	select NotNo,KatNo,TaiyarVajan AS Carat,TaiyarPadatar AS Rate,convert(Decimal(15,2), TaiyarVajan * TaiyarPadatar) AS Amount
	from TRN_Karkhana_IssueReturn 
	where ReturnDate Is not null and [status] = ''R''

	union all

	select NotNo,KatNo,Cts AS Carat,Rate,convert(Decimal(15,2), Cts * Rate) AS Amount
	from MST_Polish_Kharidi
	)VK
	'

	if @SearchParam <> ''
	begin
		EXEC(@SqlString + ' WHERE ' + @SearchParam)
	end
	else
	begin
		EXEC(@SqlString)
	end

end
GO
/****** Object:  Table [dbo].[Table_MaxId_Generate]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Table_MaxId_Generate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MAXID] [int] NOT NULL,
	[TABLE_NAME] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Table_MaxId_Generate] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[TRN_Payment_Detail_InsertUpdate]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[TRN_Payment_Detail_InsertUpdate]
	@Id int  = 0,
	@TransId varchar(50) = '',
	@PaymentType varchar(50) = '',
	@PartyId int =0 ,
	@PaymwntDate datetime,
	@KharidiDate datetime,
	@NotNo varchar(50) = '',
	@KatNo varchar(50) = '',
	@Cts float=0,
	@Rate float = 0,
	@Amount float = 0,
	@PaidAmount float = 0,
	@DueAmount float = 0,
	@IsPolish int = 0,
	@ReturnValue int =0 out
AS
begin
	
	begin transaction
	insert into dbo.TRN_Payment_Detail
	(	
		TransactionId,
		PaymentDate,
		PaymentType,
		PartyId,
		NotNo,
		KatNo,
		KharidiDate,
		vajan,
		Rate,
		Amount,
		PaidAmount,
		DueAmount

	) 
	values
	(
		@TransId,
		@PaymwntDate,
		@PaymentType,
		@PartyId,
		@NotNo,
		@KatNo,
		@KharidiDate,
		@Cts,
		@Rate,
		@Amount,
		@PaidAmount	,
		@DueAmount		
	)
	declare @PaymentStatus varchar(50)
	if @Amount <= @PaidAmount	
	begin
		set @PaymentStatus = 'COMPLETED'
	end
	else if	@PaidAmount > 0 and @Amount > @PaidAmount
	begin
		set @PaymentStatus = 'PARTIAL'
	end
	else
	begin
		set @PaymentStatus = 'PENDING'
	end
	
	if 	@IsPolish = 1
	begin
		update MST_Polish_Kharidi set PaymentStatus = @PaymentStatus where PartyId = @PartyId and NotNo = @NotNo and KatNo = @KatNo
	end	
	else	
	begin
		update MST_Kharidi set PaymentStatus = @PaymentStatus where PartyId = @PartyId and NotNo = @NotNo and KatNo = @KatNo
	end
		
	Commit Transaction
	
	if	@@Error = 0 
	begin
		set @ReturnValue = 1
	end
	else
	begin
		set @ReturnValue = 0
		Rollback Transaction 
	end

end
GO
/****** Object:  StoredProcedure [dbo].[MST_Polish_Kharidi_InsertUpdate]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MST_Polish_Kharidi_InsertUpdate]
	@Id INT = 0 ,
	@NotNo VARCHAR(50)='',
	@KatNo VARCHAR(50)='',
	@KharidiDate VARCHAR(15)='',
	@PaymentDate VARCHAR(15)='',
	@Term INT = 0,
	@PartyId INT =0,
	@BrokerId INT = 0,
	@Cts FLOAT = 0,
	@Rate FLOAT = 0,
	@RafPer FLOAT = 0,
	@BasicTotal FLOAT = 0,
	@AngadiyaPer FLOAT = 0,
	@AngadiyaKharch FLOAT = 0,
	@FinalTotal FLOAT = 0,
	@ReturnValue INT = 0 OUT
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM dbo.MST_Polish_Kharidi WITH(NOLOCK) WHERE ID = @Id)
	BEGIN
		INSERT INTO	dbo.MST_Polish_Kharidi
		        ( NotNo ,
		          KatNo ,
		          KharidiDate ,
		          PaymentTerm ,
		          PaymentDate ,
		          PartyId ,
		          BrokerId ,
		          Cts ,
		          Rate ,
		          RafPercentage ,
		          BasicTotal ,
		          AngadiyaKharchPer ,
		          AngadiyaKharch ,
		          FinalTotal
		        )
		VALUES  ( @NotNo , -- NotNo - varchar(50)
		          @KatNo , -- KatNo - varchar(50)
		          @KharidiDate , -- KharidiDate - datetime
		          @Term , -- PaymentTerm - int
		          @PaymentDate , -- PaymentDate - datetime
		          @PartyId , -- PartyId - int
		          @BrokerId , -- BrokerId - int
		          @Cts , -- Cts - float
		          @Rate , -- Rate - float
		          @RafPer , -- RafPercentage - float
		          @BasicTotal , -- BasicTotal - float
		          @AngadiyaPer , -- AngadiyaKharchPer - float
		          @AngadiyaKharch , -- AngadiyaKharch - float
		          @FinalTotal  -- FinalTotal - float
		        )
	END
	ELSE		
	BEGIN
		UPDATE dbo.MST_Polish_Kharidi SET
			NotNo = @NotNo,
			KatNo = @KatNo,
			KharidiDate = CONVERT(DATETIME,@KharidiDate),
			PaymentTerm = @Term,
			PaymentDate = CONVERT(DATETIME,@PaymentDate),
			PartyId = @PartyId,
			BrokerId = @BrokerId,
			Cts = @Cts,
			Rate = @Rate,
			RafPercentage = @RafPer,
			BasicTotal = @BasicTotal,
			AngadiyaKharchPer = @AngadiyaPer,
			AngadiyaKharch = @AngadiyaKharch,
			FinalTotal = @FinalTotal
		WHERE ID = @Id		
	END
	
	
	IF	@@ERROR = 0
	BEGIN
		SET @ReturnValue = 1	
	END
	ELSE	
	BEGIN
	    SET @ReturnValue = 0
	END
END
GO
/****** Object:  StoredProcedure [dbo].[MST_Polish_Kharidi_Delete]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MST_Polish_Kharidi_Delete]
	@Id INT =0,
	@ReturnValue INT = 0 OUT
AS 
BEGIN
   
    DELETE FROM dbo.MST_Polish_Kharidi WHERE ID = @Id
    
    IF NOT EXISTS(SELECT * FROM dbo.MST_Polish_Kharidi WITH(NOLOCK) WHERE ID = @Id)
    BEGIN
        SET @ReturnValue = 1
    END
    ELSE	
    BEGIN
        SET @ReturnValue = 0
    END
END
GO
/****** Object:  StoredProcedure [dbo].[MST_Party_Delete]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MST_Party_Delete]
	@Id INT =0,
	@ReturnValue INT = 0 OUT
AS 
BEGIN
   
    DELETE FROM dbo.MST_Party WHERE PartyId = @Id
    
    IF NOT EXISTS(SELECT 1 FROM dbo.MST_Party WITH(NOLOCK) WHERE PartyId = @Id)
    BEGIN
        SET @ReturnValue = 1
    END
    ELSE	
    BEGIN
        SET @ReturnValue = 0
    END
END
GO
/****** Object:  StoredProcedure [dbo].[MST_Party_InsertUpdate]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MST_Party_InsertUpdate]
	@Id INT = 0,
	@PartyName VARCHAR(200) = '',
	@Mobile VARCHAR(13) = '',
	@Address VARCHAR(MAX) = '',
	@PartyType VARCHAR(50) = '',
	@Active VARCHAR(50) = '',
	@ReturnValue INT = 0 OUT
AS
BEGIN
	 IF NOT EXISTS(SELECT * FROM dbo.MST_Party WITH(NOLOCK) WHERE PartyId = @Id)
	 BEGIN
		INSERT INTO	dbo.MST_Party
		        ( PartyType ,
		          PartyName ,
		          Mobile ,
		          Address ,
		          Active
		        )
		VALUES  ( @PartyType , -- PartyType - varchar(50)
		          @PartyName , -- PartyName - varchar(500)
		          @Mobile , -- Mobile - varchar(10)
		          @Address , -- Address - varchar(5000)
		          @Active  -- Active - bit
		        )
	 END
	 ELSE	
	 BEGIN
			UPDATE dbo.MST_Party SET	
					PartyType = @PartyType,
					PartyName = @PartyName,
					Mobile = @Mobile,
					Address = @Address,
					Active = @Active
			WHERE PartyId = @Id		
	 END
	 
	 IF	@@ERROR = 0
	 BEGIN
		SET @ReturnValue = 1	
	 END
	 ELSE	
	 BEGIN
	     SET @ReturnValue = 0
	 END
END
GO
/****** Object:  StoredProcedure [dbo].[MST_ParameterValue_InsertUpdate]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[MST_ParameterValue_InsertUpdate]
	@Id int = 0,
	@TypeId int = 0,
	@ParaCode varchar(50) = '',
	@ParaValue varchar(50) = '',
	@Remark varchar(5000) ='',
	@Active bit = 0,
	@ReturnValue int = 0 out
AS
begin
	if not exists(select 1 from MST_ParameterValue with(nolock) where ParaValueId = @Id)
	begin
		insert into MST_ParameterValue
		(
			ParaTypeId,
			ParaCode,
			ParaValue,
			Remark,
			Active

		)
		Values
		(
			@TypeId,
			@ParaCode,
			@ParaValue,
			@Remark,
			@Active
		)
	end
	else
	begin
		update MST_ParameterValue set
			ParaTypeId = @TypeId,
			ParaCode = @ParaCode,
			ParaValue = @ParaValue,
			Remark = Remark,
			Active = @Active
		where ParaValueId = @Id	
	end
	
	if @@error = 0
	begin
		set @ReturnValue = 1
	end
	else
	begin
		set @ReturnValue = 0
	end
end
GO
/****** Object:  StoredProcedure [dbo].[MST_ParameterType_InsertUpdate]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[MST_ParameterType_InsertUpdate]
	@Id int = 0,
	@Type varchar(50) = '',
	@Remark varchar(5000) ='',
	@Active bit = 0,
	@ReturnValue int = 0 out
AS
begin
	if not exists(select 1 from MST_Parameter_Type with(nolock) where ParameterTypeId = @Id)
	begin
		insert into MST_Parameter_Type
		(
			ParameterType,
			Remark,
			Active
		)
		Values
		(
			@Type,
			@Remark,
			@Active
		)
	end
	else
	begin
		update MST_Parameter_Type set
			ParameterType = @Type,
			Remark = Remark,
			Active = @Active
		where ParameterTypeId = @Id	
	end
	
	if @@error = 0
	begin
		set @ReturnValue = 1
	end
	else
	begin
		set @ReturnValue = 0
	end
end
GO
/****** Object:  StoredProcedure [dbo].[MST_Kharidi_InsertUpdate]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MST_Kharidi_InsertUpdate]
	@Id INT = 0 ,
	@NotNo VARCHAR(50)='K-1',
	@KatNo VARCHAR(50)='1',
	@KharidiDate VARCHAR(15)='03/08/2017',
	@PaymentDate VARCHAR(15)='03/28/2017',
	@Term INT = 20,
	@PartyId INT =5,
	@BrokerId INT = 1,
	@Cts FLOAT = 50,
	@Rate FLOAT = 20,
	@RafPer FLOAT = 0,
	@BasicTotal FLOAT = 1000,
	@AngadiyaPer FLOAT = 5,
	@AngadiyaKharch FLOAT = 50,
	@FinalTotal FLOAT = 950,
	@ReturnValue INT = 0 OUT
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM dbo.MST_Kharidi WITH(NOLOCK) WHERE ID = @Id)
	BEGIN
		INSERT INTO	dbo.MST_Kharidi
		        ( NotNo ,
		          KatNo ,
		          KharidiDate ,
		          PaymentTerm ,
		          PaymentDate ,
		          PartyId ,
		          BrokerId ,
		          Cts ,
		          Rate ,
		          RafPercentage ,
		          BasicTotal ,
		          AngadiyaKharchPer ,
		          AngadiyaKharch ,
		          FinalTotal
		        )
		VALUES  ( @NotNo , -- NotNo - varchar(50)
		          @KatNo , -- KatNo - varchar(50)
		          @KharidiDate , -- KharidiDate - datetime
		          @Term , -- PaymentTerm - int
		          @PaymentDate , -- PaymentDate - datetime
		          @PartyId , -- PartyId - int
		          @BrokerId , -- BrokerId - int
		          @Cts , -- Cts - float
		          @Rate , -- Rate - float
		          @RafPer , -- RafPercentage - float
		          @BasicTotal , -- BasicTotal - float
		          @AngadiyaPer , -- AngadiyaKharchPer - float
		          @AngadiyaKharch , -- AngadiyaKharch - float
		          @FinalTotal  -- FinalTotal - float
		        )
	END
	ELSE		
	BEGIN
		UPDATE dbo.MST_Kharidi SET
			NotNo = @NotNo,
			KatNo = @KatNo,
			KharidiDate = CONVERT(DATETIME,@KharidiDate),
			PaymentTerm = @Term,
			PaymentDate = CONVERT(DATETIME,@PaymentDate),
			PartyId = @PartyId,
			BrokerId = @BrokerId,
			Cts = @Cts,
			Rate = @Rate,
			RafPercentage = @RafPer,
			BasicTotal = @BasicTotal,
			AngadiyaKharchPer = @AngadiyaPer,
			AngadiyaKharch = @AngadiyaKharch,
			FinalTotal = @FinalTotal
		WHERE ID = @Id		
	END
	
	
	IF	@@ERROR = 0
	BEGIN
		SET @ReturnValue = 1	
	END
	ELSE	
	BEGIN
	    SET @ReturnValue = 0
	END
END
GO
/****** Object:  StoredProcedure [dbo].[MST_Kharidi_GetNotNo]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MST_Kharidi_GetNotNo]
	@IsPolish int = 0
	
AS
begin
 if	@IsPolish = 0
 begin
	Select 'K-' + Convert(varchar(50),ISNULL(MAX(KatNo),0)+1) AS MAXNO From dbo.MST_Kharidi with(nolock) 
 end
 else
 begin
	Select 'P-' + Convert(varchar(50),ISNULL(MAX(KatNo),0)+1) AS MAXNO From dbo.MST_Polish_Kharidi with(nolock) 
 end
 
	
end
GO
/****** Object:  StoredProcedure [dbo].[MST_Kharidi_Delete]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MST_Kharidi_Delete]
	@Id INT =0,
	@ReturnValue INT = 0 OUT
AS 
BEGIN
   
    DELETE FROM dbo.MST_Kharidi WHERE ID = @Id
    
    IF NOT EXISTS(SELECT * FROM dbo.MST_Kharidi WITH(NOLOCK) WHERE ID = @Id)
    BEGIN
        SET @ReturnValue = 1
    END
    ELSE	
    BEGIN
        SET @ReturnValue = 0
    END
END
GO
/****** Object:  StoredProcedure [dbo].[MST_Dalal_InsertUpdate]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MST_Dalal_InsertUpdate]
	@Id INT = 0,
	@PartyId INT = 0,
	@DalalName VARCHAR(200) = '',
	@Mobile VARCHAR(13) = '',
	@Address VARCHAR(MAX) = '',
	@DalalType VARCHAR(50) = '',
	@Active VARCHAR(50) = '',
	@ReturnValue INT = 0 OUT
AS
BEGIN
	 IF NOT EXISTS(SELECT 1 FROM dbo.MST_Dalal WITH(NOLOCK) WHERE DalalId = @Id)
	 BEGIN
		INSERT INTO dbo.MST_Dalal
		        ( PartyId,
		          DalalType ,
		          DalalName ,
		          Mobile ,
		          Address ,
		          Active
		        )
		VALUES  ( @PartyId,
				  @DalalType , -- DalalType - varchar(50)
		          @DalalName , -- DalalName - varchar(200)
		          @Mobile , -- Mobile - varchar(10)
		          @Address , -- Address - varchar(max)
		          @Active  -- Active - bit
		        )
	 END
	 ELSE	
	 BEGIN
			UPDATE dbo.MST_Dalal SET	
					PartyId = @PartyId,
					DalalType = @DalalType,
					DalalName = @DalalName,
					Mobile = @Mobile,
					Address = @Address,
					Active = @Active
			WHERE DalalId = @Id		
	 END
	 
	 IF	@@ERROR = 0
	 BEGIN
		SET @ReturnValue = 1	
	 END
	 ELSE	
	 BEGIN
	     SET @ReturnValue = 0
	 END
END
GO
/****** Object:  StoredProcedure [dbo].[MST_Karkhana_InsertUpdate]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MST_Karkhana_InsertUpdate]
	@Id int = 0,
	@KarkhanaName varchar(50) = '',
	@OwnerName varchar(50) = '',
	@Mobile varchar(10)='',
	@Address varchar(5000) = '',
	@Active bit,
	@ReturnValue int = 0 out	
AS
begin
	if not exists(select 1 from MST_Karkhana_Master with(nolock) where Id = @Id)
	begin
		insert into MST_Karkhana_Master
		(
			KarkhanaName,
			[Owner],
			Mobile,
			[Address],
			Active

		)
		Values
		(
			@KarkhanaName,
			@OwnerName,
			@Mobile,
			@Address,
			@Active
		)
	end
	else
	begin
		Update MST_Karkhana_Master set
			KarkhanaName = @KarkhanaName,
			[Owner] = @OwnerName,
			Mobile = @Mobile,
			[Address] = @Address,
			Active = @Active
		where Id = @Id
	end
	
	if @@Error = 0
	begin
		SET @ReturnValue = 1
	end
	else 
	begin
		SET @ReturnValue = 0
	end
end
GO
/****** Object:  StoredProcedure [dbo].[MST_Dalal_Delete]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MST_Dalal_Delete]
	@Id INT =0,
	@ReturnValue INT = 0 OUT
AS 
BEGIN
   
    DELETE FROM dbo.MST_Dalal WHERE DalalId = @Id
    
    IF NOT EXISTS(SELECT 1 FROM dbo.MST_Dalal WITH(NOLOCK) WHERE DalalId = @Id)
    BEGIN
        SET @ReturnValue = 1
    END
    ELSE	
    BEGIN
        SET @ReturnValue = 0
    END
END
GO
/****** Object:  StoredProcedure [dbo].[Karkhana_IssueReturn_InsertUpdate]    Script Date: 04/27/2017 00:02:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE	 PROCEDURE [dbo].[Karkhana_IssueReturn_InsertUpdate]
    @Id INT = 0 ,
    @KarkhanaId INT = 0,
    @IssueDate VARCHAR(50) ='',
    @ReturnDate VARCHAR(50) = '',
    @NotNo VARCHAR(50) = '' ,
    @KatNo VARCHAR(50) = '' ,
    @KharidiDate VARCHAR(50) = '' ,
    @Cts FLOAT = 0 ,
    @Rate FLOAT = 0 ,
    @Amount FLOAT = 0 ,
    @BanvaChadelu FLOAT = 0,
    @VajanLoss FLOAT = 0,
    @VajanGhatt FLOAT = 0,
    @PalsuVajan FLOAT = 0,
    @PalsuRate FLOAT = 0,
    @PalsuAmount FLOAT = 0,
    @ChokiVajan FLOAT = 0,
    @ChokiRate FLOAT = 0,
    @ChokiAmount FLOAT = 0,
    @DblVajan FLOAT = 0,
    @DblRate FLOAT = 0,
    @DblAmount FLOAT = 0,
    @PCDAmount FLOAT = 0,
    @Than FLOAT = 0,
    @ThanTotal FLOAT = 0,
    @TaiyarVajan FLOAT = 0,
	@TaiyarPadatar FLOAT = 0,
	@CommPadatar FLOAT = 0,
	@FinalPadatar FLOAT = 0,
	@STaka FLOAT = 0,
	@RafTaka FLOAT = 0,
	@Status VARCHAR(5) = '',
    @ReturnValue INT = 0 OUT
AS
    BEGIN
    
    DECLARE @PKID INT
        IF NOT EXISTS ( SELECT  1
                        FROM    TRN_Karkhana_IssueReturn WITH ( NOLOCK )
                        WHERE   Id = @Id )
            BEGIN
				
				SELECT @PKID = ISNULL(MAXID,0) + 1 FROM dbo.Table_MaxId_Generate WITH(NOLOCK) WHERE TABLE_NAME = 'TRN_Karkhana_IssueReturn'
				
                INSERT INTO dbo.TRN_Karkhana_IssueReturn
                        ( Id ,
                          KarkhanaId ,
                          IssueDate ,
                          Returndate ,
                          NotNo ,
                          KatNo ,
                          KharidiDate ,
                          Vajan ,
                          Rate ,
                          Amount ,
                          BanvaChadeluCts ,
                          VajanLoss ,
                          VajanGhatt ,
                          PalsuVajan ,
                          PalsuRate ,
                          PalsuAmount ,
                          ChokiVajan ,
                          ChokiRate ,
                          ChokiAmount ,
                          DblVajan ,
                          DblRate ,
                          DblAmount ,
                          PCDAmount ,
                          Than ,
                          ThanTotal ,
                          TaiyarVajan ,
                          TaiyarPadatar ,
                          CommPadatar ,
                          FinalPadatar ,
                          STaka ,
                          RafTaka ,
                          Status
                        )
                VALUES  ( @PKID , -- Id - int
                          @KarkhanaId , -- KarkhanaId - int
                          @IssueDate , -- IssueDate - datetime
                          '' , -- Returndate - datetime
                          @NotNo , -- NotNo - varchar(50)
                          @KatNo , -- KatNo - varchar(50)
                          @KharidiDate , -- KharidiDate - datetime
                          @Cts , -- Vajan - float
                          @Rate , -- Rate - float
                          @Amount , -- Amount - float
                          @BanvaChadelu , -- BanvaChadeluCts - float
                          @VajanLoss , -- VajanLoss - float
                          @VajanGhatt, -- VajanGhatt - float
                          @PalsuVajan , -- PalsuVajan - float
                          @PalsuRate, -- PalsuRate - float
                          @PalsuAmount , -- PalsuAmount - float
                          @ChokiVajan , -- ChokiVajan - float
                          @ChokiRate , -- ChokiRate - float
                          @ChokiAmount , -- ChokiAmount - float
                          @DblVajan , -- DblVajan - float
                          @DblRate , -- DblRate - float
                          @DblAmount , -- DblAmount - float
                          @PCDAmount , -- PCDAmount - float
                          @Than , -- Than - int
                          @ThanTotal , -- ThanTotal - float
                          @TaiyarVajan , -- TaiyarVajan - float
                          @TaiyarPadatar , -- TaiyarPadatar - float
                          @CommPadatar , -- CommPadatar - float
                          @FinalPadatar , -- FinalPadatar - float
                          @STaka , -- STaka - float
                          @RafTaka , -- RafTaka - float
                          @Status  -- Status - varchar(50)
                        )
		                
		         UPDATE dbo.Table_MaxId_Generate SET MAXID = @PKID WHERE TABLE_NAME = 'TRN_Karkhana_IssueReturn'       
            END;
        ELSE
            BEGIN
                UPDATE  TRN_Karkhana_IssueReturn
                SET     KarkhanaId = @KarkhanaId,
                          IssueDate = @IssueDate,
                          Returndate = '',
                          NotNo = @NotNo,
                          KatNo = @KatNo,
                          KharidiDate  = @KharidiDate,
                          Vajan = @Cts,
                          Rate = @Rate,
                          Amount = @Amount,
                          BanvaChadeluCts = @BanvaChadelu,
                          VajanLoss = @VajanLoss,
                          VajanGhatt = @VajanGhatt,
                          PalsuVajan = @PalsuVajan,
                          PalsuRate = @PalsuRate,
                          PalsuAmount = @PalsuAmount,
                          ChokiVajan = @ChokiVajan,
                          ChokiRate = @ChokiRate,
                          ChokiAmount = @ChokiAmount,
                          DblVajan = @DblVajan,
                          DblRate = @DblRate,
                          DblAmount = @DblAmount,
                          PCDAmount = @PCDAmount,
                          Than = @Than,
                          ThanTotal = @ThanTotal,
                          TaiyarVajan = @TaiyarVajan,
                          TaiyarPadatar = @TaiyarPadatar,
                          CommPadatar = @CommPadatar,
                          FinalPadatar = @FinalPadatar,
                          STaka = @STaka,
                          RafTaka = @RafTaka,
                          Status = @Status
                WHERE   Id = @Id;	
            END;
            
        
	
        IF @@Error = 0
            BEGIN
                SET @ReturnValue = 1;
            END;
        ELSE
            BEGIN
                SET @ReturnValue = 0;
            END;
    END;
GO
/****** Object:  Default [DF_MST_Dalal_PartyId]    Script Date: 04/27/2017 00:02:16 ******/
ALTER TABLE [dbo].[MST_Dalal] ADD  CONSTRAINT [DF_MST_Dalal_PartyId]  DEFAULT ((0)) FOR [PartyId]
GO
/****** Object:  Default [DF_MST_Dalal_DalalType]    Script Date: 04/27/2017 00:02:16 ******/
ALTER TABLE [dbo].[MST_Dalal] ADD  CONSTRAINT [DF_MST_Dalal_DalalType]  DEFAULT ('') FOR [DalalType]
GO
/****** Object:  Default [DF_MST_Dalal_DalalName]    Script Date: 04/27/2017 00:02:16 ******/
ALTER TABLE [dbo].[MST_Dalal] ADD  CONSTRAINT [DF_MST_Dalal_DalalName]  DEFAULT ('') FOR [DalalName]
GO
/****** Object:  Default [DF_MST_Dalal_Mobile]    Script Date: 04/27/2017 00:02:16 ******/
ALTER TABLE [dbo].[MST_Dalal] ADD  CONSTRAINT [DF_MST_Dalal_Mobile]  DEFAULT ('') FOR [Mobile]
GO
/****** Object:  Default [DF_MST_Dalal_Address]    Script Date: 04/27/2017 00:02:16 ******/
ALTER TABLE [dbo].[MST_Dalal] ADD  CONSTRAINT [DF_MST_Dalal_Address]  DEFAULT ('') FOR [Address]
GO
/****** Object:  Default [DF_MST_Dalal_Active]    Script Date: 04/27/2017 00:02:16 ******/
ALTER TABLE [dbo].[MST_Dalal] ADD  CONSTRAINT [DF_MST_Dalal_Active]  DEFAULT ((0)) FOR [Active]
GO
/****** Object:  Default [DF_MST_Kharidi_NotNo]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Kharidi] ADD  CONSTRAINT [DF_MST_Kharidi_NotNo]  DEFAULT ('') FOR [NotNo]
GO
/****** Object:  Default [DF_MST_Kharidi_KatNo]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Kharidi] ADD  CONSTRAINT [DF_MST_Kharidi_KatNo]  DEFAULT ('') FOR [KatNo]
GO
/****** Object:  Default [DF_MST_Kharidi_PaymentTerm]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Kharidi] ADD  CONSTRAINT [DF_MST_Kharidi_PaymentTerm]  DEFAULT ((0)) FOR [PaymentTerm]
GO
/****** Object:  Default [DF_MST_Kharidi_PartyName]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Kharidi] ADD  CONSTRAINT [DF_MST_Kharidi_PartyName]  DEFAULT ((0)) FOR [PartyId]
GO
/****** Object:  Default [DF_MST_Kharidi_BrokerName]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Kharidi] ADD  CONSTRAINT [DF_MST_Kharidi_BrokerName]  DEFAULT ((0)) FOR [BrokerId]
GO
/****** Object:  Default [DF_MST_Kharidi_Cts]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Kharidi] ADD  CONSTRAINT [DF_MST_Kharidi_Cts]  DEFAULT ((0)) FOR [Cts]
GO
/****** Object:  Default [DF_MST_Kharidi_Rate]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Kharidi] ADD  CONSTRAINT [DF_MST_Kharidi_Rate]  DEFAULT ((0)) FOR [Rate]
GO
/****** Object:  Default [DF_MST_Kharidi_RafPercentage]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Kharidi] ADD  CONSTRAINT [DF_MST_Kharidi_RafPercentage]  DEFAULT ((0)) FOR [RafPercentage]
GO
/****** Object:  Default [DF_MST_Kharidi_BasicTotal]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Kharidi] ADD  CONSTRAINT [DF_MST_Kharidi_BasicTotal]  DEFAULT ((0)) FOR [BasicTotal]
GO
/****** Object:  Default [DF_MST_Kharidi_AngadiyaKharchPer]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Kharidi] ADD  CONSTRAINT [DF_MST_Kharidi_AngadiyaKharchPer]  DEFAULT ((0)) FOR [AngadiyaKharchPer]
GO
/****** Object:  Default [DF_MST_Kharidi_AngadiyaKharch]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Kharidi] ADD  CONSTRAINT [DF_MST_Kharidi_AngadiyaKharch]  DEFAULT ((0)) FOR [AngadiyaKharch]
GO
/****** Object:  Default [DF_MST_Kharidi_FinalTotal]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Kharidi] ADD  CONSTRAINT [DF_MST_Kharidi_FinalTotal]  DEFAULT ((0)) FOR [FinalTotal]
GO
/****** Object:  Default [DF_MST_Kharidi_PaymentStatus]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Kharidi] ADD  CONSTRAINT [DF_MST_Kharidi_PaymentStatus]  DEFAULT ('') FOR [PaymentStatus]
GO
/****** Object:  Default [DF_MST_Karkhana_Master_KarkhanaName]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Karkhana_Master] ADD  CONSTRAINT [DF_MST_Karkhana_Master_KarkhanaName]  DEFAULT ('') FOR [KarkhanaName]
GO
/****** Object:  Default [DF_MST_Karkhana_Master_Owner]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Karkhana_Master] ADD  CONSTRAINT [DF_MST_Karkhana_Master_Owner]  DEFAULT ('') FOR [Owner]
GO
/****** Object:  Default [DF_MST_Karkhana_Master_Mobile]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Karkhana_Master] ADD  CONSTRAINT [DF_MST_Karkhana_Master_Mobile]  DEFAULT ('') FOR [Mobile]
GO
/****** Object:  Default [DF_MST_Karkhana_Master_Address]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Karkhana_Master] ADD  CONSTRAINT [DF_MST_Karkhana_Master_Address]  DEFAULT ('') FOR [Address]
GO
/****** Object:  Default [DF_MST_Karkhana_Master_Active]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Karkhana_Master] ADD  CONSTRAINT [DF_MST_Karkhana_Master_Active]  DEFAULT ((0)) FOR [Active]
GO
/****** Object:  Default [DF_MST_Parameter_Type_ParameterType]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Parameter_Type] ADD  CONSTRAINT [DF_MST_Parameter_Type_ParameterType]  DEFAULT ('') FOR [ParameterType]
GO
/****** Object:  Default [DF_MST_Parameter_Type_Remark]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Parameter_Type] ADD  CONSTRAINT [DF_MST_Parameter_Type_Remark]  DEFAULT ('') FOR [Remark]
GO
/****** Object:  Default [DF_MST_Parameter_Type_Active]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Parameter_Type] ADD  CONSTRAINT [DF_MST_Parameter_Type_Active]  DEFAULT ((0)) FOR [Active]
GO
/****** Object:  Default [DF_MST_ParameterValue_ParaTypeId]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_ParameterValue] ADD  CONSTRAINT [DF_MST_ParameterValue_ParaTypeId]  DEFAULT ((0)) FOR [ParaTypeId]
GO
/****** Object:  Default [DF_MST_ParameterValue_ParaCode]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_ParameterValue] ADD  CONSTRAINT [DF_MST_ParameterValue_ParaCode]  DEFAULT ('') FOR [ParaCode]
GO
/****** Object:  Default [DF_MST_ParameterValue_ParaValue]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_ParameterValue] ADD  CONSTRAINT [DF_MST_ParameterValue_ParaValue]  DEFAULT ('') FOR [ParaValue]
GO
/****** Object:  Default [DF_MST_ParameterValue_Remark]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_ParameterValue] ADD  CONSTRAINT [DF_MST_ParameterValue_Remark]  DEFAULT ('') FOR [Remark]
GO
/****** Object:  Default [DF_MST_ParameterValue_Active]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_ParameterValue] ADD  CONSTRAINT [DF_MST_ParameterValue_Active]  DEFAULT ((0)) FOR [Active]
GO
/****** Object:  Default [DF_MST_Party_PartyType]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Party] ADD  CONSTRAINT [DF_MST_Party_PartyType]  DEFAULT ('') FOR [PartyType]
GO
/****** Object:  Default [DF_MST_Party_PartyName]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Party] ADD  CONSTRAINT [DF_MST_Party_PartyName]  DEFAULT ('') FOR [PartyName]
GO
/****** Object:  Default [DF_MST_Party_Mobile]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Party] ADD  CONSTRAINT [DF_MST_Party_Mobile]  DEFAULT ('') FOR [Mobile]
GO
/****** Object:  Default [DF_MST_Party_Address]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Party] ADD  CONSTRAINT [DF_MST_Party_Address]  DEFAULT ('') FOR [Address]
GO
/****** Object:  Default [DF_MST_Party_Active]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Party] ADD  CONSTRAINT [DF_MST_Party_Active]  DEFAULT ((0)) FOR [Active]
GO
/****** Object:  Default [DF_MST_Polish_Kharidi_NotNo]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Polish_Kharidi] ADD  CONSTRAINT [DF_MST_Polish_Kharidi_NotNo]  DEFAULT ('') FOR [NotNo]
GO
/****** Object:  Default [DF_MST_Polish_Kharidi_KatNo]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Polish_Kharidi] ADD  CONSTRAINT [DF_MST_Polish_Kharidi_KatNo]  DEFAULT ('') FOR [KatNo]
GO
/****** Object:  Default [DF_MST_Polish_Kharidi_PaymentTerm]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Polish_Kharidi] ADD  CONSTRAINT [DF_MST_Polish_Kharidi_PaymentTerm]  DEFAULT ((0)) FOR [PaymentTerm]
GO
/****** Object:  Default [DF_MST_Polish_Kharidi_PartyId]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Polish_Kharidi] ADD  CONSTRAINT [DF_MST_Polish_Kharidi_PartyId]  DEFAULT ((0)) FOR [PartyId]
GO
/****** Object:  Default [DF_MST_Polish_Kharidi_BrokerId]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Polish_Kharidi] ADD  CONSTRAINT [DF_MST_Polish_Kharidi_BrokerId]  DEFAULT ((0)) FOR [BrokerId]
GO
/****** Object:  Default [DF_MST_Polish_Kharidi_Cts]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Polish_Kharidi] ADD  CONSTRAINT [DF_MST_Polish_Kharidi_Cts]  DEFAULT ((0)) FOR [Cts]
GO
/****** Object:  Default [DF_MST_Polish_Kharidi_Rate]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Polish_Kharidi] ADD  CONSTRAINT [DF_MST_Polish_Kharidi_Rate]  DEFAULT ((0)) FOR [Rate]
GO
/****** Object:  Default [DF_MST_Polish_Kharidi_RafPercentage]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Polish_Kharidi] ADD  CONSTRAINT [DF_MST_Polish_Kharidi_RafPercentage]  DEFAULT ((0)) FOR [RafPercentage]
GO
/****** Object:  Default [DF_MST_Polish_Kharidi_BasicTotal]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Polish_Kharidi] ADD  CONSTRAINT [DF_MST_Polish_Kharidi_BasicTotal]  DEFAULT ((0)) FOR [BasicTotal]
GO
/****** Object:  Default [DF_MST_Polish_Kharidi_AngadiyaKharchPer]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Polish_Kharidi] ADD  CONSTRAINT [DF_MST_Polish_Kharidi_AngadiyaKharchPer]  DEFAULT ((0)) FOR [AngadiyaKharchPer]
GO
/****** Object:  Default [DF_MST_Polish_Kharidi_AngadiyaKharch]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Polish_Kharidi] ADD  CONSTRAINT [DF_MST_Polish_Kharidi_AngadiyaKharch]  DEFAULT ((0)) FOR [AngadiyaKharch]
GO
/****** Object:  Default [DF_MST_Polish_Kharidi_FinalTotal]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Polish_Kharidi] ADD  CONSTRAINT [DF_MST_Polish_Kharidi_FinalTotal]  DEFAULT ((0)) FOR [FinalTotal]
GO
/****** Object:  Default [DF_MST_Polish_Kharidi_PaymentStatus]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[MST_Polish_Kharidi] ADD  CONSTRAINT [DF_MST_Polish_Kharidi_PaymentStatus]  DEFAULT ('') FOR [PaymentStatus]
GO
/****** Object:  Default [DF_TRN_Payment_Detail_TransactionId]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Payment_Detail] ADD  CONSTRAINT [DF_TRN_Payment_Detail_TransactionId]  DEFAULT ('') FOR [TransactionId]
GO
/****** Object:  Default [DF_TRN_Payment_Detail_PaymentDate]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Payment_Detail] ADD  CONSTRAINT [DF_TRN_Payment_Detail_PaymentDate]  DEFAULT (getdate()) FOR [PaymentDate]
GO
/****** Object:  Default [DF_TRN_Payment_Detail_PaymentType]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Payment_Detail] ADD  CONSTRAINT [DF_TRN_Payment_Detail_PaymentType]  DEFAULT ('') FOR [PaymentType]
GO
/****** Object:  Default [DF_TRN_Payment_Detail_PartyId]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Payment_Detail] ADD  CONSTRAINT [DF_TRN_Payment_Detail_PartyId]  DEFAULT ((0)) FOR [PartyId]
GO
/****** Object:  Default [DF_TRN_Payment_Detail_NotNo]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Payment_Detail] ADD  CONSTRAINT [DF_TRN_Payment_Detail_NotNo]  DEFAULT ('') FOR [NotNo]
GO
/****** Object:  Default [DF_TRN_Payment_Detail_KatNo]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Payment_Detail] ADD  CONSTRAINT [DF_TRN_Payment_Detail_KatNo]  DEFAULT ('') FOR [KatNo]
GO
/****** Object:  Default [DF_TRN_Payment_Detail_KharidiDate]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Payment_Detail] ADD  CONSTRAINT [DF_TRN_Payment_Detail_KharidiDate]  DEFAULT ('') FOR [KharidiDate]
GO
/****** Object:  Default [DF_TRN_Payment_Detail_vajan]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Payment_Detail] ADD  CONSTRAINT [DF_TRN_Payment_Detail_vajan]  DEFAULT ((0)) FOR [vajan]
GO
/****** Object:  Default [DF_TRN_Payment_Detail_Rate]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Payment_Detail] ADD  CONSTRAINT [DF_TRN_Payment_Detail_Rate]  DEFAULT ((0)) FOR [Rate]
GO
/****** Object:  Default [DF_TRN_Payment_Detail_Amount]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Payment_Detail] ADD  CONSTRAINT [DF_TRN_Payment_Detail_Amount]  DEFAULT ((0)) FOR [Amount]
GO
/****** Object:  Default [DF_TRN_Payment_Detail_PaidAmount]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Payment_Detail] ADD  CONSTRAINT [DF_TRN_Payment_Detail_PaidAmount]  DEFAULT ((0)) FOR [PaidAmount]
GO
/****** Object:  Default [DF_TRN_Payment_Detail_DueAmount]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Payment_Detail] ADD  CONSTRAINT [DF_TRN_Payment_Detail_DueAmount]  DEFAULT ((0)) FOR [DueAmount]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_KarkhanaId]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_KarkhanaId]  DEFAULT ((0)) FOR [KarkhanaId]
GO
/****** Object:  Default [DF_TRN_Karkhana_Issue_KatNo]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_Issue_KatNo]  DEFAULT ('') FOR [KatNo]
GO
/****** Object:  Default [DF_TRN_Karkhana_Issue_KharidiDate]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_Issue_KharidiDate]  DEFAULT (getdate()) FOR [KharidiDate]
GO
/****** Object:  Default [DF_TRN_Karkhana_Issue_Vajan]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_Issue_Vajan]  DEFAULT ((0)) FOR [Vajan]
GO
/****** Object:  Default [DF_TRN_Karkhana_Issue_Rate]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_Issue_Rate]  DEFAULT ((0)) FOR [Rate]
GO
/****** Object:  Default [DF_TRN_Karkhana_Issue_Amount]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_Issue_Amount]  DEFAULT ((0)) FOR [Amount]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_BanvaChadeluCts]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_BanvaChadeluCts]  DEFAULT ((0)) FOR [BanvaChadeluCts]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_VajanLoss]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_VajanLoss]  DEFAULT ((0)) FOR [VajanLoss]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_VajanGhatt]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_VajanGhatt]  DEFAULT ((0)) FOR [VajanGhatt]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_PalsuVajan]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_PalsuVajan]  DEFAULT ((0)) FOR [PalsuVajan]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_PalsuRate]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_PalsuRate]  DEFAULT ((0)) FOR [PalsuRate]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_PalsuAmount]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_PalsuAmount]  DEFAULT ((0)) FOR [PalsuAmount]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_ChokiVajan]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_ChokiVajan]  DEFAULT ((0)) FOR [ChokiVajan]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_ChokiRate]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_ChokiRate]  DEFAULT ((0)) FOR [ChokiRate]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_ChokiAmount]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_ChokiAmount]  DEFAULT ((0)) FOR [ChokiAmount]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_DblVajan]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_DblVajan]  DEFAULT ((0)) FOR [DblVajan]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_DblRate]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_DblRate]  DEFAULT ((0)) FOR [DblRate]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_DblAmount]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_DblAmount]  DEFAULT ((0)) FOR [DblAmount]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_PCDAmount]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_PCDAmount]  DEFAULT ((0)) FOR [PCDAmount]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_Than]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_Than]  DEFAULT ((0)) FOR [Than]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_ThanTotal]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_ThanTotal]  DEFAULT ((0)) FOR [ThanTotal]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_TaiyarVajan]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_TaiyarVajan]  DEFAULT ((0)) FOR [TaiyarVajan]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_TaiyarPadatar]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_TaiyarPadatar]  DEFAULT ((0)) FOR [TaiyarPadatar]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_CommPadatar]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_CommPadatar]  DEFAULT ((0)) FOR [CommPadatar]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_FinalPadatar]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_FinalPadatar]  DEFAULT ((0)) FOR [FinalPadatar]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_STaka]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_STaka]  DEFAULT ((0)) FOR [STaka]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_RafTaka]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_RafTaka]  DEFAULT ((0)) FOR [RafTaka]
GO
/****** Object:  Default [DF_TRN_Karkhana_IssueReturn_Status]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[TRN_Karkhana_IssueReturn] ADD  CONSTRAINT [DF_TRN_Karkhana_IssueReturn_Status]  DEFAULT ('') FOR [Status]
GO
/****** Object:  Default [DF_Table_MaxId_Generate_MAXID]    Script Date: 04/27/2017 00:02:17 ******/
ALTER TABLE [dbo].[Table_MaxId_Generate] ADD  CONSTRAINT [DF_Table_MaxId_Generate_MAXID]  DEFAULT ((0)) FOR [MAXID]
GO
