using BLL.Interface;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class DoctorController : Controller
    {
        #region Field 
        private readonly IDoctorRep Doctor;
        private readonly IAppointmentRep appointment;
        #endregion

        #region Ctor 
        public DoctorController(IDoctorRep Doctor, IAppointmentRep appointment)
        {
            this.Doctor = Doctor;
            this.appointment = appointment;
        }
        #endregion

        #region Create New Doctor 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DoctorViewModel doc)
        {
            if (ModelState.IsValid)
            {
                var check = await Doctor.Add(doc);
                if (check != 0)
                {
                    ViewBag.Success = 1;
                }
                return View();
            }
            return View();
        }
        #endregion

        #region Edit Doctor
        public async Task<IActionResult> Edit(int id)
        {
            var Data = await Doctor.GetByID(id);
            return View(Data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DoctorViewModel doc)
        {
            await Doctor.Edit(doc);
            return RedirectToAction("ViewDoctor", "Doctor", new { id = doc.Id });
        }
        #endregion

        #region Delete Doctor
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var data = await Doctor.Delete(id);
            return Json(data);
        }
        #endregion

        #region Get All Doctors
        public IActionResult GetAllDoctor(int id)
        {
            var DocData = Doctor.GetAll();

            ViewBag.DoctorNumber = DocData.Count();
            ViewBag.DoctorList = Doctor.GetAll();

            return View();
        }
        #endregion

        #region Doctor Details (Profile)
        public async Task<IActionResult> Details(int id)
        {
            var getDoc = await Doctor.GetByID(id);
            return View(getDoc);
        }
        #endregion

        #region Validate SSN
        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> SSNUssed(string ssn)
        {
            var Ssn = Doctor.SSNUnUsed(ssn);
            if (Ssn == false)
            {
                return Json($"SSN:  {ssn} is already in use.");
            }
            return Json(true);
        }
        #endregion

        #region Get Doctor Appointments Date Range
        // Ajax
        [HttpPost]
        public JsonResult GetDoctorAppointmentsDateRange(int DoctorId, DateTime StartDate, DateTime EndDate)
        {
            var DoctorAppointmentsDateRangeData = appointment.GetDoctorAppointmentsDateRange(DoctorId, StartDate, EndDate);
            return Json(DoctorAppointmentsDateRangeData);
        }
        #endregion

    }
}
