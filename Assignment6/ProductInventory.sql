create database ProductInventoryDb
use ProductInventoryDb
create table Products(
Product_Id int primary key,
PName nvarchar(50),
Price float,
Quantity int,
MfgDate date,
ExpDate date)
insert into Products values(45,'Pintola PeaNut Butter', 370, 40, '07/12/2023', '01/11/2024')
insert into Products values(55,'Harpic', 299, 20, '12/12/2022', '01/11/2026')
insert into Products values(65,'Dettol HandWash', 249, 40, '07/12/2023', '01/11/2024')
insert into Products values(75,'Fortune vegtable oil', 179, 100, '07/01/2023', '01/01/2024')
insert into Products values(85,'TATA Salt', 45, 40, '07/12/2023', '01/11/2030')
insert into Products values(99,'Brown Bread', 30, 40, '08/12/2023', '08/17/2024')
insert into Products values(109,'Body wash', 400, 20, '06/30/2023', '12/11/2023')
insert into Products values(89,'Oats', 189, 10, '07/12/2023', '01/11/2024')
insert into Products values(12,'Facw wash', 290, 25, '05/30/2023', '11/11/2024')
select * from Products