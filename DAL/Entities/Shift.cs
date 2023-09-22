using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class Shift
    {
        public int ShiftId { get; set; }
        public DateTime StartShift { get; set; }
        public DateTime EndShift { get; set; }
        public bool Delete { get; set; }
    }
}
