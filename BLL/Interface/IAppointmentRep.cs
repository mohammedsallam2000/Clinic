using BLL.Models;


namespace BLL.Interface
{
    public interface IAppointmentRep
    {
        Task<int> Create(AppointmentViewModel model);
        IEnumerable<AppointmentViewModel> GetAll();
        IEnumerable<AppointmentViewModel> GetAllDoctorAppointments(int DoctorId);
        IEnumerable<AppointmentViewModel> GetDoctorAppointmentsDateRange(int DoctorId,DateTime StartDate,DateTime EndDate);
    }

}
