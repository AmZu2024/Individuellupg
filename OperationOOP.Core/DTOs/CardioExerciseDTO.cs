using OperationOOP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.DTOs
{
    public class CardioExerciseDTO : ExerciseDTO
    {
        public int Duration { get; set; }
        public int CaloriesBurned { get; set; }

        public static CardioExerciseDTO FromExercise(CardioExercise cardioExercise)
        {
            return new CardioExerciseDTO
            {
                Id = cardioExercise.Id,
                Name = cardioExercise.ExcersiseName,
                Description = cardioExercise.ExcersiseDescription,
                Duration = cardioExercise.Duration,
                CaloriesBurned = cardioExercise.CaloriesBurned
            };
        }
    }
}
