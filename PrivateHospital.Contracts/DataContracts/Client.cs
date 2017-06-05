using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateHospital.Contracts.DataContracts
{
    public class Client
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public long Phone { get; set; }
        public int Discount { get; set; }

        public virtual ICollection<CustomerRecord> CustomerRecords { get; set; }
    }
}
