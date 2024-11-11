select * from sales.customers

Create Unique Index idx_unique_email
ON sales.customers(email)


CREATE TABLE tblDepartment
(
    DeptId INT PRIMARY KEY,
    DeptName NVARCHAR(29)
);

INSERT INTO tblDepartment (DeptId, DeptName) VALUES 
(1, 'IT'),
(2, 'Payroll'),
(3, 'HR'),
(4, 'Admin');

CREATE TABLE tblEmployee
(
    Id INT PRIMARY KEY,
    Name NVARCHAR(50),
    Salary DECIMAL(10, 2),
    Gender NVARCHAR(10),
    DeptId INT,
    FOREIGN KEY (DeptId) REFERENCES tblDepartment(DeptId)
);

INSERT INTO tblEmployee (Id, Name, Salary, Gender, DeptId) VALUES 
(1, 'John', 5000, 'Male', 3),
(2, 'Mike', 3400, 'Male', 2),
(3, 'Pam', 6000, 'Female', 1),
(4, 'Todd', 4800, 'Male', 4),
(5, 'Sara', 3200, 'Female', 1),
(6, 'Ben', 4800, 'Male', 3);

SELECT 
    e.Id, 
    e.Name, 
    e.Salary, 
    e.Gender, 
    d.DeptName 
FROM 
    tblEmployee e
JOIN 
    tblDepartment d ON e.DeptId = d.DeptId;


CREATE VIEW vwEmployeesByDepartment AS
SELECT 
    e.Id, 
    e.Name, 
    e.Salary, 
    e.Gender, 
    d.DeptName 
FROM 
    tblEmployee e
JOIN 
    tblDepartment d ON e.DeptId = d.DeptId;

SELECT * FROM vwEmployeesByDepartment;


UPDATE tblEmployee
SET Gender = 'Male' 
WHERE Id = 3;

--View that returns only IT department
CREATE VIEW VWITDepartmentEmployees AS
SELECT 
    e.Id, 
    e.Name, 
    e.Salary, 
    e.Gender, 
    d.DeptName
FROM 
    tblEmployee e
JOIN 
    tblDepartment d ON e.DeptId = d.DeptId 
WHERE 
    d.DeptName = 'IT';

SELECT * FROM VWITDepartmentEmployees;

CREATE VIEW VWEmployeesNonConfidentialData AS
SELECT 
    e.Id, 
    e.Name, 
    e.Gender, 
    d.DeptName
FROM 
    tblEmployee e
JOIN 
    tblDepartment d ON e.DeptId = d.DeptId;

--example for instead of trigger
create view vwEmployeeDetails
as

select Id,Name,Gender, DeptName from dbo.Employee e
join dbo.Department d
on e.id = d.DeptId

select * from vwEmployeeDetails
insert vwEmployeeDetails values(7,'Tina','Female','HR')

create trigger tr_vwEmployeeDetails_InsteadOfInsert
on vwEmployeeDetails
as
begin
declare @dentId int
select @deptId = DeptId from dbo.Department
join inserted 
on inserted.DeptName = dbo.Department.DeptName

if(@deptId is null)
begin 
RaiseError('Invalid Department Name .Statement Terminated',16,1)
end

inserted into tblEmployee(Id,Name,Gender,DepartmentId)
select Id,Name,Gender,@deptId
from inserted
end

insert vwEmplyeeDetails values(7,'Tina','Female','HR')

create trigger tr_vwEmployeeDetails





BEGIN TRANSACTION;

-- Insert into sales.orders table
INSERT INTO sales.orders 
    (customer_id, order_status, order_date, required_date, shipped_date, store_id, staff_id) 
VALUES 
    (49, 4, '2017-02-28', '2017-03-01', '2017-03-02', 2, 6);

-- Insert into sales.order_items table
INSERT INTO sales.order_items 
    (order_id, item_id, product_id, quantity, list_price, discount) 
VALUES 
    (93, 1, 8, 2, 269.99, 0.07);

-- Check for any errors
IF @@ERROR = 0
BEGIN
    COMMIT TRANSACTION;
    PRINT 'Insertion Successful!...';
END
ELSE
BEGIN
    ROLLBACK TRANSACTION;
    PRINT 'Something went wrong during the insertion';
END;

-- Select the inserted product from production.products table
SELECT * FROM production.products 
WHERE product_id = 8;
