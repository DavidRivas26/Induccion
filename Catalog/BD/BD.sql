create database Catalog
use Catalog

drop database Catalog

----------------------------------------------------------------------------------------------------------------------------------------- 

Create table Products
(
	Id_Product int identity,
	Id_Category_FK int,
	Name varchar(50),
	Description varchar(100),
	Stock int,
	Detail varchar(50),
	Status bit,
	Author varchar(50),
	Date_Creation date,
	Date_Update date
	Primary Key(Id_Product)
	Constraint FK_Categories Foreign Key (Id_Category_FK) References Categories(Id_Category) on delete cascade
)

Create Proc sp_create_product
	@Id_Category_FK int,
	@Name varchar(50),
	@Description varchar(100),
	@Stock int,
	@Detail varchar(50),
	@Status bit,
	@Author varchar(50),
	@Date_Creation date
As
Begin
	insert into Products(Id_Category_FK, Name, Description, Stock, Detail, Status, Author, Date_Creation)
	values(@Id_Category_FK, @Name, @Description, @Stock, @Detail, @Status, @Author, @Date_Creation)
End

Create Proc sp_update_product
	@Id_Product int,
	@Id_Category_FK int,
	@Name varchar(50),
	@Description varchar(100),
	@Stock int,
	@Detail varchar(50),
	@Status bit,
	@Author varchar(50),
	@Date_Update date
As
Begin
	update Products set Id_Category_FK = @Id_Category_FK, Name = @Name, Description = @Description, 
	Stock = @Stock, Detail=@Detail, Status = @Status, Author = @Author, Date_Update = @Date_Update where Id_Product = @Id_Product
End

Create Proc sp_update_product_detail
	@Id_Product int,
	@Detail varchar(50),
	@Date_Update date
As
Begin
	update Products set Detail=@Detail, Date_Update=@Date_Update where Id_Product = @Id_Product
End

Create Proc sp_delete_product
	@Id_Product int
As
Begin
	delete from Products where Id_Product = @Id_Product
End

Create Proc sp_get_all_product
As
Begin
	select Id_Product, Categories.Name as Category, Products.Name, Products.Description, Stock, Products.Detail, Products.Status, Products.Author,
	Products.Date_Creation, Products.Date_Update from Products inner join Categories on Products.Id_Category_FK = Categories.Id_Category
End

Create Proc sp_get_product_by_id
	@Id_Product int
As
Begin
	select Id_Product, Categories.Name as Category, Products.Name, Products.Description, Stock, Products.Detail, Products.Status, Products.Author,
	Products.Date_Creation, Products.Date_Update from Products inner join Categories on Products.Id_Category_FK = Categories.Id_Category
	where Id_Product = @Id_Product
End

Create Proc sp_get_product_by_category
	@Category varchar(50)
As
Begin
	select Id_Product, Categories.Name as Category, Products.Name, Products.Description, Stock, Products.Detail, Products.Status, Products.Author,
	Products.Date_Creation, Products.Date_Update from Products inner join Categories on Products.Id_Category_FK = Categories.Id_Category
	where Categories.Name = @Category
End

Create Proc sp_get_product_by_name
	@Name varchar(50)
As
Begin
	select Id_Product, Categories.Name as Category, Products.Name, Products.Description, Stock, Products.Detail, Products.Status, Products.Author,
	Products.Date_Creation, Products.Date_Update from Products inner join Categories on Products.Id_Category_FK = Categories.Id_Category
	where Products.Name = @Name
End

----------------------------------------------------------------------------------------------------------------------------------------- 

Create table Categories
(
	Id_Category int identity,
	Name varchar(50),
	Description varchar(100),
	Status bit,
	Author varchar(50),
	Date_Creation date,
	Date_Update date
	Primary Key(Id_Category)

)

Create Proc sp_create_category
	@Name varchar(50),
	@Description varchar(100),
	@Status bit,
	@Author varchar(50),
	@Date_Creation date
As
Begin
	insert into Categories(Name, Description, Status, Author, Date_Creation)
	values(@Name, @Description, @Status, @Author, @Date_Creation)
End

Create Proc sp_update_category
	@Id_Category int,
	@Name varchar(50),
	@Description varchar(100),
	@Status bit,
	@Author varchar(50),
	@Date_Update date
As
Begin
	update Categories set Name = @Name, Description = @Description, Status = @Status, 
	Author = @Author, Date_Update = @Date_Update where Id_Category = @Id_Category
End

Create Proc sp_delete_category
	@Id_Category int
As
Begin
	delete from Categories where Id_Category = @Id_Category
End

Create Proc sp_get_all_category
As
Begin
	select Id_Category, Name, Description, Status, Author, Date_Creation, Date_Update from Categories
End

Create Proc sp_get_category_by_id
	@Id_Category int
As
Begin
	select Id_Category, Name, Description, Status, Author, Date_Creation, Date_Update from Categories where Id_Category = @Id_Category
End

----------------------------------------------------------------------------------------------------------------------------------------- 

Create table Users
(
	Id_User int identity,
	Name varchar(50),
	LastName varchar(50),
	Address varchar(50),
	Phone varchar(50),
	Email varchar(50),
	Password varchar(100),
	Primary Key(Id_User)
)

Create Proc sp_create_user
	@Name varchar(50),
	@LastName varchar(50),
	@Address varchar(50),
	@Phone varchar(50),
	@Email varchar(50),
	@Password varchar(100)
As
Begin
	insert into Users(Name, LastName, Address, Phone, Email, Password)
	values(@Name, @LastName, @Address, @Phone, @Email, @Password)
End

Create Proc sp_update_user
	@Id_User int,
	@Name varchar(50),
	@LastName varchar(50),
	@Address varchar(50),
	@Phone varchar(50),
	@Email varchar(50),
	@Password varchar(100)
As
Begin
	update Users set Name=@Name, LastName=@LastName, Address=@Address, Phone=@Phone, Email=@Email, Password=@Password
	where Id_User = @Id_User
End

Create Proc sp_validate_user
	@Email varchar(50),
	@Password varchar(100)
As
Begin
	select Id_User, Name, LastName, Address, Phone, Email, Password from Users where Email = @Email and Password = @Password
End