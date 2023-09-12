using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment16.Models;

namespace Assignment16.Data
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext (DbContextOptions<TasksDbContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment16.Models.Task_1> Task_1 { get; set; } = default!;
    }
}
