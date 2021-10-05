

CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,

	customer_phone [nvarchar](100) NULL,
	customer_address [nvarchar](MAX) NULL,
	customer_email [nvarchar](100) NULL,
	customer_name [nvarchar](100) NULL,

	next_state [nvarchar](100) NULL,

	store_name [nvarchar](100) NULL,
	store_longitude [nvarchar](100) NULL,
	store_merchant_ref_id [nvarchar](100) NULL,
	store_address [nvarchar](100) NULL,
	store_latitude [nvarchar](100) NULL,
	store_id [nvarchar](100) NULL,

	coupon [nvarchar](100) NULL,  -- ,
	total_taxes [nvarchar](100) NULL,  -- 37.54,
	merchant_ref_id [nvarchar](100) NULL,  -- null,
	order_level_total_charges [nvarchar](100) NULL,  -- 40,
	Order_id [nvarchar](100) NULL,  -- 524956,
	payable_amount [nvarchar](100) NULL,  -- 868.44,
	total_external_discount [nvarchar](100) NULL,  -- 0,
	order_total [nvarchar](100) NULL,  -- 868.44,
	order_type [nvarchar](100) NULL,  -- delivery,
	[state] [nvarchar](100) NULL,  -- Placed,
	modified_from [nvarchar](100) NULL,  -- null,
	channel [nvarchar](100) NULL,  -- satellite,
	delivery_datetime [nvarchar](100) NULL,  -- 1633280219000,
	item_level_total_charges [nvarchar](100) NULL,  -- 40,
	item_taxes [nvarchar](100) NULL,  -- 37.54,
	modified_to [nvarchar](100) NULL,  -- null,
	item_level_total_taxes [nvarchar](100) NULL,  -- 37.54,
	biz_id [nvarchar](100) NULL,  -- 40683216,
	order_state [nvarchar](100) NULL,  -- Placed,
	instructions [nvarchar](100) NULL,  -- note\nPayment Method: paytm,
	total_charges [nvarchar](100) NULL,  -- 80,

	discount [nvarchar](100) NULL,  -- 0,

	created [nvarchar](100) NULL,  -- 1633278495895,

	order_level_total_taxes [nvarchar](100) NULL,  -- 0,
	order_subtotal [nvarchar](100) NULL,  -- 750.9
	dash_config_auto_assign [nvarchar](100) NULL,  -- false,
	dash_config_enabled [nvarchar](100) NULL,  -- false

	OrderJSON [nvarchar](MAX) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




CREATE TABLE [dbo].[Items](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	Order_id [nvarchar](100) NULL,  -- 524956,

					image_url [nvarchar](100) NULL,
				total [nvarchar](100) NULL,  --  750.9,
				title [nvarchar](100) NULL,  --  Veg Biryani,
				 total_with_tax [nvarchar](100) NULL,  --  828.44,
				price [nvarchar](100) NULL,  --  125.44999999999999,
				translations [nvarchar](100) NULL,  --  null,
				unit_weight [nvarchar](100) NULL,  --  500,
				discount [nvarchar](100) NULL,  --  0,
				image_landscape_url [nvarchar](100) NULL,  --  null,
				food_type [nvarchar](100) NULL,  --  1,
				merchant_id [nvarchar](100) NULL,  --  I-1,
			   ItemId [nvarchar](100) NULL,  --  722927,
				quantity [nvarchar](100) NULL,  --  2


 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




CREATE TABLE [dbo].Payment(
	[ID] [int] IDENTITY(1,1) NOT NULL,
	Order_id [nvarchar](100) NULL,  -- 524956,

					amount [nvarchar](100) NULL,
				[option] [nvarchar](100) NULL,  --  750.9,
				srvr_trx_id [nvarchar](100) NULL,  --  Veg Biryani,



 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




CREATE TABLE [dbo].charges(
	[ID] [int] IDENTITY(1,1) NOT NULL,
	Order_id [nvarchar](100) NULL,  -- 524956,

					[Type] [nvarchar](100) NULL, -- Item Chanrge or Order chrarge
				value [nvarchar](100) NULL,  --  750.9,
				title [nvarchar](100) NULL,  --  Veg Biryani,



 CONSTRAINT [PK_charges] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




CREATE TABLE [dbo].taxes(
	[ID] [int] IDENTITY(1,1) NOT NULL,
	Order_id [nvarchar](100) NULL,  -- 524956,

					[Type] [nvarchar](100) NULL, -- Item Chanrge or Order chrarge
				value [nvarchar](100) NULL,  --  750.9,
				title [nvarchar](100) NULL,  --  Veg Biryani,
				rate [nvarchar](100) NULL,  --  Veg Biryani,



 CONSTRAINT [PK_taxes] PRIMARY KEY CLUSTERED
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


