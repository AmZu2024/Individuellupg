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


            int workoutId = Workouts.Any() ? Workouts.Max(w => w.Id) + 1 : 1;


            int exerciseId = Exercises.Any() ? Exercises.Max(e => e.Id) + 1 : 1;


            // Mappa rätt övningar till rätt workouts
            var cardioExercise1 = new CardioExercise("Jogging", "Regular Jogg", 30, 500)
            {Id = exerciseId++ };
            Exercises.Add(cardioExercise1);

            Workouts.Add(new CardioWorkout(

                "Morning Run",
                30,
                WorkoutLevel.Master,
                 CardioType.IntervalTraining,
                new List<CardioExercise> {cardioExercise1})
            { Id = workoutId++});

            var strengthExercise1 = new StrengthExercise("Bench Press", "blablabla", "Chest", 5, 5, 80)
            { Id=exerciseId};
           Exercises.Add(strengthExercise1);

            Workouts.Add(new StrengthWorkout(
                "Upper Body",
                45,
                WorkoutLevel.Beginner,

                new List<StrengthExercise> {strengthExercise1})
            { Id = workoutId++ });
           
        }

    }
}


