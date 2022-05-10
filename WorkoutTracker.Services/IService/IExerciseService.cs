using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Data.Models;

namespace WorkoutTracker.Services.IService
{
    public interface IExerciseService
    {
        void AddExercise(Exercise exercise);

        void RemoveExercise(int ID);

        void UpdateExercise(Exercise exercise);

        Exercise GetExercise(int ID);

        IList<Exercise> GetExercises();

        void AddExerciseToWorkout(int ID, Exercise exercise);
    }
}
