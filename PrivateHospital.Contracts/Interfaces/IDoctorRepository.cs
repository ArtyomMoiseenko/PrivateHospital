using PrivateHospital.Contracts.DataContracts;
using System.Collections.Generic;

namespace PrivateHospital.Contracts.Interfaces
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAll();

        Doctor GetById(int id);

        void Add(Doctor report);

        void Update(Doctor reportWithChanges);

        void Delete(int id);

        int GetSumAllMoney(int id);
    }
}
