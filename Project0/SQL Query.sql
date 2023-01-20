-- Create User Table
CREATE TABLE [User](
    [user_id] VARCHAR(3) ,
    [first_name] VARCHAR(25) ,
	[middle_name] VARCHAR(25) ,
	[last_name] VARCHAR(25) ,
	[gender] VARCHAR(6),
	[pincode] VARCHAR (6),
    [Email] VARCHAR(25) UNIQUE NOT NULL,
	[website] VARCHAR(40) UNIQUE,
    [mobile_number] VARCHAR(10) ,
    [password] VARCHAR(25) NOT NULL,
	[about_me] VARCHAR(max),
    CONSTRAINT [pk_user] PRIMARY KEY([user_id])

);
SELECT [user_id],[first_name],[middle_name],[last_name],[gender],[pincode],[Email],[website],[mobile_number],[password],[about_me] FROM [User];

-- Create Skills Table
CREATE TABLE [Skills](
    [skill_id] VARCHAR(3) NOT NULL,
    [skill_name] VARCHAR(30) ,
	CONSTRAINT [fk_skill] FOREIGN KEY(skill_id) REFERENCES [User](user_id)  ON DELETE CASCADE
);
SELECT [skill_id],[skill_name] FROM [Skills];

-- Create Company Table
CREATE TABLE [Company](
	[company_id] VARCHAR(3) NOT NULL,
    [company_name] VARCHAR(30),
    [industry] VARCHAR(40),
	[duration] VARCHAR (20),
    CONSTRAINT [fk_company] FOREIGN KEY([company_id]) REFERENCES [User](user_id)  ON DELETE CASCADE 
);
SELECT [company_id],[company_name],[industry],[duration] FROM [Company];

-- Create Education_Details
CREATE TABLE [Education_Details](
    [education_id] VARCHAR(3) NOT NULL,
    [education_name] VARCHAR(30),
	[institute_name] VARCHAR(50),
	[grade] VARCHAR (10),
	[duration] Varchar(20),
    CONSTRAINT [fk_education] FOREIGN KEY([education_id]) REFERENCES [User](user_id)  ON DELETE CASCADE
);
SELECT [education_id],[education_name],[institute_name],[grade],[duration] FROM [Education_Details];

--Inserting Data Into Tables :-
--Inserting Data Into [User] Table
INSERT INTO [User]([user_id],[first_name],[middle_name],[last_name],[gender],[pincode],[Email],[website],[mobile_number],[password],[about_me])
Values('111','Chuka','Venkat','Teza','Others',564721,'venkat123@gmail.com','http:/chukka@google.com',9876543210,'venkat123','I am a quick learner.'),
('222','Arshad','Ahmed','Khan','Female',564721,'arshad123@gmail.com','http:arshad/@google.com',9876543211,'arshad123','I am passinate about my work.'),
('333','Rizwan','','Ahmed','Male',564723,'rizwan123@gmail.com','http:/rizwan@google.com',9876543212,'rizwan123','I am intrested in C#.');

--Inserting Data Into [Skills] Table
INSERT INTO [Skills]([skill_id],[skill_name])
VALUES ('111','Java'),
('111','C#'),
('111','SQL'),
('222','SQL'),
('222','Java'),
('333','C#'),
('333','Java');

--Inserting Data Into [Company] Table
INSERT INTO [Company]([company_id],[company_name],[industry],[duration])
VALUES('111','Revature','Junior Developer','1 Year and 3 Months'),
('111','Wipro','Senior Developer','1 Year and 9 Months'),
('222','TCS','Junior Developer','2 Years'),
('222','Revature','Team Manager','2 Years'),
('333','STL','Junior Developer','3 Years');

--Inserting Data Into [Education_Details] Table
INSERT INTO [Education_Details]([education_id],[education_name],[institute_name],[grade],[duration])
VALUES ('111','12th','Chadighar Higher secondary School','A','2 Years'),
('111','B-Tech','Chandighar University','8.5 gpa','4 Years'),
('222','12th','Delhi Higher secondary School','A+','2 Years'),
('222','B-Tech','Delhi University','9.5 gpa','4 Years'),
('333','12th','Siliguri Higher secondary School','B+','2 Years'),
('333','B-Tech','Siliguri University','8.8 gpa','4 Years');


-- Showing all the details which was inserted into the tables

SELECT * FROM [User];
SELECT * FROM [Skills];
SELECT * FROM [Company];
SELECT * FROM [Education_Details];

-- For Droping the tables
drop table [User]
drop table [Skills]
drop table [Company]
drop table [Education_Details]

--Inserting One Detail
SELECT [user_id],[first_name],[middle_name],[last_name],[gender],[pincode],[Email],[website],[mobile_number],[password],[about_me] FROM [User] WHERE [user_id] = 111;

-- Modify
Update [User] SET [first_name] = 'Aman' WHERE [user_id] = '111';
Update [Skills] SET [skill_name] = 'Java' WHERE [skill_name] = 'New' AND [skill_id] = '111';
Update [Education_Details] SET [education_name] = '10th' WHERE [education_name] = 'B-Tech' AND [education_id] = '111';
Update [Company] SET [company_name] = 'STL' WHERE [company_name] = 'Revature' AND [company_id] = '111';

SELECT [first_name],[middle_name],[last_name],[gender],[pincode],[website],[mobile_number],[about_me] FROM [User] WHERE [user_id] = 111;

--Deleting
DELETE FROM [User] WHERE [gender] = 'Male';
DELETE FROM [User] WHERE [user_id] = '999';
