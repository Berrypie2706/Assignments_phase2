create database ExerciseDb
use ExerciseDb

create table Publisher(
PId int primary key,
Publisher nvarchar(100)not null unique)

create table Category(
CId int primary key,
Category nvarchar(100)not null unique)

create table Author(
AId int primary key,
Author_Name nvarchar(100)not null unique)



create table Book(
BId int primary key,
Book_Name varchar(100) not null,
Book_price nvarchar(50) not null,
AId int foreign key references Author,
PId int foreign key references Publisher,
CId  int foreign key references Category,
)

INSERT INTO Publisher (PId, Publisher)
VALUES (748472,'Penguin Books'), (384848,'HarperCollins')

INSERT INTO Category (CId,Category)
VALUES (8901,'Fiction'), (96781,'Non-Fiction'), (09090,'Mystery'), (90087,'Science Fiction')

INSERT INTO Author (AId,Author_Name)
VALUES (19980,'J.K. Rowling'), (12421,'Stephen King'), (87764,'Agatha Christie'), (56634,'Isaac Asimov')

INSERT INTO Book (BId, Book_Name,Book_price, AId, PId, CId)
VALUES (701,'Harry Potter and the Sorcerer''s Stone',$50, 19980, 748472, 8901 ),
       (702,'The Shining', $23, 12421, 748472, 96781),
       (703,'Murder on the Orient Express',$44, 87764, 384848, 09090),
       (704, 'Foundation',$99, 56634, 384848, 90087)
      insert into Book values (705,'It', $49, 12421, 748472, 96781 )
      insert into Book values  (706, 'The Caves of Steel', $25, 87764, 384848, 09090)


  	  select  b.BId, b.Book_Name, b.Book_price,a.AId, a.Author_Name,  c.CId, c.Category, p.PId, p.Publisher
	  from Book b
	   join Publisher p on  b.PId = p.PId 
	   join Author a on  b.AId = a.AId 
	   join Category c on  b.CId = c.CId 


	