using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    [Table("ActiveTasks")]
    public class ActiveTask
    {
        [Column("TaskStartDate")]
        [Required]
        public DateTime TaskStartDate { get; set; }

        [Column("TaskEndDate")]
        public DateTime TaskEndDate { get; set; }

        [Column("TimeCompleted")]
        [Required]
        public int TimeCompleted { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public int TaskID { get; set; }

        public Employee Employee { get; set; }

        public Task Task { get; set; }
    }
}
