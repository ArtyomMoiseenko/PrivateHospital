using PrivateHospital.Contracts.DataContracts;
using System.Collections.Generic;

namespace PrivateHospital.Contracts.Interfaces
{
    public interface ICustomerRecordRepository
    {
        IEnumerable<CustomerRecord> GetAll();

        CustomerRecord GetById(int id);

        void Add(CustomerRecord report);

        void Update(CustomerRecord reportWithChanges);

        void Delete(int id);

        Consultation GetReceipt(int id);
    }
}
