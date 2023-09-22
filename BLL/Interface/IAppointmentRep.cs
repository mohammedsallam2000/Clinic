using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IAppointmentRep
    {
        Task<int> Create(AppointmentViewModel model);
        IEnumerable<AppointmentViewModel> GetAll();
        IEnumerable<AppointmentViewModel> GetAllDoctorAppointments(int DoctorId);
    }

}
