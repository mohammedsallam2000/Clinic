
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Index(nameof(SSN), IsUnique = true)]
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string SSN { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime? WorkStartTime { get; set; }
        public string Photo { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public int? ShiftId { get; set; }
        [ForeignKey("ShiftId")]
        public Shift Shift { get; set; }
        public double Salary { get; set; }
    }
}
