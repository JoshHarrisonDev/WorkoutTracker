using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Data.Models;

namespace WorkoutTracker.Models
{
    public class ExerciseWorkout
    {
        public int ID { get; set; }

        public string ExerciseName { get; set; }

        public int Workout { get; set; }

    }
}
