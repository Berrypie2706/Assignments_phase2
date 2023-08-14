create database ExerciseDb
create table CompanyInfo(
CId int primary key,
CName nvarchar(50) not null)

create table ProductInfo(
PId int primary key,
PName nvarchar(50) not null,
PPrice float ,
PMDate date,
CId int foreign key references CompanyInfo
)

insert into CompanyInfo values(1, 'Samsung')
insert into CompanyInfo values(2, 'HP')
insert into CompanyInfo values(3, 'Apple')
insert into CompanyInfo values(4, 'Dell')
insert into CompanyInfo values(5, 'Toshiba')
insert into CompanyInfo values(6, 'Redmi')


insert into ProductInfo values(101, 'Laptop', 55000.90, '12/12/2023', 1)
insert into ProductInfo values(102, 'Laptop', 35000.90, '12/12/2012', 2)
insert into ProductInfo values(103, 'Mobile', 15000.90, '12/03/2012', 2)
insert into ProductInfo values(104, 'Laptop', 135000.90, '12/12/2012', 3)
insert into ProductInfo values(105, 'Mobile', 65000.90, '12/12/2012', 3)
insert into ProductInfo values(106, 'Laptop', 35000.90, '12/12/2012', 5)
insert into ProductInfo values(107, 'Mobile', 35000.90, '12/01/2012', 5)
insert into ProductInfo values(108, 'Earpod', 1000.90, '12/01/2022', 3)
insert into ProductInfo values(109, 'Laptop', 85000.90, '12/12/2021', 6)
insert into ProductInfo values(110, 'Mobile', 55000.70, '12/12/2020', 1)

select c.CName, p.PId, p.PName, p.PPrice, p.PMDate
from ProductInfo p
join CompanyInfo c on p.CId = c.CId


select  p.PName, c.CName
from ProductInfo p
join CompanyInfo c on p.CId = c.CId

select p.PId, p.PName, p.PPrice, p.PMDate, c.CName,c.CId
from ProductInfo p
cross join CompanyInfo c 
---------------------------------------------------------------------------------
---------------------------------------------------------------------------------
--Part2

create table Products(
PId int primary key,
PQ int not null,
PPrice float,
Discount float )



insert into Products values( 1, 24, 24000.89, 0.15)
insert into Products values( 2, 24, 19000.89, 0.10)
insert into Products values( 3, 24, 15000.89, 0.25)

create function Discount
(
@price float,
@discount float
)
returns float
as 
begin
declare @discountGiven float;
select @discountGiven = @price * @discount
return @discountGiven
end

create function CalcDiscountValue
(
@price float,
@discount float
)
returns float
as 
begin
declare @discountValue float;
select @discountValue= @price - (@price * @discount)
return @discountValue
end

select PId, PQ, PPrice, Discount, dbo.Discount(PPrice,Discount) as 'Discount Given', dbo.CalcDiscountValue(PPrice,Discount) as 'Price After Discount' from Products

