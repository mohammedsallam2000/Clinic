using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.Models.DoctorViewModel;

namespace BLL.Models
{
    [Index(nameof(SSN), IsUnique = true)]

    public class PatientViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "SSN is Required")]
        [MinLength(14, ErrorMessage = "SSN Must Be 14 Number This is less than 14")]
        [MaxLength(14, ErrorMessage = "SSN Must Be 14 Number This is more than 14")]
        [Remote(action: "SSNUssed", controller: "Patient")]
        public string SSN { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "BirthDate Is Required")]
        [DataType(DataType.DateTime)]
        [CustomHireDate(ErrorMessage = "Enter Real Birth Date")]

        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Phone is Required")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Another Phone is Required")]
        public string? AnotherPhone { get; set; }
        public bool IsActive { get; set; }
        public string? photo { get; set; }
        //[RegularExpression(@"(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$", ErrorMessage = "Only Image files allowed.")]
        public IFormFile PhotoUrl { get; set; }
        public DateTime LogInTime { get; set; }
        public class CustomHireDate : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime dateTime = Convert.ToDateTime(value);
                return dateTime <= DateTime.Now;
            }
        }
    }
}
