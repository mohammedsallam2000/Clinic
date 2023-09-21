using BLL.Interface;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
