using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    //Skapar en basklass workout som inte är instansierbar (abstract)
    public abstract class Workout
    {
        //Skapar properties 

        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public WorkoutLevel Level { get; set; }
        //Komposition: lägger till  property där datatypen är av en klass 
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();


    }

    public enum WorkoutLevel
    {
        Beginner,
        Intermediate,
        Advanced,
        Master
    }

    
}
