--Example 1

Create procedure usDisplayMessage
As
Begin
Print 'Welcome to Hexaware Technologies'
End

Execute usDisplayMessage

--Example 2
Select * from production.products;

Create proc uspProductList
AS
Begin
select Product_name,list_price from production.products order by product_name
END

drop procedure uspProductList

exec uspProductList

--Example 3

Create proc InsertBrands
	@brand_id int,
	@brand_name varchar(255)
AS
Begin
	Insert into production.brands(brand_id,brand_name)values(@brand_id,@brand_name);
End

Exec InsertBrands
	@brand_id = 11,
	@brand_name = "Bajaj";


--Output parameter

Create procedure uspFindProductCountByModelYear
(@modelyear int, @prouctCount int OUTPUT)
As
Begin
select Product_name,list_Price from production.products
WHERE
model_year = @modelyear

select @prouctCount = @@ROWCOUNT
END

DECLAre @count int;
Exec uspFindProductCountByModelYear @modelyear= 2016, @prouctCount = @count OUT

select @count as 'Number of Products Found';

--Calling one stored proc in other one

Create proc usp_GetAllCustomers
As 
Begin
select * from sales.customers
End

usp_GetAllCustomers

Create proc usp_GetCustomerOrders
@customerId Int
AS
Begin
select * from sales.orders
where 
customer_id = @customerId
End

usp_GetCustomerOrders 1;

Create proc usp_GetCustomerData
@customerId Int
As
Begin
Exec usp_GetAllCustomers;
Exec usp_GetCustomerOrders @customerId;
End

exec usp_GetCustomerData 1;

--USD Function
--Scalar Valued Function

Create Function GetAllProducts()
Returns int
as
Begin
Return (Select Count(*) from production.products)
End

Print dbo.GetAllProducts()

--Table Valued Function
--Inline Table valued Function ==> Contain single select element

Create Function GetProductById(@productId int)
Returns Table
as
Return(Select *from production.products where product_id = @productId)

select * from GetProductById(4)