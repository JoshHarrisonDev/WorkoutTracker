using System.Collections.Generic;
using System.Data.Entity;
using WorkoutTracker.Data;
using WorkoutTracker.Data.Models;
using WorkoutTracker.Services.IService;
using System.Linq;

namespace WorkoutTracker.Services.Service
{
    public class UserService : IUserService
    {
        private WorkoutContext _context;

        public UserService(WorkoutContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public User GetUser(int ID)
        {
            IList<User> users = GetUsers();
            return users.Where(u => u.ID == ID).FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            IList<User> users = GetUsers();
            return users.FirstOrDefault(u => u.Email == email);
        }

        public IList<User> GetUsers()
        {
            IList<User> users = _context.User.Include(u => u.Workouts).ToList();
            return users;



        }
    }
}
