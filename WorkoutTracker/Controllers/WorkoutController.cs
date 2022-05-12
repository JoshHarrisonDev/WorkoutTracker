using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Services.IService;
using WorkoutTracker.Models;
using WorkoutTracker.Data.Models;

namespace WorkoutTracker.Controllers
{
    public class WorkoutController : Controller
    {
        private IWorkoutService _workoutService;
        private IExerciseService _exerciseService;
        private IUserService _userService;
        public WorkoutController(IWorkoutService workoutService, IExerciseService exerciseService, IUserService userService)
        {
            _workoutService = workoutService;
            _exerciseService = exerciseService;
            _userService = userService;

        }
        // GET: WorkoutController
        public ActionResult Index()
        {
            var workouts = _workoutService.GetWorkouts();
            return View(workouts);
        }
        public ActionResult MyWorkouts(int ID)
        {
            var workouts = _workoutService.GetWorkoutsUser(ID);
            return View(workouts);
        }

        // GET: WorkoutController/Details/5
        public ActionResult Details(int id)
        {
            var workout = _workoutService.GetWorkout(id);


            return View(workout);
        }

        // GET: WorkoutController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkoutController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Workout workout)
        {
            try
            {


                User user = _userService.GetUser((int)HttpContext.Session.GetInt32("UserID"));
                _workoutService.AddWorkoutUser(user, workout);
                return RedirectToAction("MyWorkouts", new { ID = HttpContext.Session.GetInt32("UserID") });
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkoutController/Edit/5
        public ActionResult Edit(int id)
        {
            var workout = _workoutService.GetWorkout(id);
            return View(workout);
        }

        // POST: WorkoutController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Workout workout)
        {
            try
            {

                _workoutService.UpdateWorkout(workout);
                return RedirectToAction("MyWorkouts", new { ID = HttpContext.Session.GetInt32("UserID") });
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkoutController/Delete/5
        public ActionResult Delete(int id)
        {
            var workout = _workoutService.GetWorkout(id);
            return View(workout);
        }

        // POST: WorkoutController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _workoutService.DeleteWorkout(id);
                return RedirectToAction("MyWorkouts", new { ID = HttpContext.Session.GetInt32("UserID") });
            }
            catch
            {
                return View();
            }
        }
    }
}
