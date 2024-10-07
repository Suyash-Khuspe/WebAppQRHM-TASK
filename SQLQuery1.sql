create database ProductDB

Create Table Product
(
	Id int Primary key identity(1,1),
	Name nvarchar(100) not null,
	Description nvarchar(200),
	Created datetime default getdate()
)

select * from product