using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    //StrengthExercise ärver från Exercise 
    public class StrengthExercise : Exercise
    {
     
        public StrengthExercise(string name, string description, string muscleGroup, int repetitions, int sets, int weight)
        {
            ExcersiseName = name;
            ExcersiseDescription = description;
            MuscleGroup = muscleGroup;
            Repetitions = repetitions;
            Sets = sets;
            Weight = weight;
        }
        public string MuscleGroup { get; set; } 
        public int Repetitions { get; set; }
        public int Sets { get; set; }
        public int Weight { get; set; }

    }
}
