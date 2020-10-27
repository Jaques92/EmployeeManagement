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
        [Column("WIPID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int WIPID { get; set; }

        [Required]
        public int TaskID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public int EmployeeCurrentRate { get; set; }

        [Column("TaskStartDate")]
        [Required]
        public DateTime TaskStartDate { get; set; }

        [Column("TaskEndDate")]
        public DateTime TaskEndDate { get; set; }

        [Column("TimeCompleted")]
        [Required]
        public int TimeCompleted { get; set; }

        public Employee Employee { get; set; }

        public Task Task { get; set; }
    }
}
