using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    [Table("Employees")]
    public class Employee
    {
        [Column("EmployeeID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int EmployeeID { get; set; }

        [Column("EmployeeName")]
        [Required]
        public string EmployeeName { get; set; }

        [Column("EmployeeSurname")]
        [Required]
        public string EmployeeSurname { get; set; }

        [Column("EmployeeEmail")]
        [Required]
        public string EmployeeEmail { get; set; }
        
        [Column("EmployeePassword")]
        [Required]
        public string EmployeePassword { get; set; }

        [Column("EmployeeStartDate")]
        [Required]
        public DateTime EmployeeStartDate { get; set; }

        [Column("EmployeeEndDate")]
        public DateTime EmployeeEndDate { get; set; }

        [Column("EmployeeImage")]
        public byte[] EmployeeImage { get; set; }

        [Required]
        public int RoleID { get; set; }
    }
}
