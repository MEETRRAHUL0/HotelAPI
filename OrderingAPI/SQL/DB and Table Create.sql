﻿CREATE DATABASE [Hotal]

go

USE [Hotal]
USE rest_pro
GO

/****** Object:  Table [dbo].[OrderDetails]    Script Date: 9/21/2021 3:41:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RefID] [nvarchar](100) NULL,
	[APIKey] [nvarchar](100) NULL,
	[OrderId] [nvarchar](100) NULL,
	[Otp] [nvarchar](100) NULL,
	[OrderDate] [nvarchar](100) NULL,
	[OrderTime] [nvarchar](100) NULL,
	[GuestName] [nvarchar](100) NULL,
	[Phone] [nvarchar](100) NULL,
	[ItemId] [nvarchar](100) NULL,
	[ItemName] [nvarchar](100) NULL,
	[GST] [nvarchar](100) NULL,
	[Qty] [nvarchar](100) NULL,
	[TotalBill] [nvarchar](50) NULL,
	[Discount] [nvarchar](50) NULL,
	[DiscountPercentage] [nvarchar](50) NULL,
	[NetBIll] [nvarchar](50) NULL,
	[OrderStatus] [nvarchar](50) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


