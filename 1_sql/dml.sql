use AdventureWorks2017;
go

-- select
select 1 + 1;

select *
from Person.Person;

select FirstName, LastName, MiddleName
from Person.Person;

select FirstName, lastname, middlename
from person.Person
where FirstName='Robert';

select FirstName, lastname, middlename
from person.Person
where FirstName<>'robert' and FirstName<>'john';

select firstname, lastname, middlename
from Person.Person
WHERE FirstName like '%robert%' or FirstName like 'r_' or FirstName like 'r[aeiou]%';

select count(*) as "amount of", FirstName, lastname
from person.Person
where FirstName='robert' or FirstName='john'
group by Firstname, lastname;

select count(*) as "amount of", FirstName, lastname
from person.Person
where FirstName='robert' or FirstName='john'
group by Firstname, lastname
HAVING COUNT(*) > 1;

select count(*) as "amount of", FirstName, lastname
from person.Person
where FirstName='robert' or FirstName='john'
group by Firstname, lastname
HAVING COUNT(*) > 1
order by LastName asc, FirstName DESC;

--mode of execution
/*
FROM
WHERE
GROUP BY
HAVING
SELECT
ORDER BY
*/

-- insert
select * 
from Person.Address
WHERE AddressLine1 = 'UT';

insert into Person.Address(AddressLine1, AddressLine2, City, StateProvinceID, PostalCode, SpatialLocation, rowguid, ModifiedDate)
values 
('UT',NULL,'Arlington',79,76011,0xE6100000010CAE8BFC28BCE4474067A89189898A5EC0,'9aadcb0d-36cf-483f-84d8-585c2d4ec6ea','2019-11-08');


insert into Person.Address
SELECT AddressLine1, AddressLine2, City, StateProvinceID, PostalCode, SpatialLocation, rowguid, ModifiedDate
from Person.Address
where AddressLine1 = 'UT';

-- bulk insert Person.Address from 'data.csv' with (rowterminator = '\n', fieldterminator = ',');

-- update

update Person.Person
set firstname = 'john'
where FirstName = 'robert';

update pp
set firstname = 'robert'
from Person.Person as pp
where pp.LastName = 'jones';

-- delete

delete 
from Person.Person  
WHERE MiddleName is NULL and FirstName = 'xavier';  

-- join

-- get person with address by joining person, business entity address, and address table
select pp.firstname, pp.lastname, pa.addressline1, pa.city, pa.PostalCode
from Person.Person as pp
inner join Person.BusinessEntityAddress as pbea on pbea.BusinessEntityID = pp.BusinessEntityID
inner join Person.Address as pa on pa.AddressID = pbea.AddressID
where pp.FirstName = 'jimmy';

select pp.firstname, pp.lastname, prp.Name, ssoh.OrderDate
from Person.Person as pp
inner join Person.BusinessEntityAddress as pbea on pbea.BusinessEntityID = pp.BusinessEntityID
inner join Person.Address as pa on pa.AddressID = pbea.AddressID
inner join Sales.Customer as sc on sc.CustomerID = pp.BusinessEntityID
inner join Sales.SalesOrderHeader as ssoh on ssoh.CustomerID = sc.CustomerID
inner join Sales.SalesOrderDetail as ssod on ssod.SalesOrderID = ssoh.SalesOrderID
inner join Production.Product as prp on prp.ProductID = ssod.ProductID
where pp.FirstName = 'jimmy' and datepart(month, ssoh.OrderDate) = 7 and prp.Name like '%tire%';


select pp.firstname, pp.lastname, ppt.Name
from Person.Person as pp
inner join Person.BusinessEntityAddress as pbea on pbea.BusinessEntityID = pp.BusinessEntityID
inner join Person.Address as pa on pa.AddressID = pbea.AddressID
inner join Sales.Customer as sc on sc.CustomerID = pp.BusinessEntityID
inner join
(
    select salesorderid, customerid
    from Sales.SalesOrderHeader
    where datepart(month, orderdate) = 7
) as ssoh on ssoh.CustomerID = sc.CustomerID
inner join Sales.SalesOrderDetail as ssod on ssoh.SalesOrderID = ssoh.SalesOrderID
inner join
(
    select productid, name
    from Production.Product
    where Name like '%tire%'
) as ppt on ppt.ProductID = ssod.ProductID
where pp.FirstName = 'jimmy';


with OrderHeader as
(
    select salesorderid, customerid
    from Sales.SalesOrderHeader
    where datepart(month, orderdate) = 7
),
Product as
(
    select productid, name
    from Production.Product
    where Name like '%tire%'
)
select pp.firstname, pp.lastname, ppt.name, ssoh.OrderDate
from Person.Person as pp
inner join Person.BusinessEntityAddress as pbea on pbea.BusinessEntityID = pp.BusinessEntityID
inner join Person.Address as pa on pa.AddressID = pbea.AddressID
inner join Sales.Customer as sc on sc.CustomerID = pp.BusinessEntityID
inner join Sales.SalesOrderHeader as ssoh on ssoh.CustomerID = sc.CustomerID
inner join Sales.SalesOrderDetail as ssod on ssod.SalesOrderID = ssoh.SalesOrderID
inner join Product as ppt on ppt.ProductID = ssod.ProductID
where pp.FirstName = 'jimmy';

select distinct pp.firstname, pp2.LastName
from Person.Person as pp
inner join Person.Person as pp2 on pp2.LastName = pp.FirstName;

select firstname
from Person.Person
intersect
select lastname
from Person.person;

