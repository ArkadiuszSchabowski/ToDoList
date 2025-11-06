
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ToDoList_Server_Database.Entities;

namespace ToDoList_Server_Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
    }
}