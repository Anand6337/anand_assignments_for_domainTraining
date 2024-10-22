--Assignment : 5

CREATE FUNCTION CalculateTotalSalesForProducts()
RETURNS @TotalSalesTable TABLE
(
    ProductID INT,
    ProductName VARCHAR(100),
    TotalSales DECIMAL(15, 2)
)
AS
BEGIN

    INSERT INTO @TotalSalesTable
    SELECT 
        P.product_id,
        P.product_name,
        SUM(OI.quantity * OI.list_price) AS TotalSales 
    FROM 
        production.products P
        INNER JOIN sales.order_items OI ON P.product_id = OI.product_id
    GROUP BY 
        P.product_id, P.product_name;

    RETURN;
END;

SELECT * 
FROM CalculateTotalSalesForProducts();
