using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateHospital.Contracts.DataContracts
{
    public class Service
    {
        public int Id { get; set; }
        public string NameService { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }
    }
}
