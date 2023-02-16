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
	[s_id] int  identity(1,1) NOT NULL,
    [skill_id] VARCHAR(3) NOT NULL,
    [skill_name] VARCHAR(30) ,
	CONSTRAINT [pk_skill] PRIMARY KEY ([s_id]),
	CONSTRAINT [fk_skill] FOREIGN KEY(skill_id) REFERENCES [User](user_id)  ON DELETE CASCADE
);

SELECT[skill_id],[skill_name] FROM [Skills];


-- Create Company Table
CREATE TABLE [Company](
	[c_id] int identity(1,1) NOT NULL,
	[company_id] VARCHAR(3) NOT NULL,
    [company_name] VARCHAR(30),
    [industry] VARCHAR(40),
	[duration] VARCHAR (20),
	CONSTRAINT [pk_company] PRIMARY KEY ([c_id]),
    CONSTRAINT [fk_company] FOREIGN KEY([company_id]) REFERENCES [User](user_id)  ON DELETE CASCADE 
);

SELECT [c_id],[company_id],[company_name],[industry],[duration] FROM [Company];

-- Create Education_Details
CREATE TABLE [Education_Details](
	[e_id] int identity(1,1) NOT NULL,
    [education_id] VARCHAR(3) NOT NULL,
    [education_name] VARCHAR(30),
	[institute_name] VARCHAR(50),
	[grade] VARCHAR (10),
	[duration] Varchar(20),
	CONSTRAINT [pk_education] PRIMARY KEY ([e_id]),
    CONSTRAINT [fk_education] FOREIGN KEY([education_id]) REFERENCES [User](user_id)  ON DELETE CASCADE
);

SELECT [e_id],[education_id],[education_name],[institute_name],[grade],[duration] FROM [Education_Details];

--Inserting Data Into Tables :-
--Inserting Data Into [User] Table

INSERT INTO [User]([user_id], [Email] ,[password] ,[first_name],[middle_name], [last_name] , [gender] , [pincode] , [website] , [mobile_number] , [about_me]) 
VALUES ('222' ,'venkat123@gmail.com', 'Venkat123@','Chuka','Venkat','Teza','Others',800006,'http:/chukka@google.com',9876543210,'I am a quick learner.'),
('321' , 'arshad123@gmail.com' , 'Arshad123@' , 'Arshad' , 'Ahmed' , 'Khan','Male' , 800006,'http:/ahmed.com' , 8767876787,'Everyone Knows About me.'),
('333' , 'rizwan123@gmail.com' , 'Rizwan123@' , 'Rizwan' , 'Ahmed' , 'Khan','Male' , 556004,'http:/rizwan.com' , 987678543,'Hard Working Person.');

--Inserting Data Into [Skills] Table
INSERT INTO [Skills]([skill_id],[skill_name])
VALUES ('321','Java'),
('321','C#'),
('222','SQL'),
('222','Java'),
('333','C#'),
('333','Java');

--Insert Into [Skills] ([skill_name]) Values ('C++') WHERE [skill_id] = 321;

--Inserting Data Into [Company] Table
INSERT INTO [Company]([company_id],[company_name],[industry],[duration])
VALUES('321','Revature','Junior Developer','1 Year and 3 Months'),
('321','Wipro','Senior Developer','1 Year and 9 Months'),
('222','TCS','Junior Developer','2 Years'),
('222','Revature','Team Manager','2 Years'),
('333','STL','Junior Developer','3 Years');

--Inserting Data Into [Education_Details] Table
INSERT INTO [Education_Details]([education_id],[education_name],[institute_name],[grade],[duration])
VALUES ('321','12th','Chadighar Higher secondary School','A','2 Years'),
('321','B-Tech','Chandighar University','8.5 gpa','4 Years'),
('222','12th','Delhi Higher secondary School','A+','2 Years'),
('222','B-Tech','Delhi University','9.5 gpa','4 Years'),
('333','12th','Siliguri Higher secondary School','B+','2 Years'),
('333','B-Tech','Siliguri University','8.8 gpa','4 Years');


-- Showing all the details which was inserted into the tables
SELECT * FROM [Skills];
SELECT * FROM [User];
SELECT * FROM [Education_Details];
SELECT * FROM [Company];

-- For Droping the tables
drop table [User]
drop table [Skills]
drop table [Company]
drop table [Education_Details]

