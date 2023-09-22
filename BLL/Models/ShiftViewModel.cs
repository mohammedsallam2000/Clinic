
using System.ComponentModel.DataAnnotations;


namespace BLL.Models
{
    public class ShiftViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Start Shift Required")]
        public DateTime StartShift { get; set; }

        [Required(ErrorMessage = "End Shift Required")]
        public DateTime EndShift { get; set; }
    }
}
