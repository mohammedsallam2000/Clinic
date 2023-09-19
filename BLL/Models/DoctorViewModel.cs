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

        [Required(ErrorMessage = "SSN is Required")]
        [MinLength(14, ErrorMessage = "SSN Must Be 14 Number This is less than 14")]
        [MaxLength(14, ErrorMessage = "SSN Must Be 14 Number This is more than 14")]
        [Remote(action: "SSNUssed", controller: "Doctor")]       
        public string SSN { get; set; }
       
        [Required(ErrorMessage = "Phone Is Required")]
        public string Phone { get; set; }

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
        public int? VacationBalance { get; set; }

        //[Required(ErrorMessage = "Department Name is Required")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Shift is Required")]
        public int? ShiftId { get; set; }


        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "You Must Enter Valid Email")]
        [Remote(action: "VerifyEmail", controller: "Users")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Min Lenth 6")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Min Lenth 6")]
        [Compare("Password", ErrorMessage = "Not Matching")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        //[RegularExpression(@"/.*\.(gif|jpe?g|bmp|png)$/igm")]
        //[RegularExpression(@"^.*\.(jpg|JPG|gif|GIF|png|PNG)$", ErrorMessage = "Only .gif, .jpg and .png")]
        public IFormFile PhotoUrl { get; set; }
        public string Photo { get; set; }


        [Required(ErrorMessage = " Salary Required")]

        public double Salary { get; set; }
        [Required(ErrorMessage = "Shift Prise Required")]

        public double ShiftPrise { get; set; }


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
