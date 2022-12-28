CREATE TABLE [Department](
    [ID] INT PRIMARY KEY,
    [Name] VARCHAR(40) NOT NULL,
    [Location] VARCHAR(40) NOT NULL,
);

SELECT * from [Department];

CREATE TABLE [Employee](
    [ID] INT IDENTITY(1,1) PRIMARY key, 
    [FirstName] VARCHAR(30) NOT NULL,
    [LastName] VARCHAR(30) NOT NULL,
    [SSN] bigint ,
    [DeptID] INT  FOREIGN KEY REFERENCES Department([ID])
);

SELECT * FROM Employee;

CREATE TABLE [EmpDetails](
    [EmployeeID] INT IDENTITY(1,1) FOREIGN KEY REFERENCES Employee([ID]),
    [id] INT  PRIMARY KEY,
    [Salary] INT NOT NULL,
    [Address 1] VARCHAR(MAX) ,
    [Address 2] VARCHAR(MAX) ,
    [City] VARCHAR (30) NOT NULL,
    [State] VARCHAR(30) NOT NULL,
    [Countary] VARCHAR(30) NOT NULL,
);

SELECT * from [EmpDetails];

INSERT INTO [Department]
VALUES('1','Software','Chennai'),
('2','Sales','Noida'),
('3','Marketing','Chennai');

SELECT * from [Department];

ALTER TABLE [Employee]
DROP CONSTRAINT FK__Employee__DeptID__74AE54BC ;

INSERT INTO [Employee] 
VALUES ('Aman','Shankar' ,'974932433','1'),
('Abhimanyu','Singh' ,'974937353','2'),
('Ranjit','Sharma' ,'872932433','3');
--add employee Tina Smith

INSERT INTO [Employee] 
VALUES ('Tina','Smith','093108311','3');

SELECT * FROM Employee;

ALTER TABLE [EmpDetails]
DROP CONSTRAINT FK__EmpDetail__Emplo__7D439ABD ;

INSERT INTO [EmpDetails]
VALUES ('1','2400','BTM Stage 1','' , 'Bengaluru', 'Karnatka','India'),
('2','4300','Mouar Lane','' , 'Patna', 'Bihar','India'),
('3','4500','Zill 75','' , 'Mirzapur', 'UP','India')

SELECT * from [EmpDetails];



SELECT * FROM Employee;

--add department Marketing

INSERT INTO [Department] 
VALUES ('6','Marketing','Bihar');

SELECT * From Department;

--list all employees in marketing
SELECT * FROM Employee as e1
INNER JOIN  EmpDetails as e2
on e2.EmployeeID = e1.id
WHERE e1.DeptID = 3;


--report total salary of marketing
SELECT sum(Salary) as totalSalary From Employee as e1
INNER JOIN EmpDetails as e2 ON
e2.EmployeeID = e1.id
WHERE e1.DeptID =3 ;

--report total employee by Department

SELECT DeptID COUNT(*)
FROM Employee
GROUP BY DeptId;

--increase salary of Tina Smith to 90000

UPDATE EmpDetails 
SET Salary = '90000'
WHERE id = '4';