--Assignment Question 1

CREATE PROCEDURE GetCustomersByProduct
    @product_id INT  
AS
BEGIN

    SELECT 
        C.customer_id,
        C.first_name,
        O.order_date AS PurchaseDate
    FROM 
        sales.customers C
        INNER JOIN sales.orders O ON C.customer_id = O.customer_id
        INNER JOIN sales.order_items OI ON O.order_id = OI.order_id
    WHERE 
        OI.product_id = @product_id;  
END;

Drop procedure GetCustomersByProduct


Exec GetCustomersByProduct @product_id = 15;

select * from production.products