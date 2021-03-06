USE [SHOP]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 4/4/2019 10:44:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[customer_id] [varchar](10) NOT NULL,
	[customer_name] [varchar](100) NULL,
	[email_address] [varchar](50) NULL,
	[phone_number] [varchar](10) NULL,
	[address] [varchar](100) NULL,
	[login_name] [varchar](20) NULL,
	[login_password] [varchar](10) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 4/4/2019 10:44:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[employee_id] [varchar](10) NOT NULL,
	[employee_password] [varchar](10) NULL,
	[employee_status] [bit] NULL,
	[employee_name] [varchar](50) NULL,
	[email_address] [varchar](50) NULL,
	[phone_number] [varchar](10) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Footer]    Script Date: 4/4/2019 10:44:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footer](
	[FooterID] [int] NOT NULL,
	[Contain] [varchar](50) NULL,
	[Status] [bit] NULL,
	[FooterIDType] [int] NULL,
	[FooterParentID] [int] NULL,
	[Link] [varchar](max) NULL,
	[Target] [varchar](50) NULL,
 CONSTRAINT [PK_Footer] PRIMARY KEY CLUSTERED 
(
	[FooterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 4/4/2019 10:44:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[invoice_number] [varchar](10) NOT NULL,
	[order_id] [varchar](10) NULL,
	[invoice_date] [date] NULL,
	[invoice_status_code] [int] NULL,
	[invoice_total_money] [real] NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[invoice_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menu]    Script Date: 4/4/2019 10:44:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuID] [int] NOT NULL,
	[Text] [nvarchar](300) NULL,
	[Link] [nvarchar](250) NULL,
	[DisplayOrder] [int] NULL,
	[Target] [nvarchar](250) NULL,
	[Status] [bit] NULL,
	[MenuTypeID] [int] NULL,
	[MenuParentID] [int] NULL,
	[Icon] [varchar](50) NULL,
	[Properti] [varchar](50) NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order_items]    Script Date: 4/4/2019 10:44:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_items](
	[order_item_id] [varchar](10) NOT NULL,
	[order_id] [varchar](10) NULL,
	[product_id] [varchar](10) NULL,
	[order_item_status_code] [int] NULL,
	[order_item_quantity] [int] NULL,
	[order_item_price] [real] NULL,
 CONSTRAINT [PK_Order_items] PRIMARY KEY CLUSTERED 
(
	[order_item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 4/4/2019 10:44:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[order_id] [varchar](10) NOT NULL,
	[customer_id] [varchar](10) NULL,
	[date_order] [date] NULL,
	[order_place] [varchar](100) NULL,
	[order_note] [nvarchar](100) NULL,
	[total_price] [money] NULL,
	[order_status_code] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payments]    Script Date: 4/4/2019 10:44:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[payment_id] [varchar](10) NOT NULL,
	[invoice_number] [varchar](10) NULL,
	[payment_date] [date] NULL,
	[payment_amount] [real] NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[payment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 4/4/2019 10:44:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[product_id] [varchar](10) NOT NULL,
	[product_type_code] [varchar](10) NULL,
	[product_name] [varchar](max) NULL,
	[product_price] [real] NULL,
	[product_description] [nvarchar](max) NULL,
	[product_size] [varchar](max) NULL,
	[product_color] [varchar](max) NULL,
	[product_imge] [varchar](max) NULL,
	[more_image] [xml] NULL,
	[createddate] [datetime] NULL,
	[promotionprice] [real] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ref_Invoice_Status_Codes]    Script Date: 4/4/2019 10:44:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ref_Invoice_Status_Codes](
	[invoice_status_code] [int] NOT NULL,
	[invoice_status_description] [varchar](50) NULL,
 CONSTRAINT [PK_Ref_Invoice_Status_Codes] PRIMARY KEY CLUSTERED 
(
	[invoice_status_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ref_Order_Item_Status_Codes]    Script Date: 4/4/2019 10:44:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ref_Order_Item_Status_Codes](
	[order_item_status_code] [int] NOT NULL,
	[order_item_status_description] [varchar](50) NULL,
 CONSTRAINT [PK_Ref_Order_Item_Status_Codes] PRIMARY KEY CLUSTERED 
(
	[order_item_status_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ref_Order_Status_Codes]    Script Date: 4/4/2019 10:44:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ref_Order_Status_Codes](
	[order_status_code] [int] NOT NULL,
	[order_status_decription] [varchar](50) NULL,
 CONSTRAINT [PK_Ref_Order_Status_Codes] PRIMARY KEY CLUSTERED 
(
	[order_status_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ref_Product_Types]    Script Date: 4/4/2019 10:44:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ref_Product_Types](
	[product_type_code] [varchar](10) NOT NULL,
	[product_type_description] [varchar](max) NULL,
 CONSTRAINT [PK_Ref_Product_Types] PRIMARY KEY CLUSTERED 
(
	[product_type_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Shipment_Items]    Script Date: 4/4/2019 10:44:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipment_Items](
	[shipment_id] [varchar](10) NOT NULL,
	[order_item_id] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Shipment_Items] PRIMARY KEY CLUSTERED 
(
	[shipment_id] ASC,
	[order_item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Shipments]    Script Date: 4/4/2019 10:44:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipments](
	[shipment_id] [varchar](10) NOT NULL,
	[order_id] [varchar](10) NULL,
	[invoice_number] [varchar](10) NULL,
	[shipment_date] [date] NULL,
	[shipment_tracking_number] [int] NULL,
 CONSTRAINT [PK_Shipments] PRIMARY KEY CLUSTERED 
(
	[shipment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slider]    Script Date: 4/4/2019 10:44:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[ID] [int] NOT NULL,
	[Image] [nvarchar](250) NULL,
	[DisplayOrder] [int] NULL,
	[Link] [nvarchar](250) NULL,
	[Description] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[Status] [bit] NULL,
	[Priority] [varchar](50) NULL,
 CONSTRAINT [PK_Slider] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Customers] ([customer_id], [customer_name], [email_address], [phone_number], [address], [login_name], [login_password]) VALUES (N'1', N'haohao', N'nam99@gmail.com', N'0966666666', N'TP HCM', N'nam', N'123')
INSERT [dbo].[Customers] ([customer_id], [customer_name], [email_address], [phone_number], [address], [login_name], [login_password]) VALUES (N'181426', N'Soai Vuong', N'vuong@gmail.com', NULL, NULL, N'vuong@gmail.com', N'123456')
INSERT [dbo].[Employees] ([employee_id], [employee_password], [employee_status], [employee_name], [email_address], [phone_number]) VALUES (N'1', N'123', 1, N'linh', N'linh@gmail.com', N'122')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (1, N'Get to Know Us', 1, 1, NULL, N'#', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (2, N'Make Money with Us', 1, 1, NULL, N'#', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (3, N'Amazon Payment Products', 1, 1, NULL, N'#', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (4, N'Let Us Help You', 1, 1, NULL, N'#', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (5, N'Careers', 1, 2, 1, N'#', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (6, N'Blog', 1, 2, 1, N'#', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (7, N'About Amazon', 1, 2, 1, N'#', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (8, N'Investor Relations', 1, 2, 1, N'#', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (9, N'Amazon Devices
', 1, 2, 1, N'#', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (10, N'Sell on Amazon', 1, 2, 2, N'https://services.amazon.com/content/sell-on-amazon.htm/ref=footer_soa?ld=AZFSSOA', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (11, N'Sell Your Services on Amazon', 1, 2, 2, N'https://services.amazon.com/selling-services/home.html?ld=AZUSVAS-globalfooter', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (12, N'Sell on Amazon Business', 1, 2, 2, N'https://services.amazon.com/amazon-business.html?ld=usb2bunifooter', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (13, N'Sell Your Apps on Amazon', 1, 2, 2, N'https://developer.amazon.com/', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (14, N'Become an Affiliate', 1, 2, 2, N'https://affiliate-program.amazon.com/', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (15, N'Advertise Your Products', 1, 2, 2, N'https://advertising.amazon.com/?ref=ext_amzn_ftr', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (16, N'Self-Publish with Us', 1, 2, 2, N'https://www.amazon.com/gp/seller-account/mm-summary-page.html/ref=footer_publishing?ie=UTF8&ld=AZFooterSelfPublish&topic=200260520', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (17, N'Amazon Business Card', 1, 2, 3, N'https://www.amazon.com/dp/B07984JN3L?_encoding=UTF8&ie=UTF-8&plattr=ACOMFO', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (18, N'Shop with Points', 1, 2, 3, N'https://www.amazon.com/b/ref=footer_swp?ie=UTF8&node=16218619011', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (19, N'Reload Your Balance', 1, 2, 3, N'https://www.amazon.com/Reload-Your-Gift-Card-Balance/b/ref=footer_reload_us?ie=UTF8&node=10232440011', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (20, N'Amazon Currency Converter', 1, 2, 3, N'https://www.amazon.com/Currency-Converter/b/ref=footer_tfx?ie=UTF8&node=388305011', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (21, N'Your Account', 1, 2, 4, N'https://www.amazon.com/gp/css/homepage.html/ref=footer_ya', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (22, N'Your Orders', 1, 2, 4, N'#', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (23, N'Shipping Rates & Policies', 1, 2, 4, N'https://www.amazon.com/gp/help/customer/display.html/ref=footer_shiprates?ie=UTF8&nodeId=468520', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (24, N'Returns & Replacements', 1, 2, 4, N'https://www.amazon.com/gp/orc/returns/homepage.html/ref=orc_surl_ret_hp?fg=1', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (25, N'Manage Your Content and Devices', 1, 2, 4, N'#', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (26, N'Amazon Assistant', 1, 2, 4, N'#', N'_self')
INSERT [dbo].[Footer] ([FooterID], [Contain], [Status], [FooterIDType], [FooterParentID], [Link], [Target]) VALUES (27, N'Help', 1, 2, 4, N'#', N'_self')
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (1, N'Delivery to', N'#', 1, N'_self', 1, 1, 0, N'glyphicon glyphicon-map-marker', N'dropdown')
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (2, N'Departments', N'#', 2, N'_self', 1, 1, 0, N'caret', N'dropdown')
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (3, N'Browsing History', N'#', 3, N'_self', 1, 1, 0, N'caret', NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (4, N'Your Amazon.com', N'#', 4, N'_self', 1, 1, 0, NULL, NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (5, N'Today''s Deals', N'#', 5, N'_self', 1, 1, 0, NULL, NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (6, N'Gift Cards', N'#', 6, N'_self', 1, 1, 0, NULL, NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (7, N'Hello, name Account & Lists', N'#', 7, N'_self', 1, 1, 0, N'caret', N'dropdown')
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (8, N'Orders', N'#', 8, N'_self', 1, 1, 0, NULL, NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (9, N'Cart', N'Cart', 9, N'_self', 1, 1, 0, N'glyphicon glyphicon-shopping-cart', N'')
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (10, N'Austrailia', N'#', 1, N'_self', 1, 2, 1, NULL, NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (11, N'Canada', N'#', 2, N'_self', 1, 2, 1, NULL, NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (12, N'China', N'#', 3, N'_self', 1, 2, 1, NULL, NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (13, N'Japan', N'#', 4, N'_self', 1, 2, 1, NULL, NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (14, N'Smartphone', N'Product?typeID=1', 1, N'_self', 1, 2, 2, N'fas fa-mobile-alt', NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (15, N'Network', N'Product?typeID=2', 2, N'_self', 1, 2, 2, N'fas fa-wifi', NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (16, N'Digital Music', N'#', 3, N'_self', 1, 2, 2, N'fas fa-music', NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (17, N'Sign in', N'User/Login', 1, N'_self', 1, 2, 7, N'fas fa-sign-in-alt', NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (18, N'Sign out', N'Home', 2, N'_self', 1, 2, 7, N'fas fa-sign-out-alt', NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (19, N'New customer ?', N'User/Regist', 3, N'_self', 1, 2, 7, N'fas fa-external-link-alt', NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (20, N'Forget passwprd', N'#', 4, N'_self', 1, 2, 7, N'fab fa-gofore', NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (21, N'Your Information', N'#', 5, N'_self', 1, 2, 7, N'far fa-user', NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (22, N'Fashion', N'Product?typeID=4', 4, N'_self', 1, 2, 2, N'fas fa-tshirt', NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (23, N'Book', N'Product?typeID=5', 5, N'_self', 1, 2, 2, N'fas fa-book', NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (24, N'Vietnam', N'#', 5, N'_self', 1, 2, 1, NULL, NULL)
INSERT [dbo].[Menu] ([MenuID], [Text], [Link], [DisplayOrder], [Target], [Status], [MenuTypeID], [MenuParentID], [Icon], [Properti]) VALUES (25, N'Entertaiment', N'Product?typeID=3', 6, N'_self', 1, 2, 2, NULL, NULL)
INSERT [dbo].[Products] ([product_id], [product_type_code], [product_name], [product_price], [product_description], [product_size], [product_color], [product_imge], [more_image], [createddate], [promotionprice]) VALUES (N'1', N'1', N'Samsung S8', 1000, N'Body: Polished aluminum frame, Gorilla Glass 5 front and rear; IP68 certified for water and dust resistance. Arctic Silver, Orchid Grey, Black Sky, Maple Gold, and Coral Blue color schemes. Display: 5.8" Super AMOLED, 2,960x1440px resolution, 18.5:9 (2.06:1) aspect ratio, 570ppi; HDR 10 compliant (no Dolby Vision). Rear camera:12MP, f/1.7 aperture, dual pixel phase detection autofocus, OIS; multi-shot image stacking; 2160p/30fps video recording. Front camera: 8MP, f/1.7 aperture, autofocus; 1440p/30fps video recording. OS/Software: Android 7.0 Nougat; Bixby virtual assistant. Chipsets: Qualcomm Snapdragon 835: octa-core CPU (4xKryo 280 + 4xCortex-A53), Adreno 540 GPU. Exynos 8895: octa-core CPU (4x2nd-gen Mongoose + 4xCortex-A53), Mali-G71 GPU. Memory: 4GB of RAM (a 6GB option likely in some markets, later down the line); 64GB of storage; microSD slot up to 256GB, UFS cards support. Battery: 3,000mAh Li-Ion (sealed); Adaptive Fast Charging (same as S7); QuickCharge 2.0 support; WPC&PMA wireless charging. Connectivity: Single-SIM, Dual-SIM available in certain markets; LTE-A, 4-Band carrier aggregation, Cat.16/13 (1Gbps/150Mbps); USB Type-C (v3.1); Wi-Fi a/b/g/n/ac; GPS, Beidou, Galileo; NFC; Bluetooth 5.0. Misc: Fingerprint reader; iris recognition/face recognition; single speaker on the bottom; 3.5mm jack; bundled AKG headphones.', NULL, N'Black', N'/Upload/image/product/images/samsungs8.jpg', N'<Images><Image>/Upload/image/product/images/samsungs7.jpg</Image></Images>', CAST(N'2019-03-06T14:54:51.000' AS DateTime), NULL)
INSERT [dbo].[Products] ([product_id], [product_type_code], [product_name], [product_price], [product_description], [product_size], [product_color], [product_imge], [more_image], [createddate], [promotionprice]) VALUES (N'10', N'1', N'Iphone 6S', 18000, N'NETWORK	Technology GSM / CDMA / HSPA / EVDO / LTE LAUNCH	Announced	2013, September Status	Available. Released 2013, September BODY	Dimensions	123.8 x 58.6 x 7.6 mm (4.87 x 2.31 x 0.30 in) Weight	112 g (3.95 oz) Build	Front glass, aluminum body SIM	Nano-SIM DISPLAY	Type	LED-backlit IPS LCD, capacitive touchscreen, 16M colors Size	4.0 inches, 44.1 cm2 (~60.8% screen-to-body ratio) Resolution	640 x 1136 pixels, 16:9 ratio (~326 ppi density) Protection	Corning Gorilla Glass, oleophobic coating PLATFORM	OS	iOS 7, upgradable to iOS 12.1.3 Chipset	Apple A7 (28 nm) CPU	Dual-core 1.3 GHz Cyclone (ARM v8-based) GPU	PowerVR G6430 (quad-core graphics) MEMORY	Card slot	No Internal	16/32/64 GB, 1 GB RAM DDR3 MAIN CAMERA	Single	8 MP, f/2.2, 29mm (standard), 1/3", 1.5µm, AF Features	Dual-LED dual-tone flash, HDR Video	1080p@30fps, 720p@120fps SELFIE CAMERA	Single	1.2 MP, f/2.4, 31mm (standard) Features	face detection, HDR, FaceTime over Wi-Fi or Cellular Video	720p@30fps SOUND	Loudspeaker	Yes 3.5mm jack	Yes  	- 16-bit/44.1k', NULL, N'While', N'/Upload/image/product/images/Iphone6s.jpg', N'<Images><Image>/Upload/image/product/images/vaynu1.png</Image></Images>', CAST(N'2019-03-06T15:30:27.000' AS DateTime), NULL)
INSERT [dbo].[Products] ([product_id], [product_type_code], [product_name], [product_price], [product_description], [product_size], [product_color], [product_imge], [more_image], [createddate], [promotionprice]) VALUES (N'11', N'3', N'Gampad', 1000000, N'NETWORK	Technology	 GSM / CDMA / HSPA / EVDO / LTE LAUNCH	Announced	2013, September Status	Available. Released 2013, September BODY	Dimensions	123.8 x 58.6 x 7.6 mm (4.87 x 2.31 x 0.30 in) Weight	112 g (3.95 oz) Build	Front glass, aluminum body SIM	Nano-SIM DISPLAY	Type	LED-backlit IPS LCD, capacitive touchscreen, 16M colors Size	4.0 inches, 44.1 cm2 (~60.8% screen-to-body ratio) Resolution	640 x 1136 pixels, 16:9 ratio (~326 ppi density) Protection	Corning Gorilla Glass, oleophobic coating PLATFORM	OS	iOS 7, upgradable to iOS 12.1.3 Chipset	Apple A7 (28 nm) CPU	Dual-core 1.3 GHz Cyclone (ARM v8-based) GPU	PowerVR G6430 (quad-core graphics) MEMORY	Card slot	No Internal	16/32/64 GB, 1 GB RAM DDR3 MAIN CAMERA	Single	8 MP, f/2.2, 29mm (standard), 1/3", 1.5µm, AF Features	Dual-LED dual-tone flash, HDR Video	1080p@30fps, 720p@120fps SELFIE CAMERA	Single	1.2 MP, f/2.4, 31mm (standard) Features	face detection, HDR, FaceTime over Wi-Fi or Cellular Video	720p@30fps SOUND	Loudspeaker	Yes 3.5mm jack	Yes  	- 16-bit/44.1k', NULL, N'Black', N'/Upload/image/product/images/gamepad.jpg', NULL, CAST(N'2019-03-06T15:34:40.000' AS DateTime), NULL)
INSERT [dbo].[Products] ([product_id], [product_type_code], [product_name], [product_price], [product_description], [product_size], [product_color], [product_imge], [more_image], [createddate], [promotionprice]) VALUES (N'12', N'3', N'Game Spider Man', 1000, N'Game', NULL, NULL, N'/Upload/image/product/images/Game_spider.jpg', NULL, CAST(N'2019-03-06T17:13:24.000' AS DateTime), NULL)
INSERT [dbo].[Products] ([product_id], [product_type_code], [product_name], [product_price], [product_description], [product_size], [product_color], [product_imge], [more_image], [createddate], [promotionprice]) VALUES (N'2', N'1', N'Iphone 5', 1000000, N'NETWORK	Technology	 GSM / CDMA / HSPA / EVDO / LTE LAUNCH	Announced	2013, September Status	Available. Released 2013, September BODY	Dimensions	123.8 x 58.6 x 7.6 mm (4.87 x 2.31 x 0.30 in) Weight	112 g (3.95 oz) Build	Front glass, aluminum body SIM	Nano-SIM DISPLAY	Type	LED-backlit IPS LCD, capacitive touchscreen, 16M colors Size	4.0 inches, 44.1 cm2 (~60.8% screen-to-body ratio) Resolution	640 x 1136 pixels, 16:9 ratio (~326 ppi density) Protection	Corning Gorilla Glass, oleophobic coating PLATFORM	OS	iOS 7, upgradable to iOS 12.1.3 Chipset	Apple A7 (28 nm) CPU	Dual-core 1.3 GHz Cyclone (ARM v8-based) GPU	PowerVR G6430 (quad-core graphics) MEMORY	Card slot	No Internal	16/32/64 GB, 1 GB RAM DDR3 MAIN CAMERA	Single	8 MP, f/2.2, 29mm (standard), 1/3", 1.5µm, AF Features	Dual-LED dual-tone flash, HDR Video	1080p@30fps, 720p@120fps SELFIE CAMERA	Single	1.2 MP, f/2.4, 31mm (standard) Features	face detection, HDR, FaceTime over Wi-Fi or Cellular Video	720p@30fps SOUND	Loudspeaker	Yes 3.5mm jack	Yes  	- 16-bit/44.1kHz audio - Active noise cancellation with dedicated mic COMMS	WLAN	Wi-Fi 802.11 a/b/g/n, dual-band, hotspot Bluetooth	4.0, A2DP GPS	Yes, with A-GPS, GLONASS Radio	No USB	2.0, proprietary reversible connector FEATURES	Sensors	Fingerprint (front-mounted), accelerometer, gyro, proximity, compass  	- Siri natural language commands and dictation BATTERY	 	Non-removable Li-Po 1560 mAh battery (5.92 Wh) Stand-by	Up to 250 h (2G) / Up to 250 h (3G) Talk time	Up to 10 h (2G) / Up to 10 h (3G) Music play	Up to 40 h MISC	Colors	Space Gray, White/Silver, Gold SAR	1.12 W/kg (head)     1.18 W/kg (body)     SAR EU	1.00 W/kg (head)     0.80 W/kg (body)     Price	About 330 EUR TESTS	Performance	Basemark OS II: 1077 / Basemark X: 14341 Display	Contrast ratio: 1219:1 (nominal) / 3.565:1 (sunlight) Camera	Photo / Video Loudspeaker	Voice 68dB / Noise 66dB / Ring 69dB Audio quality	Noise -93.6dB / Crosstalk -90.3dB Battery life	 Endurance rating 54h', NULL, N'Whiite', N'/Upload/image/product/images/iphone5.jpg', NULL, CAST(N'2019-03-06T15:02:19.000' AS DateTime), NULL)
INSERT [dbo].[Products] ([product_id], [product_type_code], [product_name], [product_price], [product_description], [product_size], [product_color], [product_imge], [more_image], [createddate], [promotionprice]) VALUES (N'3', N'1', N'Samsung S7', 9000000, N'NETWORK	Technology	 GSM / HSPA / LTE LAUNCH	Announced	2016, February Status	Available. Released 2016, March BODY	Dimensions	142.4 x 69.6 x 7.9 mm (5.61 x 2.74 x 0.31 in) Weight	152 g (5.36 oz) Build	Front/back glass (Gorilla Glass 4), aluminum frame SIM	Single SIM (Nano-SIM) - G930F Hybrid Dual SIM (Nano-SIM, dual stand-by) - G930FD  	- Samsung Pay (Visa, MasterCard certified) - IP68 dust/water proof (up to 1.5m for 30 mins) DISPLAY	Type	Super AMOLED capacitive touchscreen, 16M colors Size	5.1 inches, 71.5 cm2 (~72.1% screen-to-body ratio) Resolution	1440 x 2560 pixels, 16:9 ratio (~577 ppi density) Protection	Corning Gorilla Glass 4  	- Always-on display PLATFORM	OS	Android 6.0 (Marshmallow), upgradable to Android 8.0 (Oreo); TouchWiz UI Chipset	Exynos 8890 Octa (14 nm) CPU	Octa-core (4x2.3 GHz Mongoose & 4x1.6 GHz Cortex-A53) GPU	Mali-T880 MP12 MEMORY	Card slot	microSD, up to 256 GB (uses SIM 2 slot) - dual SIM model only Internal	32/64 GB, 4 GB RAM MAIN CAMERA	Single	12 MP, f/1.7, 26mm (wide), 1/2.55", 1.4µm, Dual Pixel PDAF, OIS Features	LED flash, auto-HDR, panorama Video	2160p@30fps, 1080p@60fps, 720p@240fps, HDR, dual-video rec. SELFIE CAMERA	Single	5 MP, f/1.7, 22mm (wide), 1/4.1", 1.34µm Features	Dual video call, Auto-HDR Video	1440p SOUND	Loudspeaker	Yes 3.5mm jack	Yes  	- 24-bit/192kHz audio - Active noise cancellation with dedicated mic COMMS	WLAN	Wi-Fi 802.11 a/b/g/n/ac, dual-band, Wi-Fi Direct, hotspot Bluetooth	4.2, A2DP, LE, aptX GPS	Yes, with A-GPS, GLONASS, BDS NFC	Yes Radio	No USB	microUSB 2.0, USB Host FEATURES	Sensors	Fingerprint (front-mounted), accelerometer, gyro, proximity, compass, barometer, heart rate, SpO2  	- ANT+ - S-Voice natural language commands and dictation BATTERY	 	Non-removable Li-Ion 3000 mAh battery Charging	Fast battery charging 18W (Quick Charge 2.0) Qi/PMA wireless charging (market dependent) Talk time	Up to 22 h (3G) Music play	Up to 62 h MISC	Colors	Black, White, Gold, Silver, Pink Gold SAR	1.40 W/kg (head)     1.59 W/kg (body)     SAR EU	0.41 W/kg (head)     0.62 W/kg (body)     Price	About 290 EUR TESTS	Performance	Basemark OS II: 2004 / Basemark OS II 2.0: 2128 Basemark X: 32345 Display	Contrast ratio: Infinite (nominal), 4.376 (sunlight) Camera	Photo / Video Loudspeaker	Voice 69dB / Noise 69dB / Ring 71dB Audio quality	Noise -92.5dB / Crosstalk -92.7dB Battery life	 Endurance rating 80h', NULL, N'Blue', N'/Upload/image/product/images/samsungs7.jpg', NULL, CAST(N'2019-03-06T15:05:03.000' AS DateTime), NULL)
INSERT [dbo].[Products] ([product_id], [product_type_code], [product_name], [product_price], [product_description], [product_size], [product_color], [product_imge], [more_image], [createddate], [promotionprice]) VALUES (N'4', N'1', N'Sony X1', 2000000, N'Body: Polished aluminum frame, Gorilla Glass 5 front and rear; IP68 certified for water and dust resistance. Arctic Silver, Orchid Grey, Black Sky, Maple Gold, and Coral Blue color schemes. Display: 5.8" Super AMOLED, 2,960x1440px resolution, 18.5:9 (2.06:1) aspect ratio, 570ppi; HDR 10 compliant (no Dolby Vision). Rear camera:12MP, f/1.7 aperture, dual pixel phase detection autofocus, OIS; multi-shot image stacking; 2160p/30fps video recording. Front camera: 8MP, f/1.7 aperture, autofocus; 1440p/30fps video recording. OS/Software: Android 7.0 Nougat; Bixby virtual assistant. Chipsets: Qualcomm Snapdragon 835: octa-core CPU (4xKryo 280 + 4xCortex-A53), Adreno 540 GPU. Exynos 8895: octa-core CPU (4x2nd-gen Mongoose + 4xCortex-A53), Mali-G71 GPU. Memory: 4GB of RAM (a 6GB option likely in some markets, later down the line); 64GB of storage; microSD slot up to 256GB, UFS cards support. Battery: 3,000mAh Li-Ion (sealed); Adaptive Fast Charging (same as S7); QuickCharge 2.0 support; WPC&PMA wireless charging. Conn', NULL, N'Black', N'/Upload/image/product/images/Sony.jpg', NULL, CAST(N'2019-03-06T15:06:42.000' AS DateTime), NULL)
INSERT [dbo].[Products] ([product_id], [product_type_code], [product_name], [product_price], [product_description], [product_size], [product_color], [product_imge], [more_image], [createddate], [promotionprice]) VALUES (N'5', N'2', N'Wifi Asus', 500000, N'NETWORK	Technology	 GSM / HSPA / LTE LAUNCH	Announced	2016, February Status	Available. Released 2016, March BODY	Dimensions	142.4 x 69.6 x 7.9 mm (5.61 x 2.74 x 0.31 in) Weight	152 g (5.36 oz) Build	Front/back glass (Gorilla Glass 4), aluminum frame SIM	Single SIM (Nano-SIM) - G930F Hybrid Dual SIM (Nano-SIM, dual stand-by) - G930FD  	- Samsung Pay (Visa, MasterCard certified) - IP68 dust/water proof (up to 1.5m for 30 mins) DISPLAY	Type	Super AMOLED capacitive touchscreen, 16M colors Size	5.1 inches, 71.5 cm2 (~72.1% screen-to-body ratio) Resolution	1440 x 2560 pixels, 16:9 ratio (~577 ppi density) Protection	Corning Gorilla Glass 4  	- Always-on display PLATFORM	OS	Android 6.0 (Marshmallow), upgradable to Android 8.0 (Oreo); TouchWiz UI Chipset	Exynos 8890 Octa (14 nm) CPU	Octa-core (4x2.3 GHz Mongoose & 4x1.6 GHz Cortex-A53) GPU	Mali-T880 MP12 MEMORY	Card slot	microSD, up to 256 GB (uses SIM 2 slot) - dual SIM model only Internal	32/64 GB, 4 GB RAM MAIN CAMERA	Single	12 MP, f/1.7, 26mm (wide), 1/2.55", 1.4µm, Dual Pixel PDAF, OIS Features	LED flash, auto-HDR, panorama Video	2160p@30fps, 1080p@60fps, 720p@240fps, HDR, dual-video rec. SELFIE CAMERA	Single	5 MP, f/1.7, 22mm (wide), 1/4.1", 1.34µm Features	Dual video call, Auto-HDR Video	1440p SOUND	Loudspeaker	Yes 3.5mm jack	Yes  	- 24-bit/192kHz audio - Active noise cancellation with dedicated mic COMMS	WLAN	Wi-Fi 802.11 a/b/g/n/ac, dual-band, Wi-Fi Direct, hotspot Bluetooth	4.2, A2DP, LE, aptX GPS	Yes, with A-GPS, GLONASS, BDS NFC	Yes Radio	No USB	microUSB 2.0, USB Host FEATURES	Sensors	Fingerprint (front-mounted), accelerometer, gyro, proximity, compass, barometer, heart rate, SpO2  	- ANT+ - S-Voice natural language commands and dictation BATTERY	 	Non-removable Li-Ion 3000 mAh battery Charging	Fast battery charging 18W (Quick Charge 2.0) Qi/PMA wireless charging (market dependent) Talk time	Up to 22 h (3G) Music play	Up to 62 h MISC	Colors	Black, White, Gold, Silver, Pink Gold SAR	1.40 W/kg (head)     1.59 W/kg (body)     SAR EU	0.41 W/kg (head)     0.62 W/kg (body)     Price	About 290 EUR TESTS	Performance	Basemark OS II: 2004 / Basemark OS II 2.0: 2128 Basemark X: 32345 Display	Contrast ratio: Infinite (nominal), 4.376 (sunlight) Camera	Photo / Video Loudspeaker	Voice 69dB / Noise 69dB / Ring 71dB Audio quality	Noise -92.5dB / Crosstalk -92.7dB Battery life	 Endurance rating 80h', NULL, N'Black', N'/Upload/image/product/images/wifiasus.jpg', NULL, CAST(N'2019-03-06T15:11:21.000' AS DateTime), NULL)
INSERT [dbo].[Products] ([product_id], [product_type_code], [product_name], [product_price], [product_description], [product_size], [product_color], [product_imge], [more_image], [createddate], [promotionprice]) VALUES (N'8', N'1', N'Iphone 5S', 500000, N'Body: Polished aluminum frame, Gorilla Glass 5 front and rear; IP68 certified for water and dust resistance. Arctic Silver, Orchid Grey, Black Sky, Maple Gold, and Coral Blue color schemes. Display: 5.8" Super AMOLED, 2,960x1440px resolution, 18.5:9 (2.06:1) aspect ratio, 570ppi; HDR 10 compliant (no Dolby Vision). Rear camera:12MP, f/1.7 aperture, dual pixel phase detection autofocus, OIS; multi-shot image stacking; 2160p/30fps video recording. Front camera: 8MP, f/1.7 aperture, autofocus; 1440p/30fps video recording. OS/Software: Android 7.0 Nougat; Bixby virtual assistant. Chipsets: Qualcomm Snapdragon 835: octa-core CPU (4xKryo 280 + 4xCortex-A53), Adreno 540 GPU. Exynos 8895: octa-core CPU (4x2nd-gen Mongoose + 4xCortex-A53), Mali-G71 GPU. Memory: 4GB of RAM (a 6GB option likely in some markets, later down the line); 64GB of storage; microSD slot up to 256GB, UFS cards support. Battery: 3,000mAh Li-Ion (sealed); Adaptive Fast Charging (same as S7); QuickCharge 2.0 support; WPC&PMA wireless charging. Conn', NULL, N'While', N'/Upload/image/product/images/Iphone5s.jpg', NULL, CAST(N'2019-03-06T15:27:40.000' AS DateTime), NULL)
INSERT [dbo].[Products] ([product_id], [product_type_code], [product_name], [product_price], [product_description], [product_size], [product_color], [product_imge], [more_image], [createddate], [promotionprice]) VALUES (N'9', N'1', N'Iphone 8', 500000, N'Body: Polished aluminum frame, Gorilla Glass 5 front and rear; IP68 certified for water and dust resistance. Arctic Silver, Orchid Grey, Black Sky, Maple Gold, and Coral Blue color schemes. Display: 5.8" Super AMOLED, 2,960x1440px resolution, 18.5:9 (2.06:1) aspect ratio, 570ppi; HDR 10 compliant (no Dolby Vision). Rear camera:12MP, f/1.7 aperture, dual pixel phase detection autofocus, OIS; multi-shot image stacking; 2160p/30fps video recording. Front camera: 8MP, f/1.7 aperture, autofocus; 1440p/30fps video recording. OS/Software: Android 7.0 Nougat; Bixby virtual assistant. Chipsets: Qualcomm Snapdragon 835: octa-core CPU (4xKryo 280 + 4xCortex-A53), Adreno 540 GPU. Exynos 8895: octa-core CPU (4x2nd-gen Mongoose + 4xCortex-A53), Mali-G71 GPU. Memory: 4GB of RAM (a 6GB option likely in some markets, later down the line); 64GB of storage; microSD slot up to 256GB, UFS cards support. Battery: 3,000mAh Li-Ion (sealed); Adaptive Fast Charging (same as S7); QuickCharge 2.0 support; WPC&PMA wireless charging. Conn', NULL, NULL, N'/Upload/image/product/images/Iphone8.jpg', NULL, CAST(N'2019-03-06T15:28:55.810' AS DateTime), NULL)
INSERT [dbo].[Products] ([product_id], [product_type_code], [product_name], [product_price], [product_description], [product_size], [product_color], [product_imge], [more_image], [createddate], [promotionprice]) VALUES (N'PROD000', N'1', N'Product 7', 1000, N'Product 7 des       a', N'M', N'Red', N'/Upload/image/product/images/Capture.JPG', NULL, CAST(N'2019-03-28T17:29:04.963' AS DateTime), 10000)
INSERT [dbo].[Products] ([product_id], [product_type_code], [product_name], [product_price], [product_description], [product_size], [product_color], [product_imge], [more_image], [createddate], [promotionprice]) VALUES (N'PROD001', N'1', N'Product 7a', 10000, N'Product 7 des       a', N'M', N'Red', N'/Upload/image/product/images/Capture.JPG', NULL, CAST(N'2019-03-28T17:33:32.000' AS DateTime), 10000)
INSERT [dbo].[Products] ([product_id], [product_type_code], [product_name], [product_price], [product_description], [product_size], [product_color], [product_imge], [more_image], [createddate], [promotionprice]) VALUES (N'PROD002', N'1', N'Product 7', 1000, N'Product 7 des a', N'M', N'Red', N'/Upload/image/product/images/d.JPG', NULL, CAST(N'2019-03-28T17:37:36.027' AS DateTime), 10000)
INSERT [dbo].[Ref_Order_Item_Status_Codes] ([order_item_status_code], [order_item_status_description]) VALUES (-1, N'Cancle')
INSERT [dbo].[Ref_Order_Item_Status_Codes] ([order_item_status_code], [order_item_status_description]) VALUES (0, N'Doing')
INSERT [dbo].[Ref_Order_Item_Status_Codes] ([order_item_status_code], [order_item_status_description]) VALUES (1, N'Done')
INSERT [dbo].[Ref_Order_Status_Codes] ([order_status_code], [order_status_decription]) VALUES (-1, N'Cancle')
INSERT [dbo].[Ref_Order_Status_Codes] ([order_status_code], [order_status_decription]) VALUES (0, N'Done')
INSERT [dbo].[Ref_Order_Status_Codes] ([order_status_code], [order_status_decription]) VALUES (1, N'Doing')
INSERT [dbo].[Ref_Product_Types] ([product_type_code], [product_type_description]) VALUES (N'1', N'Smartphone')
INSERT [dbo].[Ref_Product_Types] ([product_type_code], [product_type_description]) VALUES (N'10', N'Somethings')
INSERT [dbo].[Ref_Product_Types] ([product_type_code], [product_type_description]) VALUES (N'11', N'Nothing')
INSERT [dbo].[Ref_Product_Types] ([product_type_code], [product_type_description]) VALUES (N'2', N'Network')
INSERT [dbo].[Ref_Product_Types] ([product_type_code], [product_type_description]) VALUES (N'3', N'Entertainment')
INSERT [dbo].[Ref_Product_Types] ([product_type_code], [product_type_description]) VALUES (N'4', N'Fastion')
INSERT [dbo].[Ref_Product_Types] ([product_type_code], [product_type_description]) VALUES (N'5', N'Book')
INSERT [dbo].[Ref_Product_Types] ([product_type_code], [product_type_description]) VALUES (N'6', N'Electronics')
INSERT [dbo].[Ref_Product_Types] ([product_type_code], [product_type_description]) VALUES (N'7', N'Kitchens')
INSERT [dbo].[Ref_Product_Types] ([product_type_code], [product_type_description]) VALUES (N'8', N'Somethings')
INSERT [dbo].[Ref_Product_Types] ([product_type_code], [product_type_description]) VALUES (N'PTYPE001', N'Somethings 1')
INSERT [dbo].[Ref_Product_Types] ([product_type_code], [product_type_description]) VALUES (N'PTYPE002', N'Somethings')
INSERT [dbo].[Ref_Product_Types] ([product_type_code], [product_type_description]) VALUES (N'PTYPE003', N'Kitchens 1')
INSERT [dbo].[Ref_Product_Types] ([product_type_code], [product_type_description]) VALUES (N'PTYPE004', N'Nothing at all')
INSERT [dbo].[Slider] ([ID], [Image], [DisplayOrder], [Link], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [Priority]) VALUES (1, N'/Upload/image/product/images/panel1.PNG', 0, N'#', N'Pannel_1', CAST(N'2019-03-28T14:06:43.850' AS DateTime), NULL, CAST(N'2019-03-28T14:06:43.850' AS DateTime), NULL, 1, N'active')
INSERT [dbo].[Slider] ([ID], [Image], [DisplayOrder], [Link], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [Priority]) VALUES (2, N'/Upload/image/product/images/panel2.PNG', 1, N'#', N'Pannel_2', CAST(N'2019-03-28T14:06:46.163' AS DateTime), NULL, CAST(N'2019-03-28T14:06:46.163' AS DateTime), NULL, 1, NULL)
INSERT [dbo].[Slider] ([ID], [Image], [DisplayOrder], [Link], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [Priority]) VALUES (3, N'/Upload/image/product/images/panel3.PNG', 2, N'#', N'Pannel_3', CAST(N'2019-03-28T10:25:25.690' AS DateTime), NULL, CAST(N'2019-03-28T10:25:25.690' AS DateTime), NULL, 1, NULL)
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_DisplayOrder]  DEFAULT ((1)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_createddate]  DEFAULT (getdate()) FOR [createddate]
GO
ALTER TABLE [dbo].[Slider] ADD  CONSTRAINT [DF_Slider_DisplayOrder]  DEFAULT ((1)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[Slider] ADD  CONSTRAINT [DF_Slider_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Orders] FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([order_id])
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Orders]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Ref_Invoice_Status_Codes] FOREIGN KEY([invoice_status_code])
REFERENCES [dbo].[Ref_Invoice_Status_Codes] ([invoice_status_code])
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Ref_Invoice_Status_Codes]
GO
ALTER TABLE [dbo].[Order_items]  WITH CHECK ADD  CONSTRAINT [FK_Order_items_Orders] FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([order_id])
GO
ALTER TABLE [dbo].[Order_items] CHECK CONSTRAINT [FK_Order_items_Orders]
GO
ALTER TABLE [dbo].[Order_items]  WITH CHECK ADD  CONSTRAINT [FK_Order_items_Ref_Order_Item_Status_Codes] FOREIGN KEY([order_item_status_code])
REFERENCES [dbo].[Ref_Order_Item_Status_Codes] ([order_item_status_code])
GO
ALTER TABLE [dbo].[Order_items] CHECK CONSTRAINT [FK_Order_items_Ref_Order_Item_Status_Codes]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customers] ([customer_id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Ref_Order_Status_Codes] FOREIGN KEY([order_status_code])
REFERENCES [dbo].[Ref_Order_Status_Codes] ([order_status_code])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Ref_Order_Status_Codes]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Invoices] FOREIGN KEY([invoice_number])
REFERENCES [dbo].[Invoices] ([invoice_number])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Invoices]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([product_type_code])
REFERENCES [dbo].[Ref_Product_Types] ([product_type_code])
GO
ALTER TABLE [dbo].[Shipment_Items]  WITH CHECK ADD  CONSTRAINT [FK_Shipment_Items_Order_items] FOREIGN KEY([order_item_id])
REFERENCES [dbo].[Order_items] ([order_item_id])
GO
ALTER TABLE [dbo].[Shipment_Items] CHECK CONSTRAINT [FK_Shipment_Items_Order_items]
GO
ALTER TABLE [dbo].[Shipment_Items]  WITH CHECK ADD  CONSTRAINT [FK_Shipment_Items_Shipments] FOREIGN KEY([shipment_id])
REFERENCES [dbo].[Shipments] ([shipment_id])
GO
ALTER TABLE [dbo].[Shipment_Items] CHECK CONSTRAINT [FK_Shipment_Items_Shipments]
GO
ALTER TABLE [dbo].[Shipments]  WITH CHECK ADD  CONSTRAINT [FK_Shipments_Invoices] FOREIGN KEY([invoice_number])
REFERENCES [dbo].[Invoices] ([invoice_number])
GO
ALTER TABLE [dbo].[Shipments] CHECK CONSTRAINT [FK_Shipments_Invoices]
GO
ALTER TABLE [dbo].[Shipments]  WITH CHECK ADD  CONSTRAINT [FK_Shipments_Orders] FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([order_id])
GO
ALTER TABLE [dbo].[Shipments] CHECK CONSTRAINT [FK_Shipments_Orders]
GO
