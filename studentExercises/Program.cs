using System;
using System.Collections.Generic;
using System.Linq;
using studentExercises.Data;
using studentExercises.Models;



namespace studentExercises
{


    class Program
    {
        static void Main()
        {
            //Creating new instance of repository class
            Repository repository = new Repository();

            //Query the database for all the Exercises.

            List<Exercise> listOfExercises = repository.GetAllExercises();
            PrintExerciseReport("All Exercises", listOfExercises);


            //Find all the exercises in the database where the language is JavaScript.

            List<Exercise> specificExercises = repository.GetExerciseByLanguage("Javascript");
            PrintSpecificExercises("Your Searched Exercises", specificExercises);


            //Insert a new exercise into the database.

            //Exercise StudentExercises = new Exercise("Student Exercises", "C#");
            //repository.AddExercise(StudentExercises);


            //Find all instructors in the database. Include each instructor's cohort.

            List<Instructor> instructors = repository.GetAllInstructorsWithCohort();
            PrintInstructorReport("Your Instructors", instructors);

            //Insert a new instructor into the database.Assign the instructor to an existing cohort.
            List<Cohort> cohorts = repository.GetAllCohorts();
            Cohort firstCohort = cohorts[0];


            Instructor Madi = new Instructor
            {
                FirstName = "Madi",
                LastName = "Piper",
                SlackHandle = "MPiper",
                CohortId = firstCohort.Id
            };

            //repository.AddInstructor(Madi);
            instructors = repository.GetAllInstructorsWithCohort();
            PrintInstructorReport("Your Instructors", instructors);


            //Assign an existing exercise to an existing student.
            List<Student> listOfStudents = repository.GetAllStudents();
            Student firstStudent = listOfStudents[0];
            Exercise firstExercise = listOfExercises[3];

            repository.AddExerciseToStudent(firstStudent, firstExercise);

        }

        public static void PrintExerciseReport(string title, List<Exercise> listOfExercises)
        {
            foreach (Exercise e in listOfExercises)
            {
                Console.WriteLine($"{e.Id}: {e.ExerciseName}, {e.Language}");
            }
        }


        public static void PrintSpecificExercises(string title, List<Exercise> specificExercises)
        {
            foreach (Exercise e in specificExercises)
            {
                Console.WriteLine($"{e.Id}: {e.ExerciseName}, {e.Language}");
            }
        }


        public static void PrintInstructorReport(string title, List<Instructor> instructors)
        {
            foreach (Instructor i in instructors)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName} teaches for {i.Cohort.CohortName}");
            }
        }










    }
}
