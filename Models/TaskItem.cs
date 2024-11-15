using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
            public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }
    }
}
