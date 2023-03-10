USE [master]
GO
/****** Object:  Database [QLBHDienThoai]    Script Date: 5/12/2022 5:02:02 AM ******/
CREATE DATABASE [QLBHDienThoai]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLBHDienThoai', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QLBHDienThoai.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLBHDienThoai_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QLBHDienThoai_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QLBHDienThoai] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLBHDienThoai].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLBHDienThoai] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLBHDienThoai] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLBHDienThoai] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLBHDienThoai] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLBHDienThoai] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLBHDienThoai] SET  MULTI_USER 
GO
ALTER DATABASE [QLBHDienThoai] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLBHDienThoai] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLBHDienThoai] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLBHDienThoai] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLBHDienThoai] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLBHDienThoai] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QLBHDienThoai] SET QUERY_STORE = OFF
GO
USE [QLBHDienThoai]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 5/12/2022 5:02:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/12/2022 5:02:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/12/2022 5:02:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Status] [int] NULL,
	[ReceivedAddress] [nvarchar](250) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdersDetail]    Script Date: 5/12/2022 5:02:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
 CONSTRAINT [PK_OrdersDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/12/2022 5:02:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[CategoryID] [int] NOT NULL,
	[Description] [ntext] NULL,
	[Price] [decimal](18, 0) NULL,
	[Image] [nvarchar](250) NULL,
	[Quantity] [int] NULL,
	[Color] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/12/2022 5:02:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 5/12/2022 5:02:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cart] ADD  CONSTRAINT [DF_Cart_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[OrdersDetail] ADD  CONSTRAINT [DF_OrdersDetail_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_CreatedAt_1]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [DF_UserRole_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Product]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_User]
GO
ALTER TABLE [dbo].[OrdersDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrdersDetail_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[OrdersDetail] CHECK CONSTRAINT [FK_OrdersDetail_Orders]
GO
ALTER TABLE [dbo].[OrdersDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrdersDetail_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[OrdersDetail] CHECK CONSTRAINT [FK_OrdersDetail_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserRole] FOREIGN KEY([RoleID])
REFERENCES [dbo].[UserRole] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserRole]
GO
USE [master]
GO
ALTER DATABASE [QLBHDienThoai] SET  READ_WRITE 
GO

select * from Product;

select * from Category;
insert into Category(Name,CreatedAt, UpdateAt) values ('Samsung','3/5/2023','');
insert into Category(Name,CreatedAt, UpdateAt) values ('Iphone','3/2/2023','');
insert into Category(Name,CreatedAt, UpdateAt) values ('Oppo','3/6/2023','');
insert into Category(Name,CreatedAt, UpdateAt) values ('Xiaomi','3/7/2023','');
insert into Category(Name,CreatedAt, UpdateAt) values ('Nokia','3/9/2023','');
insert into Category(Name,CreatedAt, UpdateAt) values ('Vivo','3/5/2023','');

select * from [dbo].[User];

select * from UserRole;
insert into UserRole(Name, CreatedAt, UpdateAt) values ('user', '3/5/2023', '');
insert into UserRole(Name, CreatedAt, UpdateAt) values ('admin', '3/5/2023', '');

insert into [dbo].[User](RoleID, Name, Username,Password,Address,Phone,Email,CreatedAt,UpdateAt) values (1,N'Vũ ĐỨc Duy','duyduc12','111111',N'Thái Bình','0123456789','duyduc@llq.com','3/5/2023','');
insert into [dbo].[User](RoleID, Name, Username,Password,Address,Phone,Email,CreatedAt,UpdateAt) values (2,N'Vũ Minh Mạnh','vumanh285','123456',N'Hà Nội','0967295815','vumanh358@gmail.com','3/6/2023','');

select * from Cart;
select * from Product;

insert into Product(Name,CategoryID,Description,Price,Image,Quantity,Color,CreatedAt,UpdateAt) values ('Iphone 8 Plus',2,N'Máy có màn hình Retina HD, với tấm nền LCD cảm ứng chạm đa điểm, công nghệ IPS và 3D Touch. Kích thước màn hình là 4,7 inch, độ phân giải 1334×750 pixel, với mật độ điểm ảnh 326 ppi. Hệ thống miền pixel kép cho góc nhìn rộng và độ sáng tối đa lên tới 625 cd/m².',5650000,'/wwwroot/images/Products/product2.jpg',20,'White','3/6/2023','');
insert into Product(Name,CategoryID,Description,Price,Image,Quantity,Color,CreatedAt,UpdateAt) values ('Oppo A3s',3,N'OPPO A3s được trang bị bộ vi xử lý Snapdragon 450 tám nhân đi cùng 3GB RAM và 32GB bộ nhớ trong. Việc sử dụng con chip mới sản xuất trên tiến trình 14nm giúp cho OPPO A3s vừa mạnh mẽ, vừa tiết kiệm điện năng hơn, đảm bảo cho máy luôn chạy mượt mà.',2690000,'/wwwroot/images/Products/product3.jpg',80,'Red','3/6/2023','');
insert into Product(Name,CategoryID,Description,Price,Image,Quantity,Color,CreatedAt,UpdateAt) values ('Samsung A20',1,N'Điểm nhấn ấn tượng nhất trên Galaxy A20 chính là thiết kế màn hình vô cực Infinity-V mang đến trải nghiệm hình ảnh không giới hạn cho người dùng. Chiếc màn hình này chiếm phần lớn mặt trước của Galaxy A20 với tỷ lệ hiển thị lên đến 91.8%.',4190000,'/wwwroot/images/Products/product10.jpg',90,'White','3/6/2023','');
insert into Product(Name,CategoryID,Description,Price,Image,Quantity,Color,CreatedAt,UpdateAt) values ('Iphone 6',2,N'iPhone 6 có kích thước màn hình 4,7 inch, tỉ lệ 16:9 với độ phân giải 1334×750 và có mật độ điểm ảnh đạt 326 ppi. Trong khi đó, iPhone 6 Plus có kích thước màn hình 5,5 inch, cùng tỉ lệ 16:9 với độ phân giải 1920×1080 và có mật độ điểm ảnh đạt 401 ppi.',5499000,'/wwwroot/images/Products/product1.jpg',200,'Yellow','3/6/2023','');
insert into Product(Name,CategoryID,Description,Price,Image,Quantity,Color,CreatedAt,UpdateAt) values ('Iphone 12',2,N'Dòng iPhone 12 đi kèm các nâng cấp phần cứng hàng năm từ Apple, bao gồm chip A14 Bionic 5nm nhanh và tiết kiệm năng lượng hơn. Hiệu năng GPU và AI cũng được cải thiện cùng bộ nhớ trong lên đến 512 GB. Đối với dòng iPhone 12, công ty dự kiến sẽ trang bị RAM 6 GB trên bản Pro',9390000,'/wwwroot/images/Products/product11.jpg',35,'White Black','3/6/2023','');
insert into Product(Name,CategoryID,Description,Price,Image,Quantity,Color,CreatedAt,UpdateAt) values ('Nokia 110 4G',5,N'Cấu hình Điện thoại Nokia 110 4G Màn hình:TFT LCD1.8"65.536 màu SIM:2 Nano SIMHỗ trợ 4G Danh bạ:2000 số Thẻ nhớ:MicroSD, hỗ trợ tối đa 32 GB Camera sau:0.08 MP Radio FM:FM không cần tai nghe Jack cắm tai nghe:3.5 mm Pin:1020 mAh Nokia chính thức trình làng chiếc điện thoại Nokia 110 4G phiên bản nâng cấp của Nokia 110 2019 có điểm...',819000,'/wwwroot/images/Products/Nokia.jpg',60,'Yellow','3/6/2023','');
insert into Product(Name,CategoryID,Description,Price,Image,Quantity,Color,CreatedAt,UpdateAt) values ('Vivo Y33s',6,N'Vivo Y33s sở hữu một thiết kế trẻ trung với màu đen tráng gương và xanh mộng mơ, các góc của chiếc điện thoại được bo cong nhẹ tạo cảm giác thoải mái khi cầm nắm. Chiếc điện thoại được thiết kế nhỏ gọn với trọng lượng 182g và chỉ mỏng có 8 mm.',5140000,'/wwwroot/images/Products/Vivo.jpg',50,'Gray','3/6/2023','');
insert into Product(Name,CategoryID,Description,Price,Image,Quantity,Color,CreatedAt,UpdateAt) values ('Iphone 11',2,N'Sở hữu một thiết kế trẻ trung với màu đen tráng gương và xanh mộng mơ, các góc của chiếc điện thoại được bo cong nhẹ tạo cảm giác thoải mái khi cầm nắm. Chiếc điện thoại được thiết kế nhỏ gọn với trọng lượng 182g và chỉ mỏng có 8 mm.',6690000,'/wwwroot/images/Products/product17.jpg',20,'Gray','3/6/2023','');

update Product set Image = '/images/Products/product2.jpg' where ID = 1;

select * from Cart;
insert into Cart(ProductID,Quantity,CreatedAt) values (2,3,'3/6/2023');

select * from Orders;
insert into Orders(UserID, Status,ReceivedAddress,CreatedAt,UpdateAt) values (1,1,N'Tu Hoàng, Phương Cang, Nam Từ Liêm, Hà Nội','3/6/2023','');

select * from OrdersDetail;
insert into OrdersDetail(OrderID,ProductID,Quantity,CreatedAt,UpdateAt) values (1,2,3,'3/6/2023','');