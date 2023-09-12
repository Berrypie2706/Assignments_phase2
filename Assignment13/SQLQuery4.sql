create database BlogDb
use BlogDb
create table Post(
PostId int primary key,
Title nvarchar(max),
Content nvarchar(50),
PublicationDate datetime,
Author nvarchar(50))

create table Comments(
Id int primary key,
Content nvarchar(max),
PublicationDate datetime,
PostId int foreign key references Post)
select * from Comments
select * from Post