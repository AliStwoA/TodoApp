using TodoApp.Data;
using TodoApp.Models;
    

namespace TodoApp.Services
{
    public class TaskService
    {
        private readonly TodoContext _context;

        public TaskService()
        {
            _context = new TodoContext();
            _context.Database.EnsureCreated();

        }
        public void AddTask(string title, string description, DateTime dueDate, int priority)
        {
            var task = new TaskItem 
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
                Priority = priority,
                Status = "Pending"

            };
            _context.TaskItems.Add(task);
            _context.SaveChanges();
        }

        public List<TaskItem> GetTasks(bool sortByDueDate = true)
        {
            return sortByDueDate
                ? _context.TaskItems.OrderBy(t => t.DueDate).ToList()
                : _context.TaskItems.OrderBy(t => t.Priority).ToList();
        }

        public void UpdateTask(int taskId, string newTitle, string newDescription, DateTime newDueDate, int newPriority)
        {
            var task = _context.TaskItems.Find(taskId);
            if (task != null)
            {
                task.Title = newTitle;
                task.Description = newDescription;
                task.DueDate = newDueDate;
                task.Priority = newPriority;
                _context.SaveChanges();
            }
        }

        public void DeleteTask(int taskId)
        {
            var task = _context.TaskItems.Find(taskId);
            if (task != null)
            {
                _context.TaskItems.Remove(task);
                _context.SaveChanges();
            }
        }

        public void ChangeTaskStatus(int taskId, string newStatus)
        {
            var task = _context.TaskItems.Find(taskId);
            if (task != null)
            {
                task.Status = newStatus;
                _context.SaveChanges();
            }
        }

        public List<TaskItem> SearchTasks(string searchTitle)
        {
            return _context.TaskItems
                .Where(t => t.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
    
