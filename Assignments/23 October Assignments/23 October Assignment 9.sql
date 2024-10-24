--Assignment 9--

CREATE TABLE Employee_Audit (
    audit_id INT IDENTITY(1,1) PRIMARY KEY,
    employee_id INT,
    name VARCHAR(100),
    position VARCHAR(100),
    salary DECIMAL(10, 2),
    operation_type VARCHAR(10), -- 'INSERT', 'UPDATE', or 'DELETE'
    operation_time DATETIME DEFAULT GETDATE()
);

CREATE TRIGGER trg_LogEmployeeChanges
ON Employee
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    -- Log Inserted Data (for INSERT or UPDATE)
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO Employee_Audit (employee_id, name, position, salary, operation_type)
        SELECT Id, name, Dept, Salary, 
               CASE 
                   WHEN EXISTS (SELECT * FROM deleted) THEN 'UPDATE'
                   ELSE 'INSERT'
               END
        FROM inserted;
    END
    
    -- Log Deleted Data (for DELETE)
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO Employee_Audit (employee_id, name, position, salary, operation_type)
        SELECT Id, name, Dept, Salary, 'DELETE'
        FROM deleted;
    END
END;

INSERT INTO Employee (Id, Name, Dept, salary) 
VALUES (3, 'Sarah Connor', 'Analyst', 50000);

UPDATE Employee
SET salary = 62000
WHERE Id = 1;

DELETE FROM Employee
WHERE Id = 2;

select * from Employee

