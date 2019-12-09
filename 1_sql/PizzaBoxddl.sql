use master;
go

CREATE DATABASE PizzaBox;
go

use PizzaBox;
go

-- create schemas
CREATE SCHEMA [Order];
go

CREATE SCHEMA [User];
go

create schema [Store];
GO

CREATE SCHEMA [Address];
GO

CREATE SCHEMA [Pizza];
GO

-- create tables
create table [Order].[Order]
(
    OrderId int not null identity(1,1) --primary key
    ,UserId int not null --foreign key
    ,StoreId int not null --foreign key
    ,TotalCost decimal(5,2) not null
    ,OrderDate datetime2(7) not null
    ,Active bit not null
);

create table [Order].[OrderPizza]
(
    OrderPizzaId int not null identity(1,1) --primary key
    ,OrderId int not null --foreign key
    ,PizzaId int not null --foreign key
);


CREATE TABLE [User].[User]
(
    UserId int not null IDENTITY(1,1) --primary key
    ,FirstName nvarchar(50) not null
    ,LastName nvarchar(50) not null
    ,Active bit not null 
    ,UserAccountId int not null --foreign key
    ,UserTypeId int not null --foreign key
    ,AddressId int not null --foreign key
);

CREATE TABLE [User].[User_Account]
(
    UserAccountId int not null IDENTITY(1,1) --primary key
    ,Email nvarchar(50) not null 
    ,Password nvarchar(50) not null 
);

CREATE TABLE [User].[User_Type]
(
    UserTypeId int not null IDENTITY(1,1) --primary key
    ,UserType nvarchar(20) not null 
);

CREATE TABLE [Store].[Store]
(
    StoreId int not null IDENTITY(1,1) --primary key
    ,StoreName nvarchar(50) not null 
    ,AddressId int not null  --foreign key
    ,UserId int not null --foreign key
);


-- CREATE TABLE [Store].[StoreManager]
-- (
--     StoreManagerId int not null IDENTITY(1,1) --primary key
--     ,StoreId int not null --foreign key
--     ,UserId int not null --foreign key
-- );

CREATE TABLE [Address].[Address]
(
    AddressId int not null IDENTITY(1,1) --primary key
    ,Street nvarchar(50) not null 
    ,City nvarchar(20) not null 
    ,AddressState nvarchar(20) not null
    ,ZipCode int not null
);

CREATE TABLE [Pizza].[Pizza]
(
    PizzaId int not null IDENTITY(1,1) --primary key
    ,Cost decimal(5,2) not null 
    ,SizeId int not null --foreign key
    ,CrustId int not null --foreign key
);

CREATE TABLE [Pizza].[Size]
(
    SizeId int not null IDENTITY(1,1) --primary key
    ,SizeName nvarchar(20) not null
    ,Price decimal(5,2) not null
);

CREATE TABLE [Pizza].[Crust]
(
    CrustId int not null IDENTITY(1,1) --primary key
    ,CrustName nvarchar(20) not null
    ,Price decimal(5,2) not null
);

CREATE TABLE [Pizza].[PizzaTopping]
(
    PizzaToppingId int not null IDENTITY(1,1) --primary key
    ,PizzaId int not null --foreign key
    ,ToppingId int not null --foreign key
);

CREATE TABLE [Pizza].[Topping]
(
    ToppingId int not null IDENTITY(1,1) --primary key
    ,ToppingName NVARCHAR(20) not null
    ,Price decimal(5,2) not null
);

-- alter
-- primary keys
ALTER TABLE [Order].[Order]
    add constraint PK_Order_OrderId primary key (OrderId);

ALTER TABLE [Order].[OrderPizza]
    add constraint PK_OrderPizza_OrderPizzaId primary key (OrderPizzaId)

ALTER TABLE [User].[User]
    add constraint PK_User_UserId primary key (UserId)

ALTER TABLE [User].[User_Account]
    add constraint PK_User_UserAccountId primary key (UserAccountId)

ALTER TABLE [User].[User_Type]
    add constraint PK_User_UserTypeId primary key (UserTypeId)

ALTER TABLE [Store].[Store]
    add constraint PK_Store_StoreId primary key (StoreId)   

-- ALTER TABLE [Store].[StoreManager]
--     add constraint PK_Store_StoreManagerId primary key (StoreManagerId)    

ALTER TABLE [Address].[Address]
    add constraint PK_Address_AddressId primary key (AddressId) 

ALTER TABLE [Pizza].[Pizza]
    add constraint PK_Pizza_PizzaId primary key (PizzaId) 

ALTER TABLE [Pizza].[Size]
    add constraint PK_Pizza_SizeId primary key (SizeId) 

ALTER TABLE [Pizza].[Crust]
    add constraint PK_Pizza_CrustId primary key (CrustId)

ALTER TABLE [Pizza].[PizzaTopping]
    add constraint PK_PizzaTopping_PizzaToppingId primary key (PizzaToppingId) 

ALTER TABLE [Pizza].[Topping]
    add constraint PK_Topping_ToppingId primary key (ToppingId)  

-- foreign keys
ALTER TABLE [Order].[Order]
    add constraint FK_Order_UserId foreign key (UserId) references [User].[User](UserId);

ALTER TABLE [Order].[Order]
    add constraint FK_Order_StoreId foreign key (StoreId) references [Store].[Store](StoreId);

ALTER TABLE [Order].[OrderPizza]
    add constraint FK_OrderPizza_OrderId foreign key (OrderId) references [Order].[Order](OrderId);

ALTER TABLE [Order].[OrderPizza]
    add constraint FK_OrderPizza_StoreId foreign key (PizzaId) references [Pizza].[Pizza](PizzaId);

ALTER TABLE [User].[User]
    add constraint FK_User_UserAccountId foreign key (UserAccountId) references [User].[User_Account](UserAccountId);

ALTER TABLE [User].[User]
    add constraint FK_User_UserTypeId foreign key (UserTypeId) references [User].[User_Type](UserTypeId);

ALTER TABLE [User].[User]
    add constraint FK_User_AddressId foreign key (AddressId) references [Address].[Address](AddressId);

ALTER TABLE [Store].[Store]
    add constraint FK_Store_AddressId foreign key (AddressId) references [Address].[Address](AddressId);

ALTER TABLE [Store].[Store]
    add constraint FK_Store_UserId foreign key (UserId) references [User].[User](UserId);

-- ALTER TABLE [Store].[StoreManager]
--     add constraint FK_StoreManager_StoreId foreign key (StoreId) references [Store].[Store](StoreId);

-- ALTER TABLE [Store].[StoreManager]
--     add constraint FK_StoreManager_UserId foreign key (UserId) references [User].[User](UserId);

ALTER TABLE [Pizza].[Pizza]
    add constraint FK_Pizza_SizeId foreign key (SizeId) references [Pizza].[Size](SizeId);

ALTER TABLE [Pizza].[Pizza]
    add constraint FK_Pizza_CrustId foreign key (CrustId) references [Pizza].[Crust](CrustId);

ALTER TABLE [Pizza].[PizzaTopping]
    add constraint FK_PizzaTopping_PizzaId foreign key (PizzaId) references [Pizza].[Pizza](PizzaId);

ALTER TABLE [Pizza].[PizzaTopping]
    add constraint FK_PizzaTopping_ToppingId foreign key (ToppingId) references [Pizza].[Topping](ToppingId);

-- default
alter table [Order].[Order]
    add constraint DF_Order_Active default(1) for Active;

alter table [User].[User]
    add constraint DF_User_Active default(1) for Active;

-- alter table [Pizza].[Pizza]
--     alter column cost decimal(4,2);

-- alter table [Order].[Order]
--     alter column TotalCost decimal(5,2);

