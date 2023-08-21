create database Assignment07Db
use Assignment07Db

create table Book(
BookId int primary key,
Title varchar(100) not null,
Author nvarchar(50) not null,
Genre nvarchar(50) not null,
Quantity int
)

INSERT INTO Book (BookId, Title, Author, Genre, Quantity)
VALUES
    (11, 'The Lord of the Rings', 'J.R.R. Tolkien', 'Fantasy', 10),
    (12, 'The Chronicles of Narnia', 'C.S. Lewis', 'Fantasy', 6),
    (13, 'Brave New World', 'Aldous Huxley', 'Science Fiction', 3),
    (14, 'Gone Girl', 'Gillian Flynn', 'Mystery', 8),
    (15, 'The Hunger Games', 'Suzanne Collins', 'Dystopian', 7);
	  Update Book set Genre ='Romance'  where BookId = 17
	select * from Book