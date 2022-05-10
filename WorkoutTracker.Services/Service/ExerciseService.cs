using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Data;
using WorkoutTracker.Data.Models;
using WorkoutTracker.Services.IService;

namespace WorkoutTracker.Services.Service
{
    public class ExerciseService : IExerciseService
    {

        private WorkoutContext _context;
        private IWorkoutService _workoutService;

        public ExerciseService(WorkoutContext context, IWorkoutService workoutService)
        {
            _context = context;
            _workoutService = workoutService;
        }
        public void AddExercise(Exercise exercise)
        {
            _context.Add(exercise);
            _context.SaveChanges();
        }

        public void AddExerciseToWorkout(int ID, Exercise exercise)
        {
            Workout workout = _workoutService.GetWorkout(ID);

            workout.Exercises.Add(exercise);
            AddExercise(exercise);

        }

        public Exercise GetExercise(int ID)
        {
            IList<Exercise> exercises = GetExercises();
            return exercises.FirstOrDefault(e => e.ID == ID);
        }

        public IList<Exercise> GetExercises()
        {
            return _context.Exercise.Include(e => e.Sets).ToList();
        }

        public void RemoveExercise(int ID)
        {
            Exercise exercise = GetExercise(ID);
            _context.Remove(exercise);
            _context.SaveChanges();
        }

        public void UpdateExercise(Exercise exercise)
        {
            Exercise exerciseToUpdate = GetExercise(exercise.ID);
            _context.Exercise.Update(exerciseToUpdate).CurrentValues.SetValues(exercise);
            _context.SaveChanges();
        }
    }
}
