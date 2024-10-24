--Assignment : 4

CREATE FUNCTION GetCustomerOrders
(
    @CustomerID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        O.order_id,
        O.order_date,
        SUM(OI.quantity * OI.list_price) AS TotalAmount  
    FROM 
        sales.orders O
        INNER JOIN sales.order_items OI ON O.order_id = OI.order_id
    WHERE 
        O.customer_id = @CustomerID  
    GROUP BY 
        O.order_id, O.order_date  
);

select * from GetCustomerOrders(1);