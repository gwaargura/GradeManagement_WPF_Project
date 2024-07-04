USE [master]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'G6_FinalAssignment')
BEGIN
	ALTER DATABASE G6_FinalAssignment SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE G6_FinalAssignment SET ONLINE;
	DROP DATABASE G6_FinalAssignment;
END

GO

CREATE DATABASE G6_FinalAssignment
GO

USE G6_FinalAssignment
GO

CREATE TABLE Students (
    student_id INT PRIMARY KEY,
    student_name NVARCHAR(50),
    password NVARCHAR(50)
);

CREATE TABLE Teachers (
    teacher_id INT PRIMARY KEY,
    teacher_name NVARCHAR(50),
    password NVARCHAR(50)
);

CREATE TABLE Classes (
    class_id INT PRIMARY KEY,
    class_name NVARCHAR(50)
);

CREATE TABLE Subjects (
    subject_id INT PRIMARY KEY,
    subject_name NVARCHAR(50)
);

CREATE TABLE Tests (
    test_id INT PRIMARY KEY,
    test_name NVARCHAR(50),
    weight FLOAT,
    subject_id INT,
    FOREIGN KEY (subject_id) REFERENCES Subjects(subject_id)
);

CREATE TABLE Enrollment (
    student_id INT,
    class_id INT,
    PRIMARY KEY (student_id, class_id),
    FOREIGN KEY (student_id) REFERENCES Students(student_id),
    FOREIGN KEY (class_id) REFERENCES Classes(class_id)
);

CREATE TABLE StudentSubjects (
    student_id INT,
    subject_id INT,
    PRIMARY KEY (student_id, subject_id),
    FOREIGN KEY (student_id) REFERENCES Students(student_id),
    FOREIGN KEY (subject_id) REFERENCES Subjects(subject_id)
);

CREATE TABLE ClassSubjects (
    class_id INT,
    subject_id INT,
    PRIMARY KEY (class_id, subject_id),
    FOREIGN KEY (class_id) REFERENCES Classes(class_id),
    FOREIGN KEY (subject_id) REFERENCES Subjects(subject_id)
);

CREATE TABLE TeacherAssignments (
    teacher_id INT,
    class_id INT,
    subject_id INT,
    PRIMARY KEY (teacher_id, class_id, subject_id),
    FOREIGN KEY (teacher_id) REFERENCES Teachers(teacher_id),
    FOREIGN KEY (class_id) REFERENCES Classes(class_id),
    FOREIGN KEY (subject_id) REFERENCES Subjects(subject_id)
);

CREATE TABLE Grades (
    grade_id int PRIMARY KEY,
    student_id INT,
    test_id INT,
    teacher_id INT,
    grade FLOAT DEFAULT(0),
    FOREIGN KEY (student_id) REFERENCES Students(student_id),
    FOREIGN KEY (test_id) REFERENCES Tests(test_id),
    FOREIGN KEY (teacher_id) REFERENCES Teachers(teacher_id)
);

INSERT INTO Students (student_id, student_name, password)
VALUES 
(1, 'Tuan Anh', '123'),
(2, 'Jane Smith', '123'),
(3, 'Michael Johnson', '123'),
(4, 'Emily Davis', '123'),
(5, 'David Brown', '123'),
(6, 'Sarah Wilson', '123'),
(7, 'James Taylor', '123'),
(8, 'Laura Anderson', '123'),
(9, 'Robert Thomas', '123'),
(10, 'Linda Jackson', '123'),
(11, 'William White', '123'),
(12, 'Jessica Harris', '123'),
(13, 'Charles Martin', '123'),
(14, 'Karen Thompson', '123'),
(15, 'Daniel Garcia', '123'),
(16, 'Patricia Martinez', '123'),
(17, 'Christopher Robinson', '123'),
(18, 'Nancy Clark', '123'),
(19, 'Matthew Rodriguez', '123'),
(20, 'Barbara Lewis', '123'),
(21, 'Anthony Lee', '123'),
(22, 'Elizabeth Walker', '123'),
(23, 'Mark Hall', '123'),
(24, 'Jennifer Allen', '123'),
(25, 'Thomas Young', '123'),
(26, 'Susan Hernandez', '123'),
(27, 'Donald King', '123'),
(28, 'Karen Wright', '123'),
(29, 'George Lopez', '123'),
(30, 'Betty Scott', '123'),
(31, 'Kenneth Green', '123'),
(32, 'Lisa Adams', '123'),
(33, 'Steven Baker', '123'),
(34, 'Dorothy Gonzalez', '123'),
(35, 'Edward Nelson', '123'),
(36, 'Sandra Carter', '123'),
(37, 'Paul Mitchell', '123'),
(38, 'Ashley Perez', '123'),
(39, 'Brian Roberts', '123'),
(40, 'Angela Turner', '123'),
(41, 'Kevin Phillips', '123'),
(42, 'Sharon Campbell', '123'),
(43, 'Jason Parker', '123'),
(44, 'Deborah Evans', '123'),
(45, 'Jeffrey Edwards', '123'),
(46, 'Maria Collins', '123'),
(47, 'Ryan Stewart', '123'),
(48, 'Cynthia Sanchez', '123'),
(49, 'Joshua Morris', '123'),
(50, 'Kathleen Rogers', '123');

INSERT INTO Teachers (teacher_id, teacher_name, password)
VALUES 
(1, 'Alice Johnson', '1234'),
(2, 'Bob Smith', '1234'),
(3, 'Carol Davis', '1234'),
(4, 'David Brown', '1234'),
(5, 'Eve Wilson', '1234');

INSERT INTO Subjects (subject_id, subject_name) VALUES 
(1, 'PRN212'),
(2, 'SWR302'),
(3, 'SWT301'),
(4, 'SWP391');

INSERT INTO Classes (class_id, class_name) VALUES (1, 'SE1801');
INSERT INTO Classes (class_id, class_name) VALUES (2, 'SE1802');
INSERT INTO Classes (class_id, class_name) VALUES (3, 'SE1803');
INSERT INTO Classes (class_id, class_name) VALUES (4, 'SE1804');
INSERT INTO Classes (class_id, class_name) VALUES (5, 'SE1805');

INSERT INTO Tests (test_id, test_name, [weight], subject_id) VALUES 
(1, 'Progress Test 1', 0.05, 1),
(2, 'Progress Test 2', 0.05, 1),
(3, 'Assignment 1', 0.2, 1),
(4, 'Assignment 2', 0.2, 1),
(5, 'Practical Exam', 0.3, 1),
(6, 'Final Exam', 0.2, 1),

(7, 'Progress Test 1', 0.1, 2),
(8, 'Progress Test 2', 0.1, 2),
(9, 'Progress Test 3', 0.1, 2),
(10, 'Assignment 1', 0.2, 2),
(11, 'Practical Exam', 0.3, 2),
(12, 'Final Exam', 0.2, 2),

(13, 'Progress Test 1', 0.1, 3),
(14, 'Progress Test 2', 0.1, 3),
(15, 'Progress Test 3', 0.1, 3),
(16, 'Lab 1', 0.05, 3),
(17, 'Lab 2', 0.05, 3),
(18, 'Lab 3', 0.05, 3),
(19, 'Lab 4', 0.05, 3),
(20, 'Practical Exam', 0.3, 3),
(21, 'Final Exam', 0.2, 3),

(22, 'Final Project', 1, 4);


INSERT INTO ClassSubjects (class_id, subject_id) VALUES
(1, 2), (1, 3), (1, 4), (1, 1),
(2, 1), (2, 2), (2, 3), (2, 4), 
(3, 1), (3, 2), (3, 3), (3, 4), 
(4, 1), (4, 2), (4, 3), (4, 4), 
(5, 1), (5, 2), (5, 3), (5, 4);

INSERT INTO Enrollment (student_id, class_id) VALUES
(1,1), (2,1), (3,1),(4,1),(5,1),(6,1),(7,1),(8,1),(9,1),(10,1),
(11,2), (12,2), (13,2),(14,2),(15,2),(16,2),(17,2),(18,2),(19,2),(20,2),
(21,3), (22,3), (23,3),(24,3),(25,3),(26,3),(27,3),(28,3),(29,3),(30,3),
(31,4), (32,4), (33,4),(34,4),(35,4),(36,4),(37,4),(38,4),(39,4),(40,4),
(41,5), (42,5), (43,5),(44,5),(45,5),(46,5),(47,5),(48,5),(49,5),(50,5);

-- Insert all 50 students into each of the 5 subjects
DECLARE @student_id INT
DECLARE @subject_id INT

SET @student_id = 1

WHILE @student_id <= 50
BEGIN
    SET @subject_id = 1
    WHILE @subject_id <= 4
    BEGIN
        INSERT INTO StudentSubjects (student_id, subject_id) VALUES (@student_id, @subject_id)
        SET @subject_id = @subject_id + 1
    END
    SET @student_id = @student_id + 1
END

-- Teacher 1 teaches Subject 1 (PRN) in all 5 classes
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (1, 1, 1);
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (1, 4, 1);
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (1, 5, 1);

-- Teacher 2 teaches Subject 2 (SWR) in all 5 classes
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (2, 1, 2);
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (2, 2, 2);
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (2, 3, 2);
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (2, 4, 2);
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (2, 5, 2);

-- Teacher 3 teaches Subject 3 (SWT) in all 5 classes
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (3, 1, 3);
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (3, 2, 3);
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (3, 3, 3);
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (3, 4, 3);
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (3, 5, 3);

-- Teacher 4 teaches Subject 4 (SWP) in all 5 classes
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (4, 1, 4);
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (4, 2, 4);
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (4, 3, 4);
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (4, 4, 4);
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (4, 5, 4);

-- Teacher 5 teaches Subject 5 (Art) in all 5 classes
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (5, 2, 1);
INSERT INTO TeacherAssignments (teacher_id, class_id, subject_id) VALUES (5, 3, 1);

INSERT INTO Grades (grade_id, student_id, test_id, teacher_id, grade)
VALUES (1,1, 22, 1, 10), --SWP
	   (2, 1, 1, 1, 9), (3, 1, 2, 1, 8), (4,1, 3, 1, 7), (5,1, 4, 1, 8.7), (6,1, 5, 1, 9.7), (7,1, 6, 1, 9.7), -- PRN
	   (8, 1, 7, 1, 5.6), (9, 1, 8, 1, 6.1), (10,1, 9, 1, 7), (11,1, 10, 1, 8.8), (12,1,11, 1, 3.4),  (13,1, 12, 1, 9.9), --SWR
	   (14, 1, 13, 1, 1), (15, 1, 14, 1, 2), ( 16,1, 15, 1, 3.4), (17, 1, 16, 1, 4.5), (18, 1, 17, 1, 9), 
	   (19, 1, 18, 1, 7.6), (20, 1, 19, 1, 8.9), (21, 1, 20, 1, 9.4), (22,1, 21, 1, 3.6); -- SWT
/*
DECLARE @StartStudentId INT = 2;
DECLARE @EndStudentId INT = 50;

WHILE @StartStudentId <= @EndStudentId
BEGIN
    INSERT INTO Grades (student_id, test_id, teacher_id, grade)
    VALUES 
        (@StartStudentId, 22, 1, 0), --SWP
        (@StartStudentId, 1, 1, 0), (@StartStudentId, 2, 1, 0), (@StartStudentId, 3, 1, 0), (@StartStudentId, 4, 1, 0), (@StartStudentId, 5, 1, 0), (@StartStudentId, 6, 1, 0), -- PRN
        (@StartStudentId, 7, 1, 0), (@StartStudentId, 8, 1, 0), (@StartStudentId, 9, 1, 0), (@StartStudentId, 10, 1, 0), (@StartStudentId, 11, 1, 0), (@StartStudentId, 12, 1, 0), --SWR
        (@StartStudentId, 13, 1, 0), (@StartStudentId, 14, 1, 0), (@StartStudentId, 15, 1, 0), (@StartStudentId, 16, 1, 0), (@StartStudentId, 17, 1, 0), 
        (@StartStudentId, 18, 1, 0), (@StartStudentId, 19, 1, 0), (@StartStudentId, 20, 1, 0), (@StartStudentId, 21, 1, 0); -- SWT

    SET @StartStudentId = @StartStudentId + 1;
END
*/