using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateHospital.Contracts.DataContracts
{
    public class Purpose
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int DoctorPurposeId { get; set; }
        public int DoctorPerformId { get; set; }
        public int ClientId { get; set; }
        public DateTime DatePurposeService { get; set; }
        public DateTime DatePerformService { get; set; }
        public string PaymentState { get; set; }

        public virtual Service Service { get; set; }
        public virtual Doctor DoctorPurpose { get; set; }
        public virtual Doctor DoctorAssign { get; set; }
        public virtual Client Client { get; set; }
    }
}
