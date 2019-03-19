using System;
using System.Collections.Generic;
using System.Linq;
using studentExercises.Data;
using studentExercises.Models;



namespace studentExercises
{


    class Program
    {
        static void Main(string[] args)
        {
            
//Query the database for all the Exercises.
        
        Repository repository = new Repository();

        List<Exercise> listOfExercises = repository.GetAllExercises();


        PrintExerciseReport("All Exercises", listOfExercises);


//Find all the exercises in the database where the language is JavaScript.


//Insert a new exercise into the database.


            //Exercise StudentExercises = new Exercise("Student Exercises", "C#");


            //repository.AddExercise(StudentExercises);
























        }

        public static void PrintExerciseReport(string title, List<Exercise> listOfExercises)
        {
            foreach (Exercise e in listOfExercises)
            {
                Console.WriteLine($"{e.Id}: {e.ExerciseName}, {e.Language}");
            }
        }















    }
}
