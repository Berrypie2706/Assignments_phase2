create database Assignment14Db
use Assignment14Db
create table Players(
PlayerId int primary key,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
JerseyNumber int not null,
Position nvarchar(50)  not null,
Team nvarchar(20) not null)
insert into Players values(1, 'Virat', 'Kohli', 18,'Batsmen', 'India')
select * from Players	