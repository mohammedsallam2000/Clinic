using BLL.Interface;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace UI.Controllers
{
    public class AppointmentController : Controller
    {
        #region Fields
        private readonly IDoctorRep Doctor;
        private readonly IAppointmentRep Reserve;
        private readonly IPatientRep Patient;
        #endregion

        #region Ctor
        public AppointmentController(IAppointmentRep Reserve, IDoctorRep Doctor, IPatientRep Patient)
        {
            this.Reserve = Reserve;
            this.Doctor = Doctor;
            this.Patient = Patient;
        }
        #endregion

        #region Create Appointment
        public IActionResult Create()
        {
            ViewBag.PatientIdError = 1;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentViewModel Detect)
        {
            if (ModelState.IsValid)
            {
                if (Detect.PatientId != null)
                {
                    var Data = await Reserve.Create(Detect);
                    if (Data != null)
                    {
                        ViewBag.Success = 1;

                    }
                    return View();
                }

                else
                {
                    ViewBag.PatientIdError = 0;
                    return View(Detect);

                }
            }
            return View(Detect);

        }

        #endregion

        #region Get Patint Data By SSN
        [HttpPost]
        public JsonResult GetPatintData(string SSN)
        {
            //int id = (int)TempData["model"];
            //TempData["model"] = Patient.GetBySSN(SSN);
            var data = Patient.GetBySSN(SSN);
            return Json(data);
        }
        #endregion

        #region Get All Appointments
        public IActionResult GetAllAppointments()
        {

            return View();
        }
        #endregion

        #region Get Doctor By DepartmentID And ShiftId
        [HttpPost]
        public JsonResult GetDoctorByDepartmentID(int DeptId, int ShiftId)
        {
            var doctorData = Doctor.GetAll(DeptId, ShiftId);
            return Json(doctorData);
        }
        #endregion

    }
}
