# Table Design

### AcademicYear

```MSSQL
CREATE TABLE AcademicYears (
    AcademicYearID INT PRIMARY KEY IDENTITY(1,1),
    Year NVARCHAR(9) NOT NULL UNIQUE -- Example: '2024-2025'
);

```

### Grades

```MSSQL
CREATE TABLE Grades (
    GradeID INT PRIMARY KEY IDENTITY(1,1),
    GradeName NVARCHAR(10) NOT NULL UNIQUE,
    PaymentAmount DECIMAL(10, 2) NOT NULL
);

```

###  Students

```MSSQL
CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    GradeID INT NOT NULL FOREIGN KEY REFERENCES Grades(GradeID),
    CurrentYearID INT NOT NULL FOREIGN KEY REFERENCES AcademicYears(AcademicYearID),
    EnrollmentDate DATE NOT NULL DEFAULT GETDATE()
);

```

###  Payments

```MSSQL
CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
    AcademicYearID INT NOT NULL FOREIGN KEY REFERENCES AcademicYears(AcademicYearID),
    PaymentDate DATE NOT NULL DEFAULT GETDATE(),
    AmountPaid DECIMAL(10, 2) NOT NULL,
    PaymentStatus NVARCHAR(20) NOT NULL CHECK (PaymentStatus IN ('Paid', 'Pending'))
);

```

###  Promotions

```MSSQL
CREATE TABLE Promotions (
    PromotionID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
    FromGradeID INT NOT NULL FOREIGN KEY REFERENCES Grades(GradeID),
    ToGradeID INT NOT NULL FOREIGN KEY REFERENCES Grades(GradeID),
    AcademicYearID INT NOT NULL FOREIGN KEY REFERENCES AcademicYears(AcademicYearID),
    PromotionDate DATE NOT NULL DEFAULT GETDATE()
);

```

## Insert Querys

### AcademicYears

```MSSQL
INSERT INTO AcademicYears (Year)
VALUES ('2023-2024'), ('2024-2025'), ('2025-2026');
```

###  Grades

```MSSQL
INSERT INTO Grades (GradeName, PaymentAmount)
VALUES 
('Grade 1', 5000.00),
('Grade 2', 6000.00),
('Grade 3', 7000.00),
('Grade 4', 8000.00),
('Grade 5', 9000.00),
('Grade 6', 10000.00),
('Grade 7', 11000.00),
('Grade 8', 12000.00),
('Grade 9', 13000.00),
('Grade 10', 14000.00);

```

### Students

```MSSQL
INSERT INTO Students (FirstName, LastName, DateOfBirth, GradeID, CurrentYearID)
VALUES 
('John', 'Doe', '2010-05-20', 1, 1),
('Jane', 'Smith', '2009-04-15', 2, 1),
('Emily', 'Johnson', '2008-03-10', 3, 1);

```

###  Payments

```MSSQL
INSERT INTO Payments (StudentID, AcademicYearID, PaymentDate, AmountPaid, PaymentStatus)
VALUES 
(1, 1, '2023-09-01', 5000.00, 'Paid'),
(2, 1, '2023-09-01', 3000.00, 'Pending');

```

&nbsp;

# Examples Queries

### View Pending Payments for the Current Year

```MSSQL
SELECT S.StudentID, S.FirstName, S.LastName, G.GradeName, AY.Year AS AcademicYear,
       G.PaymentAmount, ISNULL(SUM(P.AmountPaid), 0) AS TotalPaid,
       (G.PaymentAmount - ISNULL(SUM(P.AmountPaid), 0)) AS OutstandingAmount
FROM Students S
INNER JOIN Grades G ON S.GradeID = G.GradeID
INNER JOIN AcademicYears AY ON S.CurrentYearID = AY.AcademicYearID
LEFT JOIN Payments P ON S.StudentID = P.StudentID AND P.AcademicYearID = S.CurrentYearID
WHERE AY.Year = '2023-2024'
GROUP BY S.StudentID, S.FirstName, S.LastName, G.GradeName, AY.Year, G.PaymentAmount;

```

###  Promote Students to the Next Grade

```MSSQL
DECLARE @NextGradeID INT, @NewAcademicYearID INT;
SET @NewAcademicYearID = (SELECT AcademicYearID FROM AcademicYears WHERE Year = '2024-2025');

-- Promote John Doe (StudentID = 1)
SET @NextGradeID = (SELECT GradeID FROM Grades WHERE GradeName = 'Grade 2');

-- Update student's grade and academic year
UPDATE Students
SET GradeID = @NextGradeID, CurrentYearID = @NewAcademicYearID
WHERE StudentID = 1;

-- Insert into Promotions table
INSERT INTO Promotions (StudentID, FromGradeID, ToGradeID, AcademicYearID)
VALUES (1, 1, @NextGradeID, @NewAcademicYearID);

```

###  Add Payment for the New Year

```MSSQL
INSERT INTO Payments (StudentID, AcademicYearID, PaymentDate, AmountPaid, PaymentStatus)
VALUES (1, (SELECT AcademicYearID FROM AcademicYears WHERE Year = '2024-2025'), GETDATE(), 6000.00, 'Paid');

```

###  Generate Payment History for a Student

```MSSQL
SELECT AY.Year AS AcademicYear, P.PaymentDate, P.AmountPaid, P.PaymentStatus
FROM Payments P
INNER JOIN AcademicYears AY ON P.AcademicYearID = AY.AcademicYearID
WHERE P.StudentID = 1;

```

### List Promotions

```MSSQL
SELECT S.FirstName, S.LastName, G1.GradeName AS FromGrade, 
       G2.GradeName AS ToGrade, AY.Year AS AcademicYear, P.PromotionDate
FROM Promotions P
INNER JOIN Students S ON P.StudentID = S.StudentID
INNER JOIN Grades G1 ON P.FromGradeID = G1.GradeID
INNER JOIN Grades G2 ON P.ToGradeID = G2.GradeID
INNER JOIN AcademicYears AY ON P.AcademicYearID = AY.AcademicYearID;

```

### Total Collections and Outstanding Payments

```MSSQl
-- Total Collections
SELECT SUM(P.AmountPaid) AS TotalCollection
FROM Payments P
WHERE P.PaymentStatus = 'Paid';

-- Outstanding Payments
SELECT S.FirstName, S.LastName, G.GradeName, 
       (G.PaymentAmount - ISNULL(SUM(P.AmountPaid), 0)) AS OutstandingAmount
FROM Students S
INNER JOIN Grades G ON S.GradeID = G.GradeID
LEFT JOIN Payments P ON S.StudentID = P.StudentID AND P.AcademicYearID = S.CurrentYearID
WHERE (G.PaymentAmount - ISNULL(SUM(P.AmountPaid), 0)) > 0
GROUP BY S.FirstName, S.LastName, G.GradeName, G.PaymentAmount;

```

#  Example Outputs

### Pending Payments

| StudentId | FirstName | LastName | GradeName | AcademicYear | PaymentAmount | TotalPaid | OutstandingAmount |
| --- | --- | --- | --- | --- | --- | --- | --- |
| 2   | Jane | Smith | Grade 2 | 2023-2024 | 6000.00 | 3000.00 | 3000.00 |

###  Promotions

| FirstName | LastName | FromGrade | ToGrade | AcademicYear | PromotionDate |
| --- | --- | --- | --- | --- | --- |
| John | Doe | Grade 1 | Grade 2 | 2024-2025 | 2024-11-28 |

&nbsp;

* * *

Notes => This system can handle grade promotions, yearly payments, and detailed tracking for students 

&nbsp;