using System;
using System.Collections.Generic;

namespace studentExercises.Models
{
    public class Exercise
    {
        public Exercise(string exerciseName, string exerciseLanguage)
        {
            ExerciseName = exerciseName;
            Language = exerciseLanguage;
        }

        public string ExerciseName { get; set; }

        public string Language { get; set; }

        public int Id { get; set; }



    }
}