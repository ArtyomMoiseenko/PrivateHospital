using PrivateHospital.Contracts.DataContracts;
using System.Collections.Generic;

namespace PrivateHospital.Contracts.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAll();

        Client GetById(int id);

        void Add(Client report);

        void Update(Client reportWithChanges);

        void Delete(int id);
    }
}
