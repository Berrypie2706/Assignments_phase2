create database Assignment11Db
use Assignment11Db

create table Article(
ArticleId int primary key,
Title nvarchar(300),
Content nvarchar(300),
PublishDate date)

INSERT INTO Article (ArticleId, Title, Content, PublishDate)
VALUES

    (1, 'Introduction to SQL', 'SQL is a domain-specific language...', '2023-08-25'),
    (2, 'Data Modeling Basics', 'Data modeling is a crucial...', '2023-08-26'),
    (3, 'Advanced Query Optimization', 'Query optimization involves...', '2023-08-27'),
    (4, 'Understanding Indexes', 'Indexes are used to speed up...', '2023-08-28'),
    (5, 'Normalization Explained', 'Database normalization is the process...', '2023-08-29'),
    (6, 'Security Best Practices for Databases', 'Securing your database is essential...', '2023-08-30'),
    (7, 'In-Memory Databases', 'In-memory databases store...', '2023-08-31'),
	(8, 'In-Memory Databases', 'In-memory databases store...', '2023-08-31')
	

	select * from Article