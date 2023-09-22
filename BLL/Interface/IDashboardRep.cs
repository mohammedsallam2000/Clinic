using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IDashboardRep
    {
        int NumberOfDoctors();
        int NumberOfDepartments();
        int NumberOfPatients();
        int NumberOfAppointments();

        IEnumerable<DashboardViewModel> GetAll();

    }
}
