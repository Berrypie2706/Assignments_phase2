create database Assignment05Db
drop schema bank
create table bank.Customer(
CId int primary key,
CName nvarchar(50) not null,
CEmail nvarchar(50) not null unique,
Contact nvarchar(50) not null unique,
CPwd AS RIGHT(CName, 2) + CAST(CId AS VARCHAR(10)) + LEFT(Contact, 2) PERSISTED)

create table bank.MailInfo(
Mailto nvarchar(100),
MailDate date,
MailMessage nvarchar(MAX))

create trigger bank.trgMailToCust
on bank.Customer
after insert
as
begin
declare @id int
declare @name nvarchar(50)
declare @email nvarchar(50)
declare @contact nvarchar(50)
declare @pwd varchar(10)
declare @mailmessage nvarchar(MAX)
select @id = CId, @name = CName, @email = CEmail, @pwd = CPwd from inserted
select @mailmessage='Your netbanking password is: ' +@pwd + '. It is valid up to 2 days only. Update it.' 

insert into bank.MailInfo values(@email,getdate(), @mailmessage) 

if(@@ROWCOUNT>=1)
begin
print 'Record Inserted '
end 
end

insert into bank.Customer(CId, CName, CEmail, Contact) 
values
(234345, 'Adwit Nayak', 'adwit114@gmail.com', 9990002345),
(2343, ' Nayak', 'nayak@gmail.com', 9999902345)
(1001, 'Shweta soni', 'somi114@gmail.com', 8109161690)

select * from bank.Customer
select * from bank.MailInfo

