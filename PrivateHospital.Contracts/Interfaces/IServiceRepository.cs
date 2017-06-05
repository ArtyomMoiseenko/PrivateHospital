using PrivateHospital.Contracts.DataContracts;
using System.Collections.Generic;

namespace PrivateHospital.Contracts.Interfaces
{
    public interface IServiceRepository
    {
        IEnumerable<Service> GetAll();

        Service GetById(int id);

        void Add(Service report);

        void Update(Service reportWithChanges);

        void Delete(int id);
    }
}
