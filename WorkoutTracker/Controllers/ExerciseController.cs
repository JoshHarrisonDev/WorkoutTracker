using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Data.Models;
using WorkoutTracker.Services.IService;
using WorkoutTracker.Models;

namespace WorkoutTracker.Controllers
{
    public class ExerciseController : Controller
    {

        private IExerciseService _exerciseService;
        private IWorkoutService _workoutService;
        public ExerciseController(IWorkoutService workoutService, IExerciseService exerciseService)
        {

            _exerciseService = exerciseService;
            _workoutService = workoutService;

        }
        // GET: ExerciseController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExerciseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExerciseController/Create
        public ActionResult Create(int ID)
        {
            Workout workout = _workoutService.GetWorkout(ID);
            ExerciseWorkout exerciseWorkout = new ExerciseWorkout()
            {
                Workout = ID,
                WorkoutName = workout.Name
            };
            return View(exerciseWorkout);
        }

        // POST: ExerciseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExerciseWorkout exerciseWorkout)
        {
            try
            {
                Exercise exercise = new Exercise()
                {
                    Name = exerciseWorkout.ExerciseName,
                };
                _exerciseService.AddExerciseToWorkout(exerciseWorkout.Workout, exercise);
                return RedirectToAction("Details", "Workout", new { ID = exerciseWorkout.Workout });
            }
            catch
            {
                return View();
            }
        }

        // GET: ExerciseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExerciseController/Edit/5
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

        // GET: ExerciseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExerciseController/Delete/5
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
