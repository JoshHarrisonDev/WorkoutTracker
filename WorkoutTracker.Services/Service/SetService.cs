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
    public class SetService : ISetService
    {
        private WorkoutContext _context;
        private IExerciseService _exerciseService;
        public SetService(WorkoutContext context, IExerciseService exerciseService)
        {
            _context = context;
            _exerciseService = exerciseService;

        }
        public void Add(Set set)
        {
            _context.Add(set);
            _context.SaveChanges();
        }

        public void AddSetToExercise(int ID, Set set)
        {
            Exercise exercise = _exerciseService.GetExercise(ID);
            exercise.Sets.Add(set);
            Add(set);
        }

        public Set GetSet(int ID)
        {
            IList<Set> sets = GetSets();
            return sets.FirstOrDefault(s => s.ID == ID);
        }

        public IList<Set> GetSets()
        {
            return _context.Set.ToList();
        }
    }
}
