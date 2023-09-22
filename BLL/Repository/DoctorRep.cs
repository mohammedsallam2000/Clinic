using BLL.Helper;
using BLL.Interface;
using BLL.Models;
using DAL.Database;
using DAL.Entities;


namespace BLL.Repository
{
    public class DoctorRep : IDoctorRep
    {
        #region Fields
        private readonly ApplicationDbContext context;
        #endregion

        #region Ctor
        public DoctorRep(ApplicationDbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Create New Doctor
        public async Task<int> Add(DoctorViewModel doc)
        {
            try
            {
                Doctor obj = new Doctor();
                obj.Name = doc.Name;
                obj.SSN = doc.SSN;
                obj.Phone = doc.Phone;
                obj.Address = doc.Address;
                obj.ShiftId = doc.ShiftId;
                obj.BirthDate = doc.BirthDate;
                obj.Gender = doc.Gender;
                obj.IsActive = false;
                obj.DepartmentId = doc.DepartmentId;
                obj.Salary = doc.Salary;
                obj.Photo = UploadFileHelper.SaveFile(doc.PhotoUrl, "Photos");
                
               
                    await context.Doctors.AddAsync(obj);
                    int res = await context.SaveChangesAsync();
                    if (res > 0)
                    {
                        return obj.DoctorId;
                    }
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }

        }
        #endregion

        #region Edit Doctor 
        public async Task<int> Edit(DoctorViewModel doc)
        {
            var OldData = context.Doctors.FirstOrDefault(x => x.DoctorId == doc.Id);
            OldData.Name = doc.Name;
            OldData.BirthDate = doc.BirthDate;
            OldData.ShiftId = doc.ShiftId;
            OldData.Salary = doc.Salary;
            OldData.Address = doc.Address;
            OldData.Phone = doc.Phone;
            await context.SaveChangesAsync();
            return 0;

        }
        #endregion

        #region Delete Doctor
        public async Task<bool> Delete(int id)
        {
            try
            {

                var DeletedObject = context.Doctors.FirstOrDefault(x => x.DoctorId == id);
                DeletedObject.IsActive = true;
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        #endregion

        #region Get All Doctors
        public IEnumerable<DoctorViewModel> GetAll()
        {
            List<DoctorViewModel> doc = new List<DoctorViewModel>();
            foreach (var item in context.Doctors.Where(x => x.IsActive == false))
            {
                DoctorViewModel obj = new DoctorViewModel();
                obj.Address = item.Address;
                obj.BirthDate = item.BirthDate;
                obj.Gender = item.Gender;
                obj.Name = item.Name;
                obj.Phone = item.Phone;
                obj.DepartmentName = context.Departments.Where(x => x.DepartmentId == item.DepartmentId).Select(x => x.Name).FirstOrDefault();
                obj.SSN = item.SSN;
                obj.WorkStartTime = item.WorkStartTime;
                obj.Photo = item.Photo;
                obj.Id = item.DoctorId;
                obj.Salary = item.Salary;
                doc.Add(obj);
            }
            return doc;
        }

        #endregion

        #region Get Doctor
        public async Task<DoctorViewModel> GetByID(int id)
        {
            Doctor doc = context.Doctors.FirstOrDefault(x => x.DoctorId == id);
            var DepartmentName = context.Departments.Where(x => x.DepartmentId == doc.DepartmentId).Select(x => x.Name).FirstOrDefault();
            DoctorViewModel obj = new DoctorViewModel();
            obj.Address = doc.Address;
            obj.BirthDate = doc.BirthDate;
            obj.Gender = doc.Gender;
            obj.Name = doc.Name;
            obj.Phone = doc.Phone;
            obj.SSN = doc.SSN;
            obj.WorkStartTime = doc.WorkStartTime;
            obj.Photo = doc.Photo;
            obj.Id = doc.DoctorId;
            obj.DepartmentName = DepartmentName;
            obj.ShiftId = doc.ShiftId;
            obj.Salary = doc.Salary;
            return obj;
        }

        #endregion

        #region Get All Doctors In Shift
        public IEnumerable<DoctorViewModel> GetAll(int id, int ShiftId)
        {
            List<DoctorViewModel> doc = new List<DoctorViewModel>();
            foreach (var item in context.Doctors.Where(x => x.DepartmentId == id && x.ShiftId == ShiftId))
            {
                DoctorViewModel obj = new DoctorViewModel();
                obj.Address = item.Address;
                obj.BirthDate = item.BirthDate;
                obj.Gender = item.Gender;
                obj.Name = item.Name;
                obj.Phone = item.Phone;
                obj.SSN = item.SSN;
                obj.WorkStartTime = item.WorkStartTime;
                obj.Photo = item.Photo;
                obj.Id = item.DoctorId;
                doc.Add(obj);
            }
            return doc;
        }

        #endregion

        #region Check SSN is Uniq or not
        public bool SSNUnUsed(string ssn)
        {
            var Ssn = context.Doctors.Where(x => x.SSN == ssn).FirstOrDefault();
            if (Ssn != null)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
