use AdventureWorks2017;
go

-- view
-- this bottom view is unsafe because column name can change
CREATE VIEW vw_Person
as
select firstname, lastname
FROM Person.Person;
GO

--this bottom view is safe because it specifies that the columns name can't change and person table can't drop
--stops destructive behavior
alter VIEW vw_Person with SCHEMABINDING
as
select firstname, lastname
FROM Person.Person;
GO

SELECT * FROM vw_Person;
go

-- function
CREATE FUNCTION fn_Person(@first nvarchar(50))
returns TABLE
as
return
select firstname, lastname
FROM Person.Person
WHERE firstname = @first;
go

create FUNCTION fn_FullName(@first nvarchar(50), @middle nvarchar(50), @last nvarchar(50))
returns NVARCHAR(200)
as
BEGIN
    -- return @first + ' ' + @middle + ' ' + @last
    -- coalesce  - if middle name is null do not display it otherwise diplay it  
    -- isnull - same as coalesce but can only give have it one thing
    return @first + coalesce(' ' + @middle, '') + ' ' + @last
    -- return @first + ISNULL(' ' + @middle, '') + ' ' + @last
END;
go

select dbo.fn_FullName(FirstName, null, LastName) as full_name from fn_person('joshua');
GO

SELECT * from fn_Person('joshua');
GO

-- stored procedure
CREATE PROCEDURE sp_InsertName(@first nvarchar(50), @middle nvarchar(50), @last nvarchar(50))
AS
begin
    begin TRANSACTION
        begin try
            declare @mname as NVARCHAR(50) = @middle

            if(@mname is null)
            BEGIN
                set @mname = ''
            end
            
            CHECKPOINT -- savepoint

            insert into Person.Person(FirstName, LastName, MiddleName)
            values (@first, @last, @mname)

            commit TRANSACTION
        end try

        begin catch
            print error_message()
            print error_severity()
            print error_state()
            print error_number()
            rollback transaction
        end catch
end;

EXECUTE sp_InsertName 'fred', null, 'belotte';
go

-- trigger

-- CREATE TRIGGER tr_InsertName
-- on Person.Person
-- instead of insert
-- as 
-- update pp
-- set firstname = inserted.firstname
-- from Person.person as pp
-- where pp.BusinessEntityID = inserted.BusinessEntityID;
