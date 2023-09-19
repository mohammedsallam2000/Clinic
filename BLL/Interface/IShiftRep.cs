using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IShiftRep
    {
        void Add(ShiftViewModel model);
        bool Edit(ShiftViewModel model);
        IEnumerable<ShiftViewModel> GetAll();
        ShiftViewModel GetByID(int id);
        bool Delete(int id);
    }
}
