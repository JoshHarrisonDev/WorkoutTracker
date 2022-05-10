using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data.Models;

namespace WorkoutTracker.Data
{
    public class WorkoutContext : DbContext
    {
        public WorkoutContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }

        public DbSet<Workout> Workout { get; set; }

        public DbSet<Exercise> Exercise { get; set; }

        public DbSet<Set> Set { get; set; }
    }
}
