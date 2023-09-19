using BLL.Interface;
using BLL.Models;
using DAL.Database;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class ShiftRep : IShiftRep
    {
        private readonly ApplicationDbContext db;

        public ShiftRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Add(ShiftViewModel shift)
        {
            Shift obj = new Shift();
            obj.StartShift = shift.StartShift;
            obj.EndShift = shift.EndShift;
            obj.Delete = false;
            db.Shifts.Add(obj);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var shift = db.Shifts.Where(x => x.ShiftId == id).FirstOrDefault();
            shift.Delete = true;
            db.SaveChanges();
            return true;

        }

        public IEnumerable<ShiftViewModel> GetAll()
        {
            List<ShiftViewModel> list = new List<ShiftViewModel>();
            foreach (var obj in db.Shifts.Where(x => x.Delete == false))
            {
                ShiftViewModel shift = new ShiftViewModel();
                shift.StartShift = obj.StartShift;
                shift.EndShift = obj.EndShift;
                shift.Id = obj.ShiftId;
                list.Add(shift);

            }
            return list;
        }

        public ShiftViewModel GetByID(int id)
        {
            var shift = db.Shifts.Where(x => x.ShiftId == id).FirstOrDefault();
            ShiftViewModel obj = new ShiftViewModel();
            obj.StartShift = shift.StartShift;
            obj.EndShift = shift.EndShift;
            obj.Id = shift.ShiftId;
            return obj;


        }

        public bool Edit(ShiftViewModel shift)
        {
            var shifts = db.Shifts.Where(x => x.ShiftId == shift.Id).FirstOrDefault();
            shifts.StartShift = shift.StartShift;
            shifts.EndShift = shift.EndShift;
            db.SaveChanges();
            return true;
        }
    }
}
