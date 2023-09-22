using BLL.Models;


namespace BLL.Interface
{
    public interface IDoctorRep
    {
        Task<int> Add(DoctorViewModel doc);
        Task<int> Edit(DoctorViewModel doc);
        Task<bool> Delete(int id);
        Task<DoctorViewModel> GetByID(int id);
        IEnumerable<DoctorViewModel> GetAll(int id, int ShiftId);
        IEnumerable<DoctorViewModel> GetAll();
        bool SSNUnUsed(string ssn);
    }
}
