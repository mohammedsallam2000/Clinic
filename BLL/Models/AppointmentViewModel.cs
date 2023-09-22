using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class AppointmentViewModel
    {
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "DateAndTime is Required")]
        [DataType(DataType.DateTime)]
        [CustomHireDate(ErrorMessage = "StartDate must greater than or equal to Today's Date")]
        public DateTime DateAndTime { get; set; }
        public bool State { get; set; }
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Doctor is Required")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Department is Required")]
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? DoctorName { get; set; }
        public string? PatientName { get; set; }

        public int? ShiftId { get; set; }

        public class CustomHireDate : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime dateTime = Convert.ToDateTime(value);
                return dateTime >= DateTime.Now;
            }
        }
    }
}
