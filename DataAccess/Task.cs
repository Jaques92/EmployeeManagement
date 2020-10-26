using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    [Table("Tasks")]
    public class Task
    {
        [Column("TaskID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int TaskID { get; set; }

        [Column("TaskName")]
        [Required]
        public string TaskName { get; set; }

        [Column("TaskDesc")]
        [Required]
        public string TaskDesc { get; set; }

        [Column("TaskDuration")]
        [Required]
        public string TaskDuration { get; set; }
    }
}
