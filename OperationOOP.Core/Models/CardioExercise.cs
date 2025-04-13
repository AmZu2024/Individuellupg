using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class CardioExercise:Exercise
    {
        public int Duration { get; set; }
        public int CaloriesBurned { get; set; }

      
        public CardioExercise(string name, string description , int duration, int caloriesBurned) 
        {
            
            ExcersiseName = name;
            ExcersiseDescription = description;
            Duration = duration;
            CaloriesBurned = caloriesBurned;
            
        }
    }
}
