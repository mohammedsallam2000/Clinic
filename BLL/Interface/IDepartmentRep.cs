using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IDepartmentRep
    {
        bool Add(DepartmentViewModel dept);
        bool Update(DepartmentViewModel dept);
        bool Cancel(int id);
        DepartmentViewModel GetByID(int id);

        IEnumerable<DepartmentViewModel> GetAll();
        IEnumerable<DepartmentViewModel> GetAllDepartmentForBooking();
    }
}
