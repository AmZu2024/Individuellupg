using OperationOOP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OperationOOP.Core.DTOs
{
   public class StrengthExerciseDTO : ExerciseDTO
    {

        [JsonPropertyOrder(1)]
        public string MuscleGroup { get; set; }

        [JsonPropertyOrder(2)]
        public int Repetitions { get; set; }

        [JsonPropertyOrder(3)]
        public int Sets { get; set; }

        [JsonPropertyOrder(4)]
        public int Weight { get; set; }

        public static StrengthExerciseDTO FromExercise(StrengthExercise strengthExercise)
        {
            return new StrengthExerciseDTO
            {
                Id = strengthExercise.Id,
                Name = strengthExercise.ExcersiseName,
                Description = strengthExercise.ExcersiseDescription,
                MuscleGroup = strengthExercise.MuscleGroup,
                Repetitions = strengthExercise.Repetitions,
                Sets = strengthExercise.Sets,
                Weight = strengthExercise.Weight
            };

        }
    }
}
