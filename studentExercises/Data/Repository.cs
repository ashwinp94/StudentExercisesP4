using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using studentExercises.Models;


namespace studentExercises.Data
{
    public class Repository
    {


        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                string _connectionString = "Server=Ashwin-pc\\SQLEXPRESS;Database=StudentExercises;Trusted_Connection=True";
                return new SqlConnection(_connectionString);
            }
        }


        public List<Exercise> GetAllExercises()
        {
            
            using (SqlConnection conn = Connection)
            {
                // Note, we must Open() the connection, the "using" block doesn't do that for us.
                conn.Open();

                // We must "use" commands too.
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Here we setup the command with the SQL we want to execute before we execute it.
                    cmd.CommandText = "SELECT Id, ExerciseName, Language FROM Exercise";

                    // Execute the SQL in the database and get a "reader" that will give us access to the data.
                    SqlDataReader reader = cmd.ExecuteReader();

                    // A list to hold the exercises we retrieve from the database.
                    List<Exercise> listOfExercises = new List<Exercise>();

                    // Read() will return true if there's more data to read
                    while (reader.Read())
                    {
                        // The "ordinal" is the numeric position of the column in the query results.
                        //  For our query, "Id" has an ordinal value of 0 and "DeptName" is 1.
                        int idColumnPosition = reader.GetOrdinal("Id");

                        // We user the reader's GetXXX methods to get the value for a particular ordinal.
                        int idValue = reader.GetInt32(idColumnPosition);

                        int exerciseNameColumnPosition = reader.GetOrdinal("ExerciseName");
                        string exerciseNameValue = reader.GetString(exerciseNameColumnPosition);

                        int languageColumnPosition = reader.GetOrdinal("Language");
                        string exerciseLanguageValue = reader.GetString(languageColumnPosition);

                        // Now let's create a new exercise object using the data from the database.
                        Exercise exercise = new Exercise(exerciseName: exerciseNameValue, exerciseLanguage: exerciseLanguageValue)
                        {Id= idValue };
                       
                            
                       
                        // ...and add that exercise object to our list.
                        listOfExercises.Add(exercise);
                    }

                    // We should Close() the reader. Unfortunately, a "using" block won't work here.
                    reader.Close();

                    // Return the list of exercises who whomever called this method.
                    return listOfExercises;
                }
            }
        }


        //public Exercise GetExerciseByLanguage(string language)
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            // String interpolation lets us inject the id passed into this method.
        //            cmd.CommandText = $"SELECT ExerciseName FROM Exercise WHERE Language = {language}";
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            Exercise exercise = null;
        //            if (reader.Read())
        //            {
        //                exercise = new Exercise
        //                {
        //                    Id = id,
        //                    exerciseName = reader.GetString(reader.GetOrdinal("DeptName"))
        //                };
        //            }

        //            reader.Close();

        //            return exercise;
        //        }
        //    }
        //}
        public void AddExercise(Exercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // More string interpolation
                    cmd.CommandText = $"INSERT INTO Exercise (ExerciseName, Language) Values ('{exercise.ExerciseName}', '{exercise.Language}')";
                    cmd.ExecuteNonQuery();
                }
            }

            // when this method is finished we can look in the database and see the new exercise.
        }

    }
}
