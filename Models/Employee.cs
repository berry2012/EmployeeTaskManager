using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EmployeeTaskManager.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Department { get; set; }

        public string Email { get; set; }

        public ICollection<TaskItem> TaskItems { get; set; }
    }
}