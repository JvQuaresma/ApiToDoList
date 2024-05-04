using ApiToDoList.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiToDoList.Context {
    public class TaskToDoContext : DbContext {

        public TaskToDoContext(DbContextOptions options) : base(options) {

        }

        public DbSet<TaskToDo> TasksToDo { get; set;}

    }
}
