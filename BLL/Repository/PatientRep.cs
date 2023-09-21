using BLL.Helper;
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
    public class PatientRep : IPatientRep
    {
        #region Fields
        private readonly ApplicationDbContext context;
        #endregion

        #region Ctor
        public PatientRep(ApplicationDbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Create New Patient
        public async Task<int> Add(PatientViewModel model)
        {
            try
            {
                Patient obj = new Patient();
                obj.Name = model.Name;
                obj.SSN = model.SSN;
                obj.Phone = model.Phone;
                obj.AnotherPhone = model.AnotherPhone;
                obj.Address = model.Address;
                obj.BirthDate = model.BirthDate;
                obj.Gender = model.Gender;
                obj.IsActive = false;
                obj.Photo = UploadFileHelper.SaveFile(model.PhotoUrl, "Photos");
                await context.Patients.AddAsync(obj);
                int res = await context.SaveChangesAsync();
                if (res > 0)
                {
                    return obj.PatientId;
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }

        }
        #endregion

        #region Edit Patient 
        public async Task<int> Edit(PatientViewModel model)
        {
            var OldData = context.Patients.FirstOrDefault(x => x.PatientId == model.Id);
            OldData.Name = model.Name;
            OldData.Address = model.Address;
            OldData.Phone = model.Phone;
            OldData.AnotherPhone = model.AnotherPhone;
            await context.SaveChangesAsync();
            return 0;

        }
        #endregion

        #region Delete Patient
        public async Task<bool> Delete(int id)
        {
            try
            {

                var DeletedObject = context.Patients.FirstOrDefault(x => x.PatientId == id);
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

        #region Get All Patients
        public IEnumerable<PatientViewModel> GetAll()
        {
            List<PatientViewModel> patient = new List<PatientViewModel>();
            foreach (var item in context.Patients.Where(x => x.IsActive == false))
            {
                PatientViewModel obj = new PatientViewModel();
                obj.Address = item.Address;
                obj.BirthDate = item.BirthDate;
                obj.Gender = item.Gender;
                obj.Name = item.Name;
                obj.Phone = item.Phone;
                obj.SSN = item.SSN;
                obj.photo = item.Photo;
                obj.Id = item.PatientId;
                patient.Add(obj);
            }
            return patient;
        }

        #endregion

        #region Get Patient
        public async Task<PatientViewModel> GetByID(int id)
        {
            Patient patient = context.Patients.FirstOrDefault(x => x.PatientId == id);
            PatientViewModel obj = new PatientViewModel();
            obj.Address = patient?.Address;
            obj.BirthDate = patient.BirthDate;
            obj.Gender = patient.Gender;
            obj.Name = patient.Name;
            obj.Phone = patient.Phone;
            obj.SSN = patient.SSN;
            obj.photo = patient.Photo;
            return obj;
        }

        #endregion

       

        #region Check SSN is Uniq or not
        public bool SSNUnUsed(string ssn)
        {
            var Ssn = context.Patients.Where(x => x.SSN == ssn).FirstOrDefault();
            if (Ssn != null)
            {
                return false;
            }
            return true;
        }
        #endregion


        #region Get Patient By his SSN
        public PatientViewModel GetBySSN(string SSN)
        {
            // Select Patient by his ssn 
            var patient = context.Patients.Where(x => x.SSN == SSN)
                                    .Select(x => new PatientViewModel
                                    {
                                        Id = x.PatientId,
                                        Name = x.Name,
                                        Address = x.Address,
                                        BirthDate = x.BirthDate,
                                        Phone = x.Phone,
                                        SSN = x.SSN,
                                        photo = x.Phone,
                                        Gender = x.Gender,
                                        LogInTime = x.LogInTime,
                                        IsActive = x.IsActive
                                    })
                                    .FirstOrDefault();
            return patient;
        }
        #endregion
    }
}
