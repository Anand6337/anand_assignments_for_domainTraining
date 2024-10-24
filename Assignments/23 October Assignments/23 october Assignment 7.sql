--Assignment 7--

CREATE TABLE Stock (
    product_id INT PRIMARY KEY,
    quantity INT
);

CREATE TABLE order_items (
    order_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (order_id) REFERENCES sales.orders(order_id)
);

CREATE TRIGGER trg_UpdateStockOnNewOrder
ON order_items
AFTER INSERT
AS
BEGIN

    DECLARE @ProductId INT, @Quantity INT;

    SELECT @ProductId = product_id, @Quantity = quantity
    FROM inserted;  


    UPDATE Stock
    SET quantity = quantity - @Quantity
    WHERE product_id = @ProductId;


    IF EXISTS (SELECT * FROM Stock WHERE product_id = @ProductId AND quantity < 0)
    BEGIN

        ROLLBACK TRANSACTION;
        PRINT 'Insufficient stock! Rolling back transaction.';
    END
END;

SELECT * FROM Stock WHERE product_id = 1;

