using BLL.Interface;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRep Patient;
        public PatientController(IPatientRep Patient)
        {

            this.Patient = Patient;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = await Patient.Add(model);
                if (check != 0)
                {
                    ViewBag.Success = 1;
                }
                return View();
            }


            return View();

        }

        public async Task<IActionResult> Edit(int id)
        {
            var Data = await Patient.GetByID(id);
            return View(Data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PatientViewModel model)
        {
            await Patient.Edit(model);
            return RedirectToAction("GetAll", "Patient", new { id = model.Id });
        }


        //public IActionResult Delete(int id)
        //{
        //    var DocData = Doctor.GetAll();
        //    ViewBag.DoctorList = Doctor.GetAll();
        //    return View();
        //}
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var data = await Patient.Delete(id);
            return Json(data);
        }


        public IActionResult GetAll(int id)
        {
            var DocData = Patient.GetAll();

            ViewBag.DoctorNumber = DocData.Count();
            ViewBag.DoctorList = Patient.GetAll();

            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var getDoc = await Patient.GetByID(id);
            return View(getDoc);
        }
        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> SSNUssed(string ssn)
        {
            var Ssn = Patient.SSNUnUsed(ssn);
            if (Ssn == false)
            {
                return Json($"SSN:  {ssn} is already in use.");
            }

            return Json(true);
        }
    }
}
