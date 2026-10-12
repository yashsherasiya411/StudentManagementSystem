-- Optional: run in SSMS to create the database manually.
-- The application also creates it automatically on first run.
CREATE DATABASE StudentManagementDb;
GO
USE StudentManagementDb;
GO
CREATE TABLE Students (
    Id             INT IDENTITY(1,1) PRIMARY KEY,
    FullName       NVARCHAR(100) NOT NULL,
    Email          NVARCHAR(150) NOT NULL UNIQUE,
    Phone          NVARCHAR(10)  NOT NULL,
    Course         NVARCHAR(50)  NOT NULL,
    Semester       INT           NOT NULL,
    EnrollmentDate DATETIME2     NOT NULL
);
GO
INSERT INTO Students (FullName, Email, Phone, Course, Semester, EnrollmentDate) VALUES
('Aarav Patel', 'aarav@example.com', '9876543210', 'IMCA', 3, '2024-07-01'),
('Diya Shah',   'diya@example.com',  '9876501234', 'BCA',  5, '2023-07-01');
GO
