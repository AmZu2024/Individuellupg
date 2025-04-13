using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    
    public  class Workout
    {
        //Skapar properties 

        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public WorkoutLevel Level { get; set; }

        public WorkoutType Type { get; set; }

        //Komposition: lägger till  property där datatypen är av en klass 
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();

        public Workout(string name, int duration, WorkoutLevel level,WorkoutType workoutType,List<Exercise>? exercises = null)
        {
            Name = name;
            Duration = duration;
            Level = level;
            Type = workoutType;
            Exercises = exercises ?? new List<Exercise>();
        }

    }

    public enum WorkoutLevel
    {
        Beginner,
        Intermediate,
        Advanced,
        Master
    }

    public enum WorkoutType
    {
        Strength,
        Cardio
    }


}
