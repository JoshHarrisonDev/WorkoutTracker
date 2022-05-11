using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Data.Models;

namespace WorkoutTracker.Models
{
    public class ExerciseSet
    {
        public int ExerciseID { get; set; }

        [DisplayName("Exercise Name")]
        public string ExerciseName { get; set; }

        public int WorkoutID { get; set; }


        public int Reps { get; set; }

        public int Weight { get; set; }

    }
}
