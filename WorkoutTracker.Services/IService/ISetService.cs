using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Data.Models;

namespace WorkoutTracker.Services.IService
{
    public interface ISetService
    {
        void Add(Set set);

        void AddSetToExercise(int ID, Set set);

        IList<Set> GetSets();

        Set GetSet(int ID);
    }
}
