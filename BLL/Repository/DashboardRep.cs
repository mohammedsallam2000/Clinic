using BLL.Interface;
using BLL.Models;
using DAL.Database;


namespace BLL.Repository
{
    public class DashboardRep:IDashboardRep
    {
        private readonly ApplicationDbContext db;
        public DashboardRep(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int NumberOfDoctors()
        {
            return db.Doctors.Count();
        }
        public int NumberOfDepartments()
        {
            return db.Departments.Count();
        }

        public int NumberOfPatients()
        {
            return db.Patients.Count();
        }

        public int NumberOfAppointments()
        {
            return db.Appointments.Count();
        }

        public IEnumerable<DashboardViewModel> GetAll()
        {
            List<DashboardViewModel> Doctors = new List<DashboardViewModel>();
            foreach (var item in db.Doctors)
            {
                DashboardViewModel obj = new DashboardViewModel();
                obj.DoctorName = item.Name;
                obj.PatientCount = db.Appointments.Where(x => x.DoctorId == item.DoctorId).Count();
                Doctors.Add(obj);
            }
            return Doctors;
        }
    }
}
