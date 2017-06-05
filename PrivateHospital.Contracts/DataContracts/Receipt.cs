using System;

namespace PrivateHospital.Contracts.DataContracts
{
    public class Receipt
    {
        public string Client { get; set; }
        public string Service { get; set; }
        public string Doctor { get; set; }
        public DateTime Date { get; set; }
        public int Cost { get; set; }
    }
}
