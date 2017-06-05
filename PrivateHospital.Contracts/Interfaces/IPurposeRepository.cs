using PrivateHospital.Contracts.DataContracts;
using System.Collections.Generic;

namespace PrivateHospital.Contracts.Interfaces
{
    public interface IPurposeRepository
    {
        IEnumerable<Purpose> GetAll();

        Purpose GetById(int id);

        void Add(Purpose report);

        void Update(Purpose reportWithChanges);

        void Delete(int id);
    }
}
