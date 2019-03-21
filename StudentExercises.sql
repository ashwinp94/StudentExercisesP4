--Create new tables

CREATE TABLE Cohort (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    CohortName VARCHAR(55) NOT NULL,
);

CREATE TABLE Exercise (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    ExerciseName VARCHAR(55) NOT NULL,
    [Language] VARCHAR(55) NOT NULL,
);

CREATE TABLE Student (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    FirstName VARCHAR(55) NOT NULL,
	LastName VARCHAR(55) NOT NULL,
	SlackHandle VARCHAR(55) NOT NULL,
	CohortId INTEGER NOT NULL,
	CONSTRAINT FK_Student_Cohort FOREIGN KEY(CohortId) REFERENCES Cohort(Id),
);

CREATE TABLE Instructor (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    FirstName VARCHAR(55) NOT NULL,
	LastName VARCHAR(55) NOT NULL,
	SlackHandle VARCHAR(55) NOT NULL,
	CohortId INTEGER NOT NULL,
	CONSTRAINT FK_Instructor_Cohort FOREIGN KEY(CohortId) REFERENCES Cohort(Id),
);


CREATE TABLE AssignedExercises (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    StudentId INTEGER NOT NULL,
    ExerciseId INTEGER,
	CONSTRAINT FK_AssignedExercises_Exercise FOREIGN KEY(ExerciseId) REFERENCES Exercise(Id),
    CONSTRAINT FK_AssignedExercises_Student FOREIGN KEY(StudentId) REFERENCES Student(Id),
);

    


-- Add some data to the tables

INSERT INTO Cohort (CohortName) VALUES ('Cohort 29');
INSERT INTO Cohort (CohortName) VALUES ('Cohort 30');
INSERT INTO Cohort (CohortName) VALUES ('Cohort 31');

INSERT INTO Exercise(ExerciseName, [Language]) VALUES ('Lists', 'C#');
INSERT INTO Exercise(ExerciseName, [Language]) VALUES ('Dictionary', 'C#');
INSERT INTO Exercise(ExerciseName, [Language]) VALUES ('Ternary Traveler', 'Javascript');
INSERT INTO Exercise(ExerciseName, [Language]) VALUES ('Deleting Data', 'Javascript');
INSERT INTO Exercise(ExerciseName, [Language]) VALUES ('REACT: Conditional Routing', 'REACT');
INSERT INTO Exercise(ExerciseName, [Language]) VALUES ('REACT: URL Routing', 'REACT');

INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Ashwin', 'Prakash', 'ashwinp94', 1);
INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Mary', 'Remo', 'MaryRemo', 1);
INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Brian', 'Neal', 'BrianNeal', 2);
INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Ryan', 'Dillinger', 'RyanDillinger', 2);
INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Michael', 'Yankura', 'MichaelYankura', 3);
INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Chris', 'Morgan', 'ChrisMorgan', 3);

INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId) VALUES ('Jisie', 'Davids', 'JisieDavid', 3);
INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId) VALUES ('Andy', 'Collins', 'AndyCollins', 1);
INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId) VALUES ('Steve', 'Brownlee', 'steve', 2);
INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId) VALUES ('Leah', 'Gwin', 'LGwin', 1);


INSERT INTO AssignedExercises(StudentId, ExerciseId) VALUES (1, 1);
INSERT INTO AssignedExercises(StudentId, ExerciseId) VALUES (1, 2);
INSERT INTO AssignedExercises(StudentId, ExerciseId) VALUES (2, 1);
INSERT INTO AssignedExercises(StudentId, ExerciseId) VALUES (2, 2);
INSERT INTO AssignedExercises(StudentId, ExerciseId) VALUES (3, 3);
INSERT INTO AssignedExercises(StudentId, ExerciseId) VALUES (3, 4);
INSERT INTO AssignedExercises(StudentId, ExerciseId) VALUES (4, 3);
INSERT INTO AssignedExercises(StudentId, ExerciseId) VALUES (4, 4);
INSERT INTO AssignedExercises(StudentId, ExerciseId) VALUES (5, 5);
INSERT INTO AssignedExercises(StudentId, ExerciseId) VALUES (5, 6);
INSERT INTO AssignedExercises(StudentId, ExerciseId) VALUES (6, 5);










