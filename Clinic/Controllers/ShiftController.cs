using BLL.Interface;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class ShiftController : Controller
    {
        private readonly IShiftRep shift;

        public ShiftController(IShiftRep shift)
        {
            this.shift = shift;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ShiftViewModel shifts)
        {
            if (ModelState.IsValid)
            {
                shift.Add(shifts);
                ViewBag.Success = 1;
            }


            return View();
        }
        public IActionResult Edit(int id)
        {

            var data = shift.GetByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(ShiftViewModel shifts)
        {
            if (ModelState.IsValid)
            {
                shift.Edit(shifts);
                ViewBag.Success = 1;

            }

            return View(shifts);
        }
        public IActionResult GetAll()
        {
            var data = shift.GetAll();
            return View(data);
        }
        public JsonResult Delete(int id)
        {

            var data = shift.Delete(id);

            return Json(data);

        }
    }
}
