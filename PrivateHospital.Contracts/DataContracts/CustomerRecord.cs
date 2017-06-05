using System;

namespace PrivateHospital.Contracts.DataContracts
{
    public class CustomerRecord
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int DoctorId { get; set; }
        public string Type { get; set; }
        public int Cost { get; set; }
        public string PaymentState { get; set; }
        public string Status { get; set; }
        public DateTime DateAndTimeOfRecord { get; set; }

        public virtual Client Client { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
