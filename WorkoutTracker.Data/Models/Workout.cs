using System.Collections.Generic;

namespace WorkoutTracker.Data.Models
{
    public class Workout
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }

        public virtual IList<Exercise> Exercises { get; set; }
    }
}