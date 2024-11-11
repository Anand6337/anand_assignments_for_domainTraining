CREATE TABLE CUSTOMERS (
    customer_id INT PRIMARY KEY,
    Name VARCHAR(100),
    active BIT
);
CREATE TABLE ORDERS (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_status VARCHAR(100),
    FOREIGN KEY (customer_id) REFERENCES CUSTOMERS (customer_id)
);
INSERT INTO CUSTOMERS (customer_id, Name, active) VALUES 
(1, 'John Doe', 1),
(2, 'Jane Smith', 1),
(3, 'Robert Brown', 0),
(4, 'Lisa White', 1),
(5, 'Michael Green', 0);
INSERT INTO ORDERS (order_id, customer_id, order_status) VALUES 
(101, 1, 'Shipped'),
(102, 2, 'Pending'),
(103, 1, 'Delivered'),
(104, 4, 'Cancelled'),
(105, 5, 'Processing');

--Transaction A

BEGIN TRANSACTION;
    -- Update customer name where customer_id = 1
    UPDATE CUSTOMERS 
    SET Name = 'John'
    WHERE customer_id = 1;

    -- Introduce a delay of 5 seconds
    WAITFOR DELAY '00:00:05';

    -- Update the order status where order_id = 101
    UPDATE ORDERS 
    SET order_status = 'Processed'
    WHERE order_id = 101;

COMMIT TRANSACTION;

--Transaction B
BEGIN TRANSACTION;
    -- Update the order status where order_id = 101
    UPDATE ORDERS 
    SET order_status = 'Shipped'
    WHERE order_id = 101;

    -- Introduce a delay of 5 seconds
    WAITFOR DELAY '00:00:05';

    -- Update customer name where customer_id = 1
    UPDATE CUSTOMERS 
    SET Name = 'Geetha'
    WHERE customer_id = 1;

COMMIT TRANSACTION;

