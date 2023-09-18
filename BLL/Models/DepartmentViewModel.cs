using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class DepartmentViewModel
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Department Name Is Required")]
        public string Name { get; set; }
        public bool State { get; set; }
        public bool Cancel { get; set; }
    }
}
