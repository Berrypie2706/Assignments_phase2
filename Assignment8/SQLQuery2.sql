create database Assignment08Db
use Assignment08Db
create table Employees(
EmployeeId int primary key,
FirstName nvarchar(50),
LastName nvarchar(50),
BirthDate date,
Salary decimal)

create table Products(
ProductId int primary key,
ProductName nvarchar(50),
Description nvarchar(50),
Price money,
ReleaseDate date)

create table Orders(
OrderId int primary key,
OrderDate datetime,
Quantity smallint,
Discount float,
IsShipped bit)

select * from Employees
select * from Products
select * from Orders

