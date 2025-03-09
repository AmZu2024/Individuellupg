using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class CardioWorkout:Workout
    {
        
       public CardioType Type { get; set; }
        public List<CardioExercise> CardioExercises { get; set; }


        //constructor with everything from workout and cardio workout
       
        public CardioWorkout(string name, int duration, WorkoutLevel level, CardioType type, List<CardioExercise>? exercises = null) 
        {
            
            Name = name;
            Duration = duration;
            Level = level;
            CardioExercises = exercises ?? new List<CardioExercise>();
            Exercises.AddRange(CardioExercises);
            Type = type;

        }


    }
  


    public enum CardioType
    {
        SteadyState,
        IntervalTraining,
        HighIntensityIntervalTraining,
        LowIntensitySteadyState,
        NeatCardio

    };
}
