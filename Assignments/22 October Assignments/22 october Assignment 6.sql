--Assignment : 6

CREATE FUNCTION GetCustomerTotalSpent()
RETURNS @CustomerTotalSpent TABLE
(
    CustomerID INT,
    CustomerName VARCHAR(100),
    TotalAmountSpent DECIMAL(15, 2)
)
AS
BEGIN
    INSERT INTO @CustomerTotalSpent
    SELECT 
        C.customer_id,
        C.first_name,
        SUM(OI.quantity * OI.list_price) AS TotalAmountSpent  
    FROM 
        sales.customers C
        INNER JOIN sales.orders O ON C.customer_id = O.customer_id
        INNER JOIN sales.order_items OI ON O.order_id = OI.order_id
    GROUP BY 
        C.customer_id, C.first_name; 

    RETURN;
END;

SELECT * 
FROM GetCustomerTotalSpent();

