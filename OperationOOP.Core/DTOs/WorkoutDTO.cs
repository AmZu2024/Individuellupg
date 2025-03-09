using OperationOOP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.DTOs
{
    public class WorkoutDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Level { get; set; }

        public List<CardioExerciseDTO>? CardioExercises { get; set; }
        public List<StrengthExerciseDTO>? StrengthExercises { get; set; }

        public static WorkoutDTO FromWorkout(Workout workout)
        {
        
            return new WorkoutDTO
            {
                
                Id = workout.Id,
                Name = workout.Name,
                Duration = workout.Duration,
                Level = workout.Level.ToString(),
                CardioExercises = workout.Exercises
                    .OfType<CardioExercise>()
                    .Select(CardioExerciseDTO.FromExercise)
                    .ToList(),

                StrengthExercises = workout.Exercises
                    .OfType<StrengthExercise>()
                    .Select(StrengthExerciseDTO.FromExercise)
                    .ToList()
            };

        }
    }
}
