using System.ComponentModel;

namespace WorkoutTracker.Models
{
    public class ExerciseWorkout
    {

        public int ID { get; set; }

        [DisplayName("Exercise Name")]
        public string ExerciseName { get; set; }

        public int Workout { get; set; }

        public string WorkoutName { get; set; }

    }
}
