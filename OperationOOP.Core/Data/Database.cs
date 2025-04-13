using OperationOOP.Core.Models;
using System.ComponentModel;

namespace OperationOOP.Core.Data
{

    // Interface for the database, som bara används i databasen
    public interface IDatabase
    {
        IList<Workout> Workouts { get; set; }
        IList<Exercise> Exercises { get; set; }


    }

    public class Database : IDatabase
    {
        public IList<Workout> Workouts { get; set; }
        public IList<Exercise> Exercises { get; set; }
        public Database()
        {

            Workouts = new List<Workout>();
            Exercises = new List<Exercise>();



            // Lite förgjorda övningar och workouts 

            var running = new CardioExercise("Running", "30 minutes running", 30, 300)
            {
                Id = 1
            };

            var cycling = new CardioExercise("Cycling", "15 minutes cycling", 15, 150)
            {
                Id = 2
            };

            var benchPress = new StrengthExercise("Bench Press", "Chest exercise", "Chest", 10, 3, 80)
            {
                Id = 3
            };

            var squats = new StrengthExercise("Squats", "Leg exercise", "Legs", 12, 4, 100)
            {
                Id = 4
            };

            Exercises.Add(running);
            Exercises.Add(cycling);
            Exercises.Add(benchPress);
            Exercises.Add(squats);

   

            var cardioWorkout = new Workout("Morning Cardio", 45, WorkoutLevel.Beginner, WorkoutType.Cardio)
            {
                Id = 1,
                Exercises = new List<Exercise> { running, cycling }
            };

            var strengthWorkout = new Workout("Full Body Strength", 60, WorkoutLevel.Intermediate, WorkoutType.Strength)
            {
                Id = 2,
                Exercises = new List<Exercise> { benchPress, squats }
            };

            Workouts.Add(cardioWorkout);
            Workouts.Add(strengthWorkout);



        }

    }
}


