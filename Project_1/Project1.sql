Create Database Project1;
use [Project1];
-- Create User Table
CREATE TABLE [User](
    [user_id] VARCHAR(3) ,
	[Email] VARCHAR(25) UNIQUE NOT NULL,
	[password] VARCHAR(25) NOT NULL,
    [first_name] VARCHAR(25) ,
	[middle_name] VARCHAR(25) ,
	[last_name] VARCHAR(25) ,
	[gender] VARCHAR(6),
	[pincode] VARCHAR (6),
	[website] VARCHAR(40) UNIQUE,
    [mobile_number] VARCHAR(10) ,
	[about_me] VARCHAR(max),
    CONSTRAINT [pk_user] PRIMARY KEY([user_id])

);

SELECT [user_id],[first_name],[middle_name],[last_name],[gender],[pincode],[Email],[website],[mobile_number],[password],[about_me] FROM [User];

-- Create Skills Table
CREATE TABLE [Skills](
	[s_id] int NOT NULL,
    [skill_id] VARCHAR(3) NOT NULL,
    [skill_name] VARCHAR(30) ,
	CONSTRAINT [pk_skill] PRIMARY KEY ([skill_name] , [s_id]),
	CONSTRAINT [fk_skill] FOREIGN KEY(skill_id) REFERENCES [User](user_id)  ON DELETE CASCADE
);

SELECT [s_id],[skill_id],[skill_name] FROM [Skills];


-- Create Company Table
CREATE TABLE [Company](
	[c_id] int NOT NULL,
	[company_id] VARCHAR(3) NOT NULL,
    [company_name] VARCHAR(30),
    [industry] VARCHAR(40),
	[duration] VARCHAR (20),
	CONSTRAINT [pk_company] PRIMARY KEY ([company_name] , [c_id]),
    CONSTRAINT [fk_company] FOREIGN KEY([company_id]) REFERENCES [User](user_id)  ON DELETE CASCADE 
);

SELECT [c_id],[company_id],[company_name],[industry],[duration] FROM [Company];

-- Create Education_Details
CREATE TABLE [Education_Details](
	[e_id] int NOT NULL,
    [education_id] VARCHAR(3) NOT NULL,
    [education_name] VARCHAR(30),
	[institute_name] VARCHAR(50),
	[grade] VARCHAR (10),
	[duration] Varchar(20),
	CONSTRAINT [pk_education] PRIMARY KEY ([education_name] , [e_id]),
    CONSTRAINT [fk_education] FOREIGN KEY([education_id]) REFERENCES [User](user_id)  ON DELETE CASCADE
);

SELECT [e_id],[education_id],[education_name],[institute_name],[grade],[duration] FROM [Education_Details];

--Inserting Data Into Tables :-
--Inserting Data Into [User] Table

INSERT INTO [User]([user_id], [Email] ,[password] ,[first_name],[middle_name], [last_name] , [gender] , [pincode] , [website] , [mobile_number] , [about_me]) 
VALUES ('321' ,'venkat123@gmail.com', 'Venkat123@','Chuka','Venkat','Teza','Others',564721,'http:/chukka@google.com',9876543210,'I am a quick learner.'),
('222' , 'arshad123@gmail.com' , 'Arshad123@' , 'Arshad' , 'Ahmed' , 'Khan','Female' , 500004,'http:/ahmed.com' , 8767876787,'Everyone Knows About me.'),
('333' , 'rizwan123@gmail.com' , 'Rizwan123@' , 'Rizwan' , 'Ahmed' , 'Khan','Male' , 556004,'http:/rizwan.com' , 987678543,'Hard Working Person.');

--Inserting Data Into [Skills] Table
INSERT INTO [Skills]([s_id],[skill_id],[skill_name])
VALUES (1,'321','Java'),
(2,'321','C#'),
(3,'222','SQL'),
(4,'222','Java'),
(5,'333','C#'),
(6,'333','Java');

--Insert Into [Skills] ([skill_name]) Values ('C++') WHERE [skill_id] = 321;

--Inserting Data Into [Company] Table
INSERT INTO [Company]([c_id],[company_id],[company_name],[industry],[duration])
VALUES(1,'321','Revature','Junior Developer','1 Year and 3 Months'),
(2,'321','Wipro','Senior Developer','1 Year and 9 Months'),
(3,'222','TCS','Junior Developer','2 Years'),
(4,'222','Revature','Team Manager','2 Years'),
(5,'333','STL','Junior Developer','3 Years');

--Inserting Data Into [Education_Details] Table
INSERT INTO [Education_Details]([e_id],[education_id],[education_name],[institute_name],[grade],[duration])
VALUES (1,'321','12th','Chadighar Higher secondary School','A','2 Years'),
(2,'321','B-Tech','Chandighar University','8.5 gpa','4 Years'),
(3,'222','12th','Delhi Higher secondary School','A+','2 Years'),
(4,'222','B-Tech','Delhi University','9.5 gpa','4 Years'),
(5,'333','12th','Siliguri Higher secondary School','B+','2 Years'),
(6,'333','B-Tech','Siliguri University','8.8 gpa','4 Years');


-- Showing all the details which was inserted into the tables

SELECT * FROM [User];
SELECT * FROM [Skills];
SELECT * FROM [Company];
SELECT * FROM [Education_Details];

insert into [User] ([user_id] ,[Email],[password]) Values ('999','manoj123@gmail.com' , 'Manoj123@');

-- For Droping the tables
drop table [User]
drop table [Skills]
drop table [Company]
drop table [Education_Details]

ALTER TABLE [User]
DROP CONSTRAINT UQ__User__2B1892FF6CB80CA9 ;

ALTER TABLE [User]
DROP CONSTRAINT UQ__User__A9D10534FE66FA82 ;

--Inserting One Detail
SELECT [user_id],[Email],[password],[first_name],[middle_name],[last_name],[gender],[pincode],[website],[mobile_number],[about_me] FROM [User] WHERE [user_id] = 111;

-- Modify
Update [User] SET [first_name] = 'Aman' WHERE [user_id] = '111';
Update [Skills] SET [skill_name] = 'Java' WHERE [skill_name] = 'New' AND [skill_id] = '111';
Update [Education_Details] SET [education_name] = '10th' WHERE [education_name] = 'B-Tech' AND [education_id] = '111';
Update [Company] SET [company_name] = 'STL' WHERE [company_name] = 'Revature' AND [company_id] = '111';

SELECT [first_name],[middle_name],[last_name],[gender],[pincode],[website],[mobile_number],[about_me] FROM [User] WHERE [user_id] = 111;

--Deleting
DELETE FROM [User] WHERE [gender] = 'Male';
DELETE FROM [Skills] WHERE [skill_name] = 'C++';
DELETE FROM [User] WHERE [user_id] = '999';

DELETE FROM [Education_Details] WHERE [education_name] = '10th' AND [education_id] = '004';

Insert Into [Skills] ([s_id],[skill_id] , [skill_name]) Values (7,'003' , 'C++');

Update [Skills] SET [skill_name] = 'C#' WHERE [skill_name] = 'C++' AND [skill_id] = '003';


UPDATE [User]([first_name],[middle_name], [last_name] , [gender] , [pincode] , [website] , [mobile_number] , [password] , [about_me] )
Values ('Chuka','Venkat','Teza','Others',564721,'venkat123@gmail.com','http:/chukka@google.com',9876543210,'Venkat123@','I am a quick learner.') 
WHERE [user_id] = 123 

update [User] set [first_name] = 'manoj', [middle_name] = 'dbak', [last_name] = 'KJb' , [gender] = 'male'  , [pincode] = '888114', [website] = 'afbla'  , [mobile_number] = '6789778754' , [about_me] = '1319kjabck'  where [user_id] = 123
