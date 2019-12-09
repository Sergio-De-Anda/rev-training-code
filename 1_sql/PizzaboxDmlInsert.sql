use PizzaBox
go

-- insert
-- User_type
INSERT into [User].User_Type(UserType)
VALUES
('Manager');

INSERT into [User].User_Type(UserType)
VALUES
('Customer');

-- SELECT * from [User].[User_Type];

SELECT uu.FirstName, aa.Street, ut.UserType, ua.Email, ua.[Password]
from [User].[User] as uu
inner join [User].User_Account as ua on uu.UserAccountId = ua.UserAccountId
inner join [User].User_Type as ut on uu.UserTypeId = ut.UserTypeId
inner join [Address].[Address] as aa on uu.AddressId = aa.AddressId;

-- Address
INSERT into [Address].[Address]
VALUES
('500 S 15th Street','Arlington','Texas',76013);

INSERT into [Address].[Address]
VALUES
('605 N 6th Avenue','Arlington','Texas', 76013);

INSERT into [Address].[Address]
VALUES
('350 N W Drive','Arlington','Texas', 76013);

SELECT * from [Address].[Address];

-- User 
-- account
INSERT into [User].[User_Account]
VALUES
('admin@pizzabox.com','123');

select * from [User].User_Account;

-- manager
INSERT into [User].[User](FirstName, LastName, UserAccountId, UserTypeId, AddressId)
VALUES
('Admin','Admin', 1, 1, 1);

-- update [User].[User]
-- set UserTypeId = 1
-- WHERE UserId = 1;

-- SELECT * from [User].[User];

-- Store
insert into [Store].[Store]
VALUES
('Pizza Planet', 2, 1);

insert into [Store].[Store]
VALUES
('Best Pizza', 3, 1);

SELECT * FROM Store.Store;

-- Pizza
-- size
insert into [Pizza].Size
VALUES
('small',5.99);

insert into [Pizza].Size
VALUES
('medium',6.99);

insert into [Pizza].Size
VALUES
('large',7.99);



SELECT * from Pizza.[Size];


-- topping
INSERT into Pizza.Topping
VALUES
('pepperoni',0.50);

insert into Pizza.Topping
VALUES
('beef', 0.50);

insert into Pizza.Topping
VALUES
('bacon', 0.50);

insert into Pizza.Topping
VALUES
('chicken', 0.50);

insert into Pizza.Topping
VALUES
('sausage', 0.50);

SELECT * from Pizza.Topping;

-- crust

insert into Pizza.Crust
VALUES
('hand-tossed', 0.50)

insert into Pizza.Crust
VALUES
('thin', 0.50)

insert into Pizza.Crust
VALUES
('cheese-stuffed', 0.50)

SELECT * from Pizza.Crust;

SELECT oo.TotalCost, uu.FirstName, ss.StoreName
from [Order].[Order] as oo
inner join [User].[User] as uu on oo.UserId = uu.UserId
inner join [Store].Store as ss on oo.StoreId = ss.StoreId;

SELECT oo.OrderId, pp.PizzaId
from [Order].[Order] as oo
inner join [Order].OrderPizza as op on oo.OrderId = op.OrderId
inner join [Pizza].Pizza as pp on op.PizzaId = pp.PizzaId;

SELECT pp.PizzaId, ps.SizeName, pc.CrustName, t.ToppingName
from Pizza.Pizza as pp
inner join Pizza.Crust as pc on pp.CrustId = pc.CrustId
inner join Pizza.[Size] as ps on pp.SizeId = ps.SizeId
inner join Pizza.PizzaTopping as pt on pp.PizzaId = pt.PizzaId
inner join Pizza.Topping as t on pt.ToppingId = t.ToppingId;

SELECT pp.PizzaId, pt.ToppingName, pp.Cost
from Pizza.pizza as pp
inner join Pizza.PizzaTopping as ppt on pp.PizzaId = ppt.PizzaId
inner join Pizza.Topping as pt on ppt.ToppingId = pt.ToppingId;

select *
from [Order].[Order];

SELECT *
from [Order].OrderPizza as oop
WHERE oop.OrderId = 3;

SELECT uu.FirstName, pp.Cost
from [User].[User] as uu
inner join [Order].[Order] as oo on uu.UserId = oo.UserId
inner join [Order].OrderPizza as oop on oo.OrderId = oop.OrderId
inner join [Pizza].Pizza as pp on oop.PizzaId = pp.PizzaId
where uu.FirstName='gerardo';

SELECT sum(oo.TotalCost)
from [Store].Store as ss
inner join [Order].[Order] as oo on ss.StoreId = oo.StoreId
WHERE datepart(month, oo.OrderDate) = 7;

SELECT *
from Pizza.[Size];

delete
from Pizza.[Size]
WHERE SizeName = 'extreme';

