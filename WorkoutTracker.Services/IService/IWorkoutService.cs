using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Data.Models;

namespace WorkoutTracker.Services.IService
{
    public interface IWorkoutService
    {
        IList<Workout> GetWorkouts();

        Workout GetWorkout(int ID);

        void AddWorkout(Workout workout);

        void UpdateWorkout(Workout workout);

        void DeleteWorkout(int ID);

        IList<Workout> GetWorkoutsUser(int ID);

        Workout GetWorkoutUser(int userID, int workoutID);

        void AddWorkoutUser(User user, Workout workout);

    }
}
