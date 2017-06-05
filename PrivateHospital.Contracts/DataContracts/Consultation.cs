using System;

namespace PrivateHospital.Contracts.DataContracts
{
    public class Consultation
    {
        public string Client { get; set; }
        public string TypeConsultation { get; set; }
        public string Doctor { get; set; }
        public DateTime Date { get; set; }
        public int Cost { get; set; }
    }
}
