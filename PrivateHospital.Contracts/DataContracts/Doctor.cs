using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateHospital.Contracts.DataContracts
{
    public class Doctor
    {
        public int Id { get; set; }
        public int SpecializationId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
        public long Phone { get; set; }
        public DateTime StartDateOfWork { get; set; }

        public virtual Specialization Specializations { get; set; }
        public virtual ICollection<CustomerRecord> CustomerRecords { get; set; }
    }
}
