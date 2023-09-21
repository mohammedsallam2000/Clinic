using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IPatientRep
    {
        Task<int> Add(PatientViewModel model);
        Task<int> Edit(PatientViewModel model);
        Task<bool> Delete(int id);
        Task<PatientViewModel> GetByID(int id);
        PatientViewModel GetBySSN(string SSN);
        IEnumerable<PatientViewModel> GetAll();
        bool SSNUnUsed(string ssn);
    }
}
