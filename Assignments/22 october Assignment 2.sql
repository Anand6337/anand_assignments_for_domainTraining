--Assignment : 2

CREATE TABLE Department (
    ID INT PRIMARY KEY, 
    Name VARCHAR(100)
);

INSERT INTO Department (ID, Name)
VALUES (1, 'HR'),(2, 'IT'),(3, 'Finance');

CREATE TABLE Employee (
    ID INT PRIMARY KEY,
    Name VARCHAR(100),
    Gender CHAR(1), 
    DOB DATE,
    DeptID INT FOREIGN KEY REFERENCES Department(ID)  
);

INSERT INTO Employee (ID, Name, Gender, DOB, DeptID)
VALUES
    (1, 'Daksh Yadav', 'M', '1990-05-15', 2),
    (2, 'Srinithi', 'F', '1985-08-20', 1),
    (3, 'Sanskar', 'M', '1992-12-03', 3),
    (4, 'Adarsh', 'F', '1988-04-10', 2);

--Procedure to Update Employee Details Based on Employee ID

Create Proc UpdateEmployeeDetails
	@EmployeeId int,@Name varchar(10), @Gender char(1),@DOB date, @DeptId int
AS
Begin
	Update Employee set Name = @Name, Gender = @Gender, DOB = @DOB, DeptID = @DeptId
	Where ID = @EmployeeId
End;


Exec UpdateEmployeeDetails
	@EmployeeId = 1,
	@Name = 'Anand',
	@Gender = 'M',
	@DOB = '2003-06-06',
	@DeptId = 2;

select * from Employee

--Procedure to Get Employee Information by Gender and Department ID

Create Proc GetEmployeeByGenderandDept
	@Gender Char(1),
	@DeptId int
As
Begin
	select ID,Name,Gender,DOB,DeptID
	From Employee
	Where Gender = @Gender and DeptID = @DeptId;
End;

Exec GetEmployeeByGenderandDept
	@Gender = 'F',
	@DeptId = 2;

--Procedure to Get Count of Employees Based on Gender
Create Proc GetEmployeeCountByGender
	@Gender Char(1)
As
Begin
	Select Count(*) as Employee_Count
	from Employee Where Gender = @Gender;
End;

Exec GetEmployeeCountByGender
	@Gender = 'M';