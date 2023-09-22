using BLL.Interface;
using BLL.Models;
using DAL.Database;
using DAL.Entities;


namespace BLL.Repository
{
    public class AppointmentRep : IAppointmentRep
    {
        #region Fields
        private readonly ApplicationDbContext context;
        #endregion

        #region Ctor
        public AppointmentRep(ApplicationDbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Create An Appointment
        public async Task<int> Create(AppointmentViewModel model)
        {
            try
            {
                Appointment obj = new Appointment();
                //mapping
                obj.DoctorId = model.DoctorId;
                obj.DoctorId = model.DoctorId;
                obj.DateAndTime = model.DateAndTime;
                obj.PatientId = model.PatientId;
                obj.DepartmentId = model.DepartmentId;              
                obj.State = false;
                await context.Appointments.AddAsync(obj);
                context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Get All Appointments
        public IEnumerable<AppointmentViewModel> GetAll()
        {
            List<AppointmentViewModel> list = new List<AppointmentViewModel>();
            foreach (var item in context.Appointments.Where(x => x.State == false))
            {
                AppointmentViewModel obj = new AppointmentViewModel();
                obj.DateAndTime = item.DateAndTime;
                obj.DepartmentName = context.Departments.Where(x => x.DepartmentId == item.DepartmentId).Select(x => x.Name).FirstOrDefault();
                obj.PatientName = context.Patients.Where(x => x.PatientId == item.PatientId).Select(x => x.Name).FirstOrDefault();
                obj.DoctorName = context.Doctors.Where(x => x.DoctorId == item.DoctorId).Select(x => x.Name).FirstOrDefault();
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #region GetAllDoctorAppointments

        public IEnumerable<AppointmentViewModel> GetAllDoctorAppointments(int DoctorId)
        {
            List<AppointmentViewModel> list = new List<AppointmentViewModel>();
            var data = context.Appointments.Where(d => d.DateAndTime.Date == DateTime.Now.Date && d.State == false && d.DoctorId == context.Doctors.Where(x => x.DoctorId == DoctorId).Select(x => x.DoctorId).FirstOrDefault());
            foreach (var item in data)
            {
                AppointmentViewModel obj = new AppointmentViewModel();
                obj.AppointmentId=item.AppointmentId;
                obj.PatientId = item.PatientId;
                obj.PatientName = context.Patients.Where(x => x.PatientId == item.PatientId).Select(x => x.Name).FirstOrDefault();
                obj.DateAndTime = item.DateAndTime;
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #region Get Doctor Appointments by Date Range

        public IEnumerable<AppointmentViewModel> GetDoctorAppointmentsDateRange(int DoctorId, DateTime StartDate, DateTime EndDate)
        {
            List<AppointmentViewModel> list = new List<AppointmentViewModel>();
            var data = context.Appointments.Where(d => d.DateAndTime.Date >= StartDate.Date && d.DateAndTime.Date <= EndDate.Date && d.State == false && d.DoctorId == context.Doctors.Where(x => x.DoctorId == DoctorId).Select(x => x.DoctorId).FirstOrDefault());
            foreach (var item in data)
            {
                AppointmentViewModel obj = new AppointmentViewModel();
                obj.AppointmentId = item.AppointmentId;
                obj.PatientId = item.PatientId;
                obj.PatientName = context.Patients.Where(x => x.PatientId == item.PatientId).Select(x => x.Name).FirstOrDefault();
                obj.DateAndTime = item.DateAndTime;
                list.Add(obj);
            }
            return list;
        }
        #endregion

    }
}
