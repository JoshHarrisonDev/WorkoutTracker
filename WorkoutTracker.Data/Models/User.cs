using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Data.Models
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual IList<Workout> Workouts { get; set; }
    }
}
