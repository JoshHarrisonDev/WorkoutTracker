using System.Collections.Generic;
using System.Linq;
using WorkoutTracker.Data.Models;
using WorkoutTracker.Services.IService;
using WorkoutTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace WorkoutTracker.Services.Service
{
    public class WorkoutService : IWorkoutService
    {
        private WorkoutContext _context;


        public WorkoutService(WorkoutContext context)
        {
            _context = context;

        }

        public void AddWorkout(Workout workout)
        {
            _context.Add(workout);
            _context.SaveChanges();
        }

        public void DeleteWorkout(int ID)
        {
            Workout workout = GetWorkout(ID);
            _context.Remove(workout);
            _context.SaveChanges();
        }

        public Workout GetWorkout(int ID)
        {
            IList<Workout> workouts = GetWorkouts();

            return workouts.FirstOrDefault(w => w.ID == ID);
        }

        public IList<Workout> GetWorkouts()
        {


            return _context.Workout.Include(w => w.Exercises).ThenInclude(e => e.Sets).ToList();
        }

        public void UpdateWorkout(Workout workout)
        {
            Workout workoutToUpdate = GetWorkout(workout.ID);
            _context.Workout.Update(workoutToUpdate).CurrentValues.SetValues(workout);
            _context.SaveChanges();
        }
    }
}
