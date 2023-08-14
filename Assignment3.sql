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

select p.PId, p.PName, p.PPrice, p.PMDate, c.CName
from ProductInfo p
join CompanyInfo c on p.CId = c.CId


select  p.PName, c.CName
from ProductInfo p
join CompanyInfo c on p.CId = c.CId

select p.PId, p.PName, p.PPrice, p.PMDate, c.CName,c.CId
from ProductInfo p
cross join CompanyInfo c 

