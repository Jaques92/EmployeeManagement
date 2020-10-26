using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    [Table("Roles")]
    public class Role
    {
        [Column("RoleID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int RoleID { get; set; }

        [Column("RoleName")]
        [Required]
        public string RoleName { get; set; }

        [Column("RoleRate")]
        [Required]
        public int RoleRate { get; set; }

        [ForeignKey("RoleID")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
