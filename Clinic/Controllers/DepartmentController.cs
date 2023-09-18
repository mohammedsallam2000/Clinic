using BLL.Interface;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRep dps;

        public DepartmentController(IDepartmentRep dps)
        {
            this.dps = dps;
        }
        public IActionResult Index()
        {
            var depts = dps.GetAll();
            return View(depts);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentViewModel dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dps.Add(dpt);
                    ViewBag.Success = 1;
                }

                return View();
            }
            catch (Exception)
            {

                return View(dpt);
            }
        }

        public IActionResult GetAllDepartments(DepartmentViewModel dpt)
        {

            return View();
        }

        public IActionResult Edit(int id)
        {
            var data = dps.GetByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentViewModel dpt, int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dpt.DepartmentId = Id;
                    ViewBag.Success = 1;
                    dps.Update(dpt);
                }
                return View(dpt);
                // return RedirectToAction("GetAllDepartments", "Department");
            }
            catch (Exception)
            {

                return View(dpt);
            }
        }

        public IActionResult Cancel(int id)
        {
            dps.Cancel(id);
            return RedirectToAction("GetAllDepartments", "Department");
        }
    }
}
