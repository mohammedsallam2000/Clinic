using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class DoctorViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }
        public string? DepartmentName { get; set; }

        [Required(ErrorMessage = "SSN is Required")]
        [MinLength(14, ErrorMessage = "SSN Must Be 14 Number This is less than 14")]
        [MaxLength(14, ErrorMessage = "SSN Must Be 14 Number This is more than 14")]
        [Remote(action: "SSNUssed", controller: "Doctor")]       
        public string SSN { get; set; }
       
        [Required(ErrorMessage = "Phone Is Required")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Gender Is Required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "BirthDate Is Required")]
        [DataType(DataType.DateTime)]
        [CustomHireDate(ErrorMessage = "Enter Real Birth Date")]
        public DateTime? BirthDate { get; set; }
        [Required(ErrorMessage = "Address Is Required")]
        public string Address { get; set; }
        //[Required(ErrorMessage = "Enter Your Date of WorkStarts")]
        public DateTime? WorkStartTime { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Department is Required")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Shift is Required")]
        public int? ShiftId { get; set; }

       public IFormFile? PhotoUrl { get; set; }
        public string? Photo { get; set; }

        public DateTime AppointmentSartDate { get; set; }
        public DateTime AppointmentEndDate { get; set; }

        [Required(ErrorMessage = " Salary Required")]

        public double Salary { get; set; }


        public class CustomHireDate : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime dateTime = Convert.ToDateTime(value);
                return dateTime.Year <= DateTime.Now.Year-20;
            }
        }
    }
}
