CREATE TABLE Student (
Student_Id INT NOT NULL PRIMARY KEY,
FirstName NVARCHAR (150) NULL,
LastName NVARCHAR (150) NULL,
Address NVARCHAR (150) NULL
);

INSERT INTO Student (Student_Id, FirstName, LastName, Address)
VALUES	(001, 'Rogel', 'Ignacio', 'Polomolok, South Cotabato'),
		(002, 'Lisa', 'Lewis', 'Calumpang, General Santos City'),
		(003, 'Rosselyn', 'Cedeño', 'Davao del Sur');

SELECT * FROM Student;


CREATE TABLE Course (
Course_Id INT NOT NULL PRIMARY KEY,
Name NVARCHAR (150) NOT NULL,
Description NVARCHAR (300) NOT NULL
);

INSERT INTO Course (Course_Id, Name, Description)
VALUES	(1, 'DBM1', 'Database Management'),
		(2, 'SE1', 'Software Engineer');

SELECT * FROM Course;


CREATE TABLE Professor (
Professor_Id INT NOT NULL PRIMARY KEY,
FirstName NVARCHAR (150) NULL,
LastName NVARCHAR (150) NULL,
Address NVARCHAR (150) NULL
);

INSERT INTO Professor (Professor_Id, FirstName, LastName, Address)
VALUES	(1, 'Philip', 'Tampus', 'Davao City'),
		(2, 'Geoman', 'Yabes', 'San Isidro, General Santos City');

SELECT * FROM Professor;



CREATE TABLE ClassSchedule (
Class_Schedule_Id INT PRIMARY KEY,
Professor_Id INT FOREIGN KEY REFERENCES Professor (professor_id),
Course_Id INT FOREIGN KEY REFERENCES Course (course_id),
Room NVARCHAR (150) NOT NULL,
From_Time TIME NOT NULL,
To_Time TIME NOT NULL,
Days NVARCHAR (500) NOT NULL
);

INSERT INTO ClassSchedule (Class_Schedule_Id, Professor_Id, Course_Id, Room, From_Time, To_Time, Days)
VALUES	(1, '1', '1','GEMMA-1', '9:00AM', '11:00AM', 'M-W-F'),
		(2, '2', '1','GEMMA-1', '1:00PM', '3:00PM', 'M-W-F'),
		(3, '1', '2', 'SE-1','9:00AM', '11:00AM', 'T-TH-S');

SELECT * FROM ClassSchedule;




CREATE TABLE StudentCourse (
Student_Course_Id INT PRIMARY KEY,
Student_Id INT NOT NULL FOREIGN KEY REFERENCES Student (Student_Id),
Course_Id INT NOT NULL FOREIGN KEY REFERENCES Course (course_id),
Class_Schedule_Id INT NOT NULL FOREIGN KEY REFERENCES ClassSchedule (Class_Schedule_Id),
Enrollment_date TIME NOT NULL,
Units INT NOT NULL
);

INSERT INTO StudentCourse ( Student_Course_Id, Student_Id, Course_Id, Class_Schedule_Id, Enrollment_Date, Units)
VALUES	(1, '1', '1', '1','November 3, 2022 3:00pm', '3'),
		(2, '2', '1', '1', 'November 2, 2022 5:00pm', '3'),
		(3, '1', '2', '2', 'November 4, 2022 12:00pm', '3'),
		(4, '3', '2', '3', 'November 2, 2022 5:00pm', '3'),
		(5, '1', '1', '1', 'May 20, 2023 4:00pm', '3');

SELECT * FROM StudentCourse;


---- SQL INNER JOIN ----

SELECT 
s.student_Id,
s.LastName,
s.FirstName,
c.Name,
c.Description

FROM
	Student S
	INNER JOIN Course C ON c.course_Id = Course_Id;



---- SQL FULL OUTER JOIN ----


SELECT
ClassSchedule.Class_Schedule_Id,
ClassSchedule.Professor_Id,
ClassSchedule.Course_Id,
StudentCourse.Student_Course_Id,
StudentCourse.Student_Id,
ClassSchedule.Room,
ClassSchedule.From_Time,
ClassSchedule.To_Time,
ClassSchedule.Days,
StudentCourse.Units,
StudentCourse.Enrollment_Date

FROM
ClassSchedule
FULL OUTER JOIN StudentCourse ON ClassSchedule.Class_Schedule_Id=StudentCourse.Class_Schedule_Id;


------ SQL FULL OUTER JOIN ---- WITH NAMES

SELECT
Student.FirstName, student.LastName, Course.Course_Id, Course.Description


FROM
StudentCourse
JOIN Student ON StudentCourse.Student_Id = StudentCourse.Student_Id
JOIN Course ON StudentCourse.Course_Id = StudentCourse.Course_Id;






