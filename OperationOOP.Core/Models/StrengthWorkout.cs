using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    //Ärver från basklassen Workout 
    public class StrengthWorkout : Workout
    {
     
        //Lägger till en property 
        public List<StrengthExercise> StrengthExercises { get; set; }
        
        //Skapar en konstruktor 
        public StrengthWorkout(string name, int duration, WorkoutLevel level, List<StrengthExercise>? exercises = null)
        {
            Name = name;
            Duration = duration;
            Level = level;
            StrengthExercises = exercises ?? new List<StrengthExercise>();
            Exercises.AddRange(StrengthExercises);

        }

    }
}
