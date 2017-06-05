using PrivateHospital.Contracts.DataContracts;
using System.Collections.Generic;

namespace PrivateHospital.Contracts.Interfaces
{
    public interface ISpecializationRepository
    {
        IEnumerable<Specialization> GetAll();

        Specialization GetById(int id);

        void Add(Specialization report);

        void Update(Specialization reportWithChanges);

        void Delete(int id);
    }
}
