
using System;
using TodoApp.Services;

namespace TodoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskService = new TaskService();

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Update Task");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Change Task Status");
                Console.WriteLine("6. Search Tasks");
                Console.WriteLine("0. Exit");

                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.Write("Title: ");
                        var title = Console.ReadLine();
                        Console.Write("Description: ");
                        var description = Console.ReadLine();
                        Console.Write("Due Date (yyyy-mm-dd): ");
                        var dueDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Priority (1: High, 2: Medium, 3: Low): ");
                        var priority = int.Parse(Console.ReadLine());
                        taskService.AddTask(title, description, dueDate, priority);
                        break;

                    case "2":
                        var tasks = taskService.GetTasks();
                        foreach (var task in tasks)
                            Console.WriteLine($"ID: {task.Id} | {task.Title} | {task.Status} | Due: {task.DueDate}");
                        break;

                    case "3":
                        Console.Write("Task ID to Update: ");
                        var updateId = int.Parse(Console.ReadLine());
                        Console.Write("New Title: ");
                        var newTitle = Console.ReadLine();
                        Console.Write("New Description: ");
                        var newDescription = Console.ReadLine();
                        Console.Write("New Due Date (yyyy-mm-dd): ");
                        var newDueDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("New Priority (1: High, 2: Medium, 3: Low): ");
                        var newPriority = int.Parse(Console.ReadLine());
                        taskService.UpdateTask(updateId, newTitle, newDescription, newDueDate, newPriority);
                        break;

                    case "4":
                        Console.Write("Task ID to Delete: ");
                        var deleteId = int.Parse(Console.ReadLine());
                        taskService.DeleteTask(deleteId);
                        break;

                    case "5":
                        Console.Write("Task ID to Change Status: ");
                        var statusId = int.Parse(Console.ReadLine());
                        Console.Write("New Status (Pending, InProgress, Done, Cancelled): ");
                        var newStatus = Console.ReadLine();
                        taskService.ChangeTaskStatus(statusId, newStatus);
                        break;

                    case "6":
                        Console.Write("Enter Title to Search: ");
                        var searchTitle = Console.ReadLine();
                        var searchResults = taskService.SearchTasks(searchTitle);
                        foreach (var result in searchResults)
                            Console.WriteLine($"ID: {result.Id} | {result.Title} | {result.Status} | Due: {result.DueDate}");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
