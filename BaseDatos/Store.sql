create database Store
use Store

Select * from Product

create table Category(
IdCategory int  primary key IDENTITY(1,1),
NameCategory varchar(120),
)

create table  Product (
IdProduct int  primary key IDENTITY(1,1)  ,
NameProduct varchar(120) not  null,
Price float not null , 
Discretion varchar(255) not null,
IdCategory int
FOREIGN KEY (IdCategory) REFERENCES  Category(IdCategory),

)

