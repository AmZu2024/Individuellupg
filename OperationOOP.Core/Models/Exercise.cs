using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    //Basklass för alla övningar
    public abstract class Exercise
    {
        public int Id { get; set; }
        public string ExcersiseName { get; set; }
        public string ExcersiseDescription { get; set; }

    }
    
}
