--Assignment 8--

CREATE TRIGGER trg_PreventCustomerDeletion
ON sales.customers
INSTEAD OF DELETE
AS
BEGIN
    -- Declare variables to hold customer ID
    DECLARE @CustomerId INT;

    -- Get the customer ID from the row(s) being deleted
    SELECT @CustomerId = customer_id FROM deleted;

    -- Check if the customer has any orders
    IF EXISTS (SELECT 1 FROM orders WHERE customer_id = @CustomerId)
    BEGIN
        -- If customer has orders, prevent deletion and print message
        PRINT 'Cannot delete customer. They have existing orders.';
    END
    ELSE
    BEGIN
        -- If no orders exist, proceed with deletion
        DELETE FROM CUSTOMERS WHERE customer_id = @CustomerId;
        PRINT 'Customer deleted successfully.';
    END
END;

INSERT INTO sales.customers (customer_id, Name, active) VALUES (3, 'John', 1);
INSERT INTO sales.orders (customer_id,order_date ,order_status,staff_id) VALUES (3,22/02/2025, 0,1);
