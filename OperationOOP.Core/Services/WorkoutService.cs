using OperationOOP.Core.Data;
using OperationOOP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationOOP.Core.DTOs;

namespace OperationOOP.Core.Services
{
    //Service klass som har hand om logik och enbart logik 
    public class WorkoutService
    {


        private readonly IDatabase _db;

        public WorkoutService(IDatabase db)
        {
            _db = db;
        }

        
        public List<WorkoutDTO> GetWorkoutsByLvl(int level)
        {
            var workouts = _db.Workouts.Where(w => (int)w.Level == level).ToList();
            return workouts.Select(WorkoutDTO.FromWorkout).ToList();
        }
    }
    
}

