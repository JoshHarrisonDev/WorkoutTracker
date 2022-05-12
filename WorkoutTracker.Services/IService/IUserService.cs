using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Data.Models;

namespace WorkoutTracker.Services.IService
{
    public interface IUserService
    {
        void AddUser(User user);

        User GetUser(int ID);

        IList<User> GetUsers();

        User GetUserByEmail(string email);

    }
}
