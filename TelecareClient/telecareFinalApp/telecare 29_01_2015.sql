USE [master]਀䜀伀 
/****** Object:  Database [TeleCare]    Script Date: 29/Jan/2015 3:55:34 AM ******/਀䌀刀䔀䄀吀䔀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 
 CONTAINMENT = NONE਀ 伀一  倀刀䤀䴀䄀刀夀  
( NAME = N'TeleCare', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TeleCare.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )਀ 䰀伀䜀 伀一  
( NAME = N'TeleCare_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TeleCare_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)਀䜀伀 
ALTER DATABASE [TeleCare] SET COMPATIBILITY_LEVEL = 100਀䜀伀 
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))਀戀攀最椀渀 
EXEC [TeleCare].[dbo].[sp_fulltext_database] @action = 'enable'਀攀渀搀 
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䄀一匀䤀开一唀䰀䰀开䐀䔀䘀䄀唀䰀吀 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䄀一匀䤀开一唀䰀䰀匀 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䄀一匀䤀开倀䄀䐀䐀䤀一䜀 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䄀一匀䤀开圀䄀刀一䤀一䜀匀 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䄀刀䤀吀䠀䄀䈀伀刀吀 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䄀唀吀伀开䌀䰀伀匀䔀 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䄀唀吀伀开䌀刀䔀䄀吀䔀开匀吀䄀吀䤀匀吀䤀䌀匀 伀一  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䄀唀吀伀开匀䠀刀䤀一䬀 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䄀唀吀伀开唀倀䐀䄀吀䔀开匀吀䄀吀䤀匀吀䤀䌀匀 伀一  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䌀唀刀匀伀刀开䌀䰀伀匀䔀开伀一开䌀伀䴀䴀䤀吀 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䌀唀刀匀伀刀开䐀䔀䘀䄀唀䰀吀  䜀䰀伀䈀䄀䰀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䌀伀一䌀䄀吀开一唀䰀䰀开夀䤀䔀䰀䐀匀开一唀䰀䰀 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 一唀䴀䔀刀䤀䌀开刀伀唀一䐀䄀䈀伀刀吀 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 儀唀伀吀䔀䐀开䤀䐀䔀一吀䤀䘀䤀䔀刀 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 刀䔀䌀唀刀匀䤀嘀䔀开吀刀䤀䜀䜀䔀刀匀 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀  䐀䤀匀䄀䈀䰀䔀开䈀刀伀䬀䔀刀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䄀唀吀伀开唀倀䐀䄀吀䔀开匀吀䄀吀䤀匀吀䤀䌀匀开䄀匀夀一䌀 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䐀䄀吀䔀开䌀伀刀刀䔀䰀䄀吀䤀伀一开伀倀吀䤀䴀䤀娀䄀吀䤀伀一 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 吀刀唀匀吀圀伀刀吀䠀夀 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䄀䰀䰀伀圀开匀一䄀倀匀䠀伀吀开䤀匀伀䰀䄀吀䤀伀一 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 倀䄀刀䄀䴀䔀吀䔀刀䤀娀䄀吀䤀伀一 匀䤀䴀倀䰀䔀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 刀䔀䄀䐀开䌀伀䴀䴀䤀吀吀䔀䐀开匀一䄀倀匀䠀伀吀 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䠀伀一伀刀开䈀刀伀䬀䔀刀开倀刀䤀伀刀䤀吀夀 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 刀䔀䌀伀嘀䔀刀夀 匀䤀䴀倀䰀䔀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀  䴀唀䰀吀䤀开唀匀䔀刀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 倀䄀䜀䔀开嘀䔀刀䤀䘀夀 䌀䠀䔀䌀䬀匀唀䴀   
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䐀䈀开䌀䠀䄀䤀一䤀一䜀 伀䘀䘀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 䘀䤀䰀䔀匀吀刀䔀䄀䴀⠀ 一伀一开吀刀䄀一匀䄀䌀吀䔀䐀开䄀䌀䌀䔀匀匀 㴀 伀䘀䘀 ⤀  
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀 吀䄀刀䜀䔀吀开刀䔀䌀伀嘀䔀刀夀开吀䤀䴀䔀 㴀 　 匀䔀䌀伀一䐀匀  
GO਀唀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 
GO਀⼀⨀⨀⨀⨀⨀⨀ 伀戀樀攀挀琀㨀  匀琀漀爀攀搀倀爀漀挀攀搀甀爀攀 嬀搀戀漀崀⸀嬀䜀攀琀䌀栀愀爀琀䐀愀琀愀开匀倀崀    匀挀爀椀瀀琀 䐀愀琀攀㨀 ㈀㤀⼀䨀愀渀⼀㈀　㄀㔀 ㌀㨀㔀㔀㨀㌀㐀 䄀䴀 ⨀⨀⨀⨀⨀⨀⼀ 
SET ANSI_NULLS ON਀䜀伀 
SET QUOTED_IDENTIFIER ON਀䜀伀 
CREATE procedure [dbo].[GetChartData_SP]਀䀀椀搀 椀渀琀 
as begin਀ 
select top 7 weight,DATENAME(dw,create_date) as day from weight_master where user_id=@id order by create_date desc਀ 
select top 7 steps,DATENAME(dw,create_date) as day from steps_master where user_id=@id order by create_date desc਀ 
select top 7 body_temp,DATENAME(dw,create_date) as day from body_temp_master  where user_id=@id order by create_date desc਀ 
select top 7 spo2,DATENAME(dw,create_date) as day from spo2_master where user_id=@id order by create_date desc਀ 
select top 7 low,high,DATENAME(dw,create_date) as day from blood_master where user_id=@id order by create_date desc਀ 
end਀䜀伀 
/****** Object:  Table [dbo].[blood_master]    Script Date: 29/Jan/2015 3:55:34 AM ******/਀匀䔀吀 䄀一匀䤀开一唀䰀䰀匀 伀一 
GO਀匀䔀吀 儀唀伀吀䔀䐀开䤀䐀䔀一吀䤀䘀䤀䔀刀 伀一 
GO਀䌀刀䔀䄀吀䔀 吀䄀䈀䰀䔀 嬀搀戀漀崀⸀嬀戀氀漀漀搀开洀愀猀琀攀爀崀⠀ 
	[blood_id] [int] IDENTITY(1,1) NOT NULL,਀ऀ嬀甀猀攀爀开椀搀崀 嬀椀渀琀崀 一唀䰀䰀Ⰰ 
	[low] [int] NULL,਀ऀ嬀栀椀最栀崀 嬀椀渀琀崀 一唀䰀䰀Ⰰ 
	[exceed] [int] NULL,਀ऀ嬀挀爀攀愀琀攀开搀愀琀攀崀 嬀搀愀琀攀琀椀洀攀崀 一唀䰀䰀 
) ON [PRIMARY]਀ 
GO਀⼀⨀⨀⨀⨀⨀⨀ 伀戀樀攀挀琀㨀  吀愀戀氀攀 嬀搀戀漀崀⸀嬀戀漀搀礀开琀攀洀瀀开洀愀猀琀攀爀崀    匀挀爀椀瀀琀 䐀愀琀攀㨀 ㈀㤀⼀䨀愀渀⼀㈀　㄀㔀 ㌀㨀㔀㔀㨀㌀㐀 䄀䴀 ⨀⨀⨀⨀⨀⨀⼀ 
SET ANSI_NULLS ON਀䜀伀 
SET QUOTED_IDENTIFIER ON਀䜀伀 
CREATE TABLE [dbo].[body_temp_master](਀ऀ嬀戀漀搀礀开琀攀洀瀀䤀搀崀 嬀椀渀琀崀 䤀䐀䔀一吀䤀吀夀⠀㄀Ⰰ㄀⤀ 一伀吀 一唀䰀䰀Ⰰ 
	[user_id] [int] NULL,਀ऀ嬀戀漀搀礀开琀攀洀瀀崀 嬀渀挀栀愀爀崀⠀㄀　⤀ 一唀䰀䰀Ⰰ 
	[create_date] [datetime] NULL਀⤀ 伀一 嬀倀刀䤀䴀䄀刀夀崀 
਀䜀伀 
/****** Object:  Table [dbo].[spo2_master]    Script Date: 29/Jan/2015 3:55:34 AM ******/਀匀䔀吀 䄀一匀䤀开一唀䰀䰀匀 伀一 
GO਀匀䔀吀 儀唀伀吀䔀䐀开䤀䐀䔀一吀䤀䘀䤀䔀刀 伀一 
GO਀匀䔀吀 䄀一匀䤀开倀䄀䐀䐀䤀一䜀 伀一 
GO਀䌀刀䔀䄀吀䔀 吀䄀䈀䰀䔀 嬀搀戀漀崀⸀嬀猀瀀漀㈀开洀愀猀琀攀爀崀⠀ 
	[spo2_id] [int] IDENTITY(1,1) NOT NULL,਀ऀ嬀甀猀攀爀开椀搀崀 嬀椀渀琀崀 一唀䰀䰀Ⰰ 
	[spo2] [varchar](50) NULL,਀ऀ嬀攀砀挀攀攀搀崀 嬀椀渀琀崀 一唀䰀䰀Ⰰ 
	[create_date] [datetime] NULL਀⤀ 伀一 嬀倀刀䤀䴀䄀刀夀崀 
਀䜀伀 
SET ANSI_PADDING OFF਀䜀伀 
/****** Object:  Table [dbo].[steps_master]    Script Date: 29/Jan/2015 3:55:34 AM ******/਀匀䔀吀 䄀一匀䤀开一唀䰀䰀匀 伀一 
GO਀匀䔀吀 儀唀伀吀䔀䐀开䤀䐀䔀一吀䤀䘀䤀䔀刀 伀一 
GO਀䌀刀䔀䄀吀䔀 吀䄀䈀䰀䔀 嬀搀戀漀崀⸀嬀猀琀攀瀀猀开洀愀猀琀攀爀崀⠀ 
	[steps_id] [int] IDENTITY(1,1) NOT NULL,਀ऀ嬀甀猀攀爀开椀搀崀 嬀椀渀琀崀 一唀䰀䰀Ⰰ 
	[steps] [nchar](10) NULL,਀ऀ嬀挀爀攀愀琀攀开搀愀琀攀崀 嬀搀愀琀攀琀椀洀攀崀 一唀䰀䰀 
) ON [PRIMARY]਀ 
GO਀⼀⨀⨀⨀⨀⨀⨀ 伀戀樀攀挀琀㨀  吀愀戀氀攀 嬀搀戀漀崀⸀嬀琀攀氀攀挀愀爀攀开洀愀猀琀攀爀崀    匀挀爀椀瀀琀 䐀愀琀攀㨀 ㈀㤀⼀䨀愀渀⼀㈀　㄀㔀 ㌀㨀㔀㔀㨀㌀㐀 䄀䴀 ⨀⨀⨀⨀⨀⨀⼀ 
SET ANSI_NULLS ON਀䜀伀 
SET QUOTED_IDENTIFIER ON਀䜀伀 
SET ANSI_PADDING ON਀䜀伀 
CREATE TABLE [dbo].[telecare_master](਀ऀ嬀甀猀攀爀开椀搀崀 嬀椀渀琀崀 䤀䐀䔀一吀䤀吀夀⠀㄀Ⰰ㄀⤀ 一伀吀 一唀䰀䰀Ⰰ 
	[user_name] [varchar](50) NULL,਀ऀ嬀甀猀攀爀开最攀渀搀攀爀崀 嬀瘀愀爀挀栀愀爀崀⠀㄀　⤀ 一唀䰀䰀Ⰰ 
	[user_age] [int] NULL,਀ऀ嬀甀猀攀爀开挀椀琀礀崀 嬀瘀愀爀挀栀愀爀崀⠀㔀　⤀ 一唀䰀䰀Ⰰ 
	[weight] [int] NULL,਀ऀ嬀猀琀攀瀀猀崀 嬀椀渀琀崀 一唀䰀䰀Ⰰ 
	[body_temp] [decimal](9, 2) NULL,਀ऀ嬀猀瀀漀㈀崀 嬀椀渀琀崀 一唀䰀䰀Ⰰ 
	[blood_prs_high] [int] NULL,਀ऀ嬀戀氀漀漀搀开瀀爀猀开氀漀眀崀 嬀椀渀琀崀 一唀䰀䰀Ⰰ 
	[motion] [varchar](50) NULL,਀ऀ嬀洀漀琀椀漀渀开戀攀搀爀漀漀洀崀 嬀瘀愀爀挀栀愀爀崀⠀㔀　⤀ 一唀䰀䰀Ⰰ 
	[motion_kitchen] [varchar](50) NULL,਀ऀ嬀洀漀琀椀漀渀开戀愀琀栀爀漀漀洀崀 嬀瘀愀爀挀栀愀爀崀⠀㔀　⤀ 一唀䰀䰀Ⰰ 
	[motion_piazza] [varchar](50) NULL,਀ऀ嬀琀攀洀瀀攀爀愀琀甀爀攀崀 嬀椀渀琀崀 一唀䰀䰀Ⰰ 
	[co] [int] NULL,਀ऀ嬀猀洀漀欀攀崀 嬀椀渀琀崀 一唀䰀䰀Ⰰ 
	[conditions] [varchar](1000) NULL,਀ऀ嬀愀氀氀攀爀最椀攀猀崀 嬀瘀愀爀挀栀愀爀崀⠀㄀　　　⤀ 一唀䰀䰀Ⰰ 
	[medications] [varchar](1000) NULL,਀ऀ嬀椀猀愀挀琀椀瘀攀崀 嬀椀渀琀崀 一唀䰀䰀 
) ON [PRIMARY]਀ 
GO਀匀䔀吀 䄀一匀䤀开倀䄀䐀䐀䤀一䜀 伀䘀䘀 
GO਀⼀⨀⨀⨀⨀⨀⨀ 伀戀樀攀挀琀㨀  吀愀戀氀攀 嬀搀戀漀崀⸀嬀眀攀椀最栀琀开洀愀猀琀攀爀崀    匀挀爀椀瀀琀 䐀愀琀攀㨀 ㈀㤀⼀䨀愀渀⼀㈀　㄀㔀 ㌀㨀㔀㔀㨀㌀㐀 䄀䴀 ⨀⨀⨀⨀⨀⨀⼀ 
SET ANSI_NULLS ON਀䜀伀 
SET QUOTED_IDENTIFIER ON਀䜀伀 
SET ANSI_PADDING ON਀䜀伀 
CREATE TABLE [dbo].[weight_master](਀ऀ嬀眀攀椀最栀琀开椀搀崀 嬀椀渀琀崀 䤀䐀䔀一吀䤀吀夀⠀㄀Ⰰ㄀⤀ 一伀吀 一唀䰀䰀Ⰰ 
	[user_id] [int] NULL,਀ऀ嬀眀攀椀最栀琀崀 嬀瘀愀爀挀栀愀爀崀⠀㔀　⤀ 一唀䰀䰀Ⰰ 
	[create_date] [datetime] NULL਀⤀ 伀一 嬀倀刀䤀䴀䄀刀夀崀 
਀䜀伀 
SET ANSI_PADDING OFF਀䜀伀 
SET IDENTITY_INSERT [dbo].[blood_master] ON ਀ 
INSERT [dbo].[blood_master] ([blood_id], [user_id], [low], [high], [exceed], [create_date]) VALUES (1, 1, 10, 80, 30, CAST(0x0000A42F001295C4 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀戀氀漀漀搀开洀愀猀琀攀爀崀 ⠀嬀戀氀漀漀搀开椀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀氀漀眀崀Ⰰ 嬀栀椀最栀崀Ⰰ 嬀攀砀挀攀攀搀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㈀Ⰰ ㄀Ⰰ 㔀Ⰰ 㔀　Ⰰ ㌀　Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㄀㈀䄀㌀䔀䔀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
INSERT [dbo].[blood_master] ([blood_id], [user_id], [low], [high], [exceed], [create_date]) VALUES (3, 1, 50, 130, 30, CAST(0x0000A42F0012AD69 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀戀氀漀漀搀开洀愀猀琀攀爀崀 ⠀嬀戀氀漀漀搀开椀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀氀漀眀崀Ⰰ 嬀栀椀最栀崀Ⰰ 嬀攀砀挀攀攀搀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㐀Ⰰ ㄀Ⰰ 㐀㔀Ⰰ ㄀　　Ⰰ ㌀　Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㄀㈀䈀䄀㘀䌀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
INSERT [dbo].[blood_master] ([blood_id], [user_id], [low], [high], [exceed], [create_date]) VALUES (6, 1, 72, 80, 30, CAST(0x0000A42F0012F210 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀戀氀漀漀搀开洀愀猀琀攀爀崀 ⠀嬀戀氀漀漀搀开椀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀氀漀眀崀Ⰰ 嬀栀椀最栀崀Ⰰ 嬀攀砀挀攀攀搀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㜀Ⰰ ㄀Ⰰ 㤀㈀Ⰰ ㄀㌀　Ⰰ ㌀　Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㄀㈀䘀䐀䄀䄀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
INSERT [dbo].[blood_master] ([blood_id], [user_id], [low], [high], [exceed], [create_date]) VALUES (8, 1, 65, 84, 30, CAST(0x0000A42F001305DE AS DateTime))਀匀䔀吀 䤀䐀䔀一吀䤀吀夀开䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀戀氀漀漀搀开洀愀猀琀攀爀崀 伀䘀䘀 
SET IDENTITY_INSERT [dbo].[body_temp_master] ON ਀ 
INSERT [dbo].[body_temp_master] ([body_tempId], [user_id], [body_temp], [create_date]) VALUES (1, 1, N'5         ', CAST(0x0000A42F002F6CE9 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀戀漀搀礀开琀攀洀瀀开洀愀猀琀攀爀崀 ⠀嬀戀漀搀礀开琀攀洀瀀䤀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀戀漀搀礀开琀攀洀瀀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㈀Ⰰ ㄀Ⰰ 一✀㐀         ✀Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㈀䘀㘀䌀䔀㤀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
INSERT [dbo].[body_temp_master] ([body_tempId], [user_id], [body_temp], [create_date]) VALUES (3, 1, N'8         ', CAST(0x0000A42F002F6CE9 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀戀漀搀礀开琀攀洀瀀开洀愀猀琀攀爀崀 ⠀嬀戀漀搀礀开琀攀洀瀀䤀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀戀漀搀礀开琀攀洀瀀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㐀Ⰰ ㄀Ⰰ 一✀㔀         ✀Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㈀䘀㘀䌀䔀㤀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
INSERT [dbo].[body_temp_master] ([body_tempId], [user_id], [body_temp], [create_date]) VALUES (5, 1, N'7         ', CAST(0x0000A42F002F6CE9 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀戀漀搀礀开琀攀洀瀀开洀愀猀琀攀爀崀 ⠀嬀戀漀搀礀开琀攀洀瀀䤀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀戀漀搀礀开琀攀洀瀀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㘀Ⰰ ㄀Ⰰ 一✀㌀         ✀Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㈀䘀㘀䌀䔀㤀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
INSERT [dbo].[body_temp_master] ([body_tempId], [user_id], [body_temp], [create_date]) VALUES (7, 1, N'4         ', CAST(0x0000A42F002F6CE9 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀戀漀搀礀开琀攀洀瀀开洀愀猀琀攀爀崀 ⠀嬀戀漀搀礀开琀攀洀瀀䤀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀戀漀搀礀开琀攀洀瀀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㠀Ⰰ ㄀Ⰰ 一✀㌀         ✀Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㈀䘀㘀䌀䔀㤀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
SET IDENTITY_INSERT [dbo].[body_temp_master] OFF਀匀䔀吀 䤀䐀䔀一吀䤀吀夀开䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀猀瀀漀㈀开洀愀猀琀攀爀崀 伀一  
਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀猀瀀漀㈀开洀愀猀琀攀爀崀 ⠀嬀猀瀀漀㈀开椀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀猀瀀漀㈀崀Ⰰ 嬀攀砀挀攀攀搀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㄀Ⰰ ㄀Ⰰ 一✀㔀㘀✀Ⰰ ㄀　　Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㌀㈀㌀䌀㈀㔀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
INSERT [dbo].[spo2_master] ([spo2_id], [user_id], [spo2], [exceed], [create_date]) VALUES (2, 1, N'56', 100, CAST(0x0000A42F00323C25 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀猀瀀漀㈀开洀愀猀琀攀爀崀 ⠀嬀猀瀀漀㈀开椀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀猀瀀漀㈀崀Ⰰ 嬀攀砀挀攀攀搀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㌀Ⰰ ㄀Ⰰ 一✀㔀㘀✀Ⰰ ㄀　　Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㌀㈀㌀䌀㈀㘀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
INSERT [dbo].[spo2_master] ([spo2_id], [user_id], [spo2], [exceed], [create_date]) VALUES (4, 1, N'56', 100, CAST(0x0000A42F00323C26 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀猀瀀漀㈀开洀愀猀琀攀爀崀 ⠀嬀猀瀀漀㈀开椀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀猀瀀漀㈀崀Ⰰ 嬀攀砀挀攀攀搀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㔀Ⰰ ㄀Ⰰ 一✀㔀㘀✀Ⰰ ㄀　　Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㌀㈀㌀䌀㈀㘀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
INSERT [dbo].[spo2_master] ([spo2_id], [user_id], [spo2], [exceed], [create_date]) VALUES (6, 1, N'56', 100, CAST(0x0000A42F00323C26 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀猀瀀漀㈀开洀愀猀琀攀爀崀 ⠀嬀猀瀀漀㈀开椀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀猀瀀漀㈀崀Ⰰ 嬀攀砀挀攀攀搀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㜀Ⰰ ㄀Ⰰ 一✀㔀㘀✀Ⰰ ㄀　　Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㌀㈀㌀䌀㈀㘀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
INSERT [dbo].[spo2_master] ([spo2_id], [user_id], [spo2], [exceed], [create_date]) VALUES (8, 1, N'56', 100, CAST(0x0000A42F00323C26 AS DateTime))਀匀䔀吀 䤀䐀䔀一吀䤀吀夀开䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀猀瀀漀㈀开洀愀猀琀攀爀崀 伀䘀䘀 
SET IDENTITY_INSERT [dbo].[steps_master] ON ਀ 
INSERT [dbo].[steps_master] ([steps_id], [user_id], [steps], [create_date]) VALUES (1, 1, N'50        ', CAST(0x0000A42F00278385 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀猀琀攀瀀猀开洀愀猀琀攀爀崀 ⠀嬀猀琀攀瀀猀开椀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀猀琀攀瀀猀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㈀Ⰰ ㄀Ⰰ 一✀㐀㈀        ✀Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㈀㜀㠀㌀㠀㘀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
INSERT [dbo].[steps_master] ([steps_id], [user_id], [steps], [create_date]) VALUES (3, 1, N'84        ', CAST(0x0000A42F00278386 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀猀琀攀瀀猀开洀愀猀琀攀爀崀 ⠀嬀猀琀攀瀀猀开椀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀猀琀攀瀀猀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㐀Ⰰ ㄀Ⰰ 一✀㔀㘀        ✀Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㈀㜀㠀㌀㠀㘀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
INSERT [dbo].[steps_master] ([steps_id], [user_id], [steps], [create_date]) VALUES (5, 1, N'72        ', CAST(0x0000A42F00278386 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀猀琀攀瀀猀开洀愀猀琀攀爀崀 ⠀嬀猀琀攀瀀猀开椀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀猀琀攀瀀猀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㘀Ⰰ ㄀Ⰰ 一✀㌀㔀        ✀Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㈀㜀㠀㌀㠀㘀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
INSERT [dbo].[steps_master] ([steps_id], [user_id], [steps], [create_date]) VALUES (7, 1, N'40        ', CAST(0x0000A42F00278386 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀猀琀攀瀀猀开洀愀猀琀攀爀崀 ⠀嬀猀琀攀瀀猀开椀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀猀琀攀瀀猀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㠀Ⰰ ㄀Ⰰ 一✀㌀㠀        ✀Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㈀㜀㠀㌀㠀㘀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
SET IDENTITY_INSERT [dbo].[steps_master] OFF਀匀䔀吀 䤀䐀䔀一吀䤀吀夀开䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀琀攀氀攀挀愀爀攀开洀愀猀琀攀爀崀 伀一  
਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀琀攀氀攀挀愀爀攀开洀愀猀琀攀爀崀 ⠀嬀甀猀攀爀开椀搀崀Ⰰ 嬀甀猀攀爀开渀愀洀攀崀Ⰰ 嬀甀猀攀爀开最攀渀搀攀爀崀Ⰰ 嬀甀猀攀爀开愀最攀崀Ⰰ 嬀甀猀攀爀开挀椀琀礀崀Ⰰ 嬀眀攀椀最栀琀崀Ⰰ 嬀猀琀攀瀀猀崀Ⰰ 嬀戀漀搀礀开琀攀洀瀀崀Ⰰ 嬀猀瀀漀㈀崀Ⰰ 嬀戀氀漀漀搀开瀀爀猀开栀椀最栀崀Ⰰ 嬀戀氀漀漀搀开瀀爀猀开氀漀眀崀Ⰰ 嬀洀漀琀椀漀渀崀Ⰰ 嬀洀漀琀椀漀渀开戀攀搀爀漀漀洀崀Ⰰ 嬀洀漀琀椀漀渀开欀椀琀挀栀攀渀崀Ⰰ 嬀洀漀琀椀漀渀开戀愀琀栀爀漀漀洀崀Ⰰ 嬀洀漀琀椀漀渀开瀀椀愀稀稀愀崀Ⰰ 嬀琀攀洀瀀攀爀愀琀甀爀攀崀Ⰰ 嬀挀漀崀Ⰰ 嬀猀洀漀欀攀崀Ⰰ 嬀挀漀渀搀椀琀椀漀渀猀崀Ⰰ 嬀愀氀氀攀爀最椀攀猀崀Ⰰ 嬀洀攀搀椀挀愀琀椀漀渀猀崀Ⰰ 嬀椀猀愀挀琀椀瘀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㄀Ⰰ 一✀愀渀椀氀✀Ⰰ 一✀䴀愀氀攀✀Ⰰ ㈀㔀Ⰰ 一✀洀甀洀戀愀椀✀Ⰰ 㜀㄀Ⰰ ㄀㌀Ⰰ 䌀䄀匀吀⠀㐀　⸀㄀　 䄀匀 䐀攀挀椀洀愀氀⠀㤀Ⰰ ㈀⤀⤀Ⰰ 㔀㘀Ⰰ 㤀　Ⰰ 㐀㔀Ⰰ 一✀㔀 搀愀礀猀 愀最漀✀Ⰰ 一✀琀漀搀愀礀 ㈀㨀㈀㘀瀀洀✀Ⰰ 一✀㈀ 搀愀礀猀 愀最漀✀Ⰰ 一✀㈀ 搀愀礀猀 愀最漀✀Ⰰ 一✀㌀ 搀愀礀猀 愀最漀✀Ⰰ ㈀㌀Ⰰ 㠀Ⰰ 　Ⰰ 一✀最漀漀搀 挀漀渀搀椀琀椀漀渀猀 最漀漀搀 挀漀渀搀椀琀椀漀渀猀 最漀漀搀 挀漀渀搀椀琀椀漀渀猀✀Ⰰ 一✀愀氀氀攀爀最椀攀猀 愀氀氀攀爀最椀攀猀 愀氀氀攀爀最椀攀猀 愀氀氀攀爀最椀攀猀✀Ⰰ 一✀琀愀欀攀 洀攀搀椀挀椀渀攀 愀渀搀 最漀 愀眀愀礀✀Ⰰ ㄀⤀ 
INSERT [dbo].[telecare_master] ([user_id], [user_name], [user_gender], [user_age], [user_city], [weight], [steps], [body_temp], [spo2], [blood_prs_high], [blood_prs_low], [motion], [motion_bedroom], [motion_kitchen], [motion_bathroom], [motion_piazza], [temperature], [co], [smoke], [conditions], [allergies], [medications], [isactive]) VALUES (2, N'Sunil Vishwakarma', N'Male', 24, N'15', NULL, NULL, NULL, 56, NULL, NULL, N'5 days ago', N'today 2:26pm', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀琀攀氀攀挀愀爀攀开洀愀猀琀攀爀崀 ⠀嬀甀猀攀爀开椀搀崀Ⰰ 嬀甀猀攀爀开渀愀洀攀崀Ⰰ 嬀甀猀攀爀开最攀渀搀攀爀崀Ⰰ 嬀甀猀攀爀开愀最攀崀Ⰰ 嬀甀猀攀爀开挀椀琀礀崀Ⰰ 嬀眀攀椀最栀琀崀Ⰰ 嬀猀琀攀瀀猀崀Ⰰ 嬀戀漀搀礀开琀攀洀瀀崀Ⰰ 嬀猀瀀漀㈀崀Ⰰ 嬀戀氀漀漀搀开瀀爀猀开栀椀最栀崀Ⰰ 嬀戀氀漀漀搀开瀀爀猀开氀漀眀崀Ⰰ 嬀洀漀琀椀漀渀崀Ⰰ 嬀洀漀琀椀漀渀开戀攀搀爀漀漀洀崀Ⰰ 嬀洀漀琀椀漀渀开欀椀琀挀栀攀渀崀Ⰰ 嬀洀漀琀椀漀渀开戀愀琀栀爀漀漀洀崀Ⰰ 嬀洀漀琀椀漀渀开瀀椀愀稀稀愀崀Ⰰ 嬀琀攀洀瀀攀爀愀琀甀爀攀崀Ⰰ 嬀挀漀崀Ⰰ 嬀猀洀漀欀攀崀Ⰰ 嬀挀漀渀搀椀琀椀漀渀猀崀Ⰰ 嬀愀氀氀攀爀最椀攀猀崀Ⰰ 嬀洀攀搀椀挀愀琀椀漀渀猀崀Ⰰ 嬀椀猀愀挀琀椀瘀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㌀Ⰰ 一✀瘀椀欀愀猀✀Ⰰ 一✀䴀愀氀攀✀Ⰰ ㈀㐀Ⰰ 一✀㈀✀Ⰰ 一唀䰀䰀Ⰰ 一唀䰀䰀Ⰰ 一唀䰀䰀Ⰰ 㔀㘀Ⰰ 一唀䰀䰀Ⰰ 一唀䰀䰀Ⰰ 一✀㔀 搀愀礀猀 愀最漀✀Ⰰ 一✀琀漀搀愀礀 ㈀㨀㈀㘀瀀洀✀Ⰰ 一唀䰀䰀Ⰰ 一唀䰀䰀Ⰰ 一唀䰀䰀Ⰰ 一唀䰀䰀Ⰰ 一唀䰀䰀Ⰰ 一唀䰀䰀Ⰰ 一✀琀栀椀猀 椀猀 搀甀洀洀礀 挀漀渀搀琀椀漀渀✀Ⰰ 一✀栀攀氀氀漀 愀氀氀攀爀最椀攀猀✀Ⰰ 一✀洀礀 渀愀洀攀 椀猀 欀栀愀渀✀Ⰰ 一唀䰀䰀⤀ 
INSERT [dbo].[telecare_master] ([user_id], [user_name], [user_gender], [user_age], [user_city], [weight], [steps], [body_temp], [spo2], [blood_prs_high], [blood_prs_low], [motion], [motion_bedroom], [motion_kitchen], [motion_bathroom], [motion_piazza], [temperature], [co], [smoke], [conditions], [allergies], [medications], [isactive]) VALUES (5, N'dsfdsds', N'Male', 43, N'0', NULL, NULL, NULL, 56, NULL, NULL, N'5 days ago', N'today 2:26pm', NULL, NULL, NULL, NULL, NULL, NULL, N'fdsfd', N'sfsdf', N'dsfds', 1)਀匀䔀吀 䤀䐀䔀一吀䤀吀夀开䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀琀攀氀攀挀愀爀攀开洀愀猀琀攀爀崀 伀䘀䘀 
SET IDENTITY_INSERT [dbo].[weight_master] ON ਀ 
INSERT [dbo].[weight_master] ([weight_id], [user_id], [weight], [create_date]) VALUES (1, 1, N'50', CAST(0x0000A42F001837F8 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀眀攀椀最栀琀开洀愀猀琀攀爀崀 ⠀嬀眀攀椀最栀琀开椀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀眀攀椀最栀琀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㈀Ⰰ ㄀Ⰰ 一✀㐀㈀✀Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㄀㠀㌀㜀䘀㠀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
INSERT [dbo].[weight_master] ([weight_id], [user_id], [weight], [create_date]) VALUES (3, 1, N'84', CAST(0x0000A42F001837F9 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀眀攀椀最栀琀开洀愀猀琀攀爀崀 ⠀嬀眀攀椀最栀琀开椀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀眀攀椀最栀琀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㐀Ⰰ ㄀Ⰰ 一✀㔀㘀✀Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㄀㠀㌀㜀䘀㤀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
INSERT [dbo].[weight_master] ([weight_id], [user_id], [weight], [create_date]) VALUES (5, 1, N'72', CAST(0x0000A42F001837F9 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀眀攀椀最栀琀开洀愀猀琀攀爀崀 ⠀嬀眀攀椀最栀琀开椀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀眀攀椀最栀琀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㘀Ⰰ ㄀Ⰰ 一✀㌀㔀✀Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㄀㠀㌀㜀䘀㤀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
INSERT [dbo].[weight_master] ([weight_id], [user_id], [weight], [create_date]) VALUES (7, 1, N'40', CAST(0x0000A42F001837F9 AS DateTime))਀䤀一匀䔀刀吀 嬀搀戀漀崀⸀嬀眀攀椀最栀琀开洀愀猀琀攀爀崀 ⠀嬀眀攀椀最栀琀开椀搀崀Ⰰ 嬀甀猀攀爀开椀搀崀Ⰰ 嬀眀攀椀最栀琀崀Ⰰ 嬀挀爀攀愀琀攀开搀愀琀攀崀⤀ 嘀䄀䰀唀䔀匀 ⠀㠀Ⰰ ㄀Ⰰ 一✀㌀㠀✀Ⰰ 䌀䄀匀吀⠀　砀　　　　䄀㐀㈀䘀　　㄀㠀㌀㜀䘀㤀 䄀匀 䐀愀琀攀吀椀洀攀⤀⤀ 
SET IDENTITY_INSERT [dbo].[weight_master] OFF਀唀匀䔀 嬀洀愀猀琀攀爀崀 
GO਀䄀䰀吀䔀刀 䐀䄀吀䄀䈀䄀匀䔀 嬀吀攀氀攀䌀愀爀攀崀 匀䔀吀  刀䔀䄀䐀开圀刀䤀吀䔀  
GO਀�