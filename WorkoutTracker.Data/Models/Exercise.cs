using System.Collections.Generic;

namespace WorkoutTracker.Data.Models
{
    public class Exercise
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual IList<Set> Sets { get; set; }


    }
}