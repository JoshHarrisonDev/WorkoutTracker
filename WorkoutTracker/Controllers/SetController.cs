using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Data.Models;
using WorkoutTracker.Models;
using WorkoutTracker.Services.IService;

namespace WorkoutTracker.Controllers
{
    public class SetController : Controller
    {
        private ISetService _setService;
        private IExerciseService _exerciseService;
        private readonly IWorkoutService _workoutService;
        public SetController(ISetService setService, IExerciseService exerciseService, IWorkoutService workoutService)
        {
            _exerciseService = exerciseService;
            _setService = setService;
            _workoutService = workoutService;

        }
        // GET: SetController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SetController/Create
        public ActionResult Create(int ID)
        {

            IList<Workout> workouts = _workoutService.GetWorkouts();
            Exercise exercise = _exerciseService.GetExercise(ID);
            int workoutID = new int();
            foreach (var workout in workouts)
            {
                if (workout.Exercises.Contains(exercise))
                {
                    workoutID = workout.ID;
                }
            }




            ExerciseSet exerciseSet = new ExerciseSet()
            {
                ExerciseID = exercise.ID,
                ExerciseName = exercise.Name,
                WorkoutID = workoutID
            };






            return View(exerciseSet);
        }

        // POST: SetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExerciseSet exerciseSet)
        {
            try
            {
                Set set = new Set()
                {
                    Reps = exerciseSet.Reps,
                    Weight = exerciseSet.Weight,

                };

                _setService.AddSetToExercise(exerciseSet.ExerciseID, set);
                return RedirectToAction("Details", "Workout", new { ID = exerciseSet.WorkoutID });
            }
            catch
            {
                return View();
            }
        }

        // GET: SetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SetController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
