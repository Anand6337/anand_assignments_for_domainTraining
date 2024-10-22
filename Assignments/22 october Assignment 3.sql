--Assignment : 3

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Price DECIMAL(10, 2)  
);

INSERT INTO Products (ProductID, ProductName, Price)
VALUES
    (1, 'Laptop', 50000.00),
    (2, 'Smartphone', 30000.00),
    (3, 'Headphones', 1500.00),
    (4, 'Monitor', 8000.00);


CREATE FUNCTION CalculateTotalPrice
(
    @ProductID INT,
    @Quantity INT
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @Price DECIMAL(10, 2);

    SELECT @Price = Price 
    FROM Products 
    WHERE ProductID = @ProductID;


    RETURN @Price * @Quantity;
END;

SELECT dbo.CalculateTotalPrice(1, 2) AS TotalPrice;




