using ToDoList_Server.Interfaces;
using ToDoList_Server_Database;
using ToDoList_Server_Database.Entities;
using ToDoList_Server.Enums;

namespace ToDoList_Server.Seeders
{
    public class TaskSeeder : ISeeder
    {
        private readonly MyDbContext _context;

        public TaskSeeder(MyDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.TaskItems.Any())
                {
                    var tasks = new List<TaskItem>
                    {
                        new TaskItem { Title = "Buy groceries", Description = "Milk, bread, eggs, and fresh fruit.", Status = Enums.TaskStatus.Pending },
                        new TaskItem { Title = "Finish project report", Description = "Prepare the quarterly report for the team.", Status = Enums.TaskStatus.Completed },
                        new TaskItem { Title = "Clean the kitchen", Description = "Wipe down counters and mop the floor.", Status = Enums.TaskStatus.Completed },
                        new TaskItem { Title = "Book dentist appointment", Description = "Schedule a routine dental check-up.", Status = Enums.TaskStatus.Completed },
                        new TaskItem { Title = "Pay electricity bill", Description = "Complete online payment before the deadline.", Status = Enums.TaskStatus.Pending },
                        new TaskItem { Title = "Read new book", Description = "Start reading 'The Pragmatic Programmer'.", Status = Enums.TaskStatus.Pending },
                        new TaskItem { Title = "Call parents", Description = "Catch up with mom and dad over the weekend.", Status = Enums.TaskStatus.Completed },
                        new TaskItem { Title = "Clean car", Description = "Wash, vacuum, and polish the interior.", Status = Enums.TaskStatus.Pending },
                        new TaskItem { Title = "Update resume", Description = "Add recent projects and achievements.", Status = Enums.TaskStatus.Completed },
                        new TaskItem { Title = "Plan weekend trip", Description = "Choose destination and book accommodation.", Status = Enums.TaskStatus.Pending },
                        new TaskItem { Title = "Organize workspace", Description = "Sort documents and clean up the desk area.", Status = Enums.TaskStatus.Pending },
                        new TaskItem { Title = "Exercise", Description = "Go jogging for at least 30 minutes.", Status = Enums.TaskStatus.Completed },
                        new TaskItem { Title = "Buy birthday gift", Description = "Get a nice present for Anna.", Status = Enums.TaskStatus.Pending },
                        new TaskItem { Title = "Prepare presentation", Description = "Finalize slides for the Monday meeting.", Status = Enums.TaskStatus.Completed },
                        new TaskItem { Title = "Backup laptop", Description = "Copy all files to external drive.", Status = Enums.TaskStatus.Pending },
                        new TaskItem { Title = "Water the plants", Description = "Water all indoor plants and balcony flowers.", Status = Enums.TaskStatus.Completed },
                        new TaskItem { Title = "Clean refrigerator", Description = "Remove expired food and wipe the shelves.", Status = Enums.TaskStatus.Pending },
                        new TaskItem { Title = "Write blog post", Description = "Draft new article about productivity habits.", Status = Enums.TaskStatus.Completed },
                        new TaskItem { Title = "Meditate", Description = "Spend 10 minutes practicing mindfulness.", Status = Enums.TaskStatus.Pending },
                        new TaskItem { Title = "Organize photos", Description = "Sort and delete duplicates from the gallery.", Status = Enums.TaskStatus.Completed }
                    };

                    _context.TaskItems.AddRange(tasks);
                    _context.SaveChanges();
                }
            }
        }
    }
}
