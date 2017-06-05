using System.Collections.Generic;

namespace PrivateHospital.Contracts.DataContracts
{
    public class Specialization
    {
        public int Id { get; set; }
        public string NameSpecialization { get; set; }
        public string Description { get; set; }
        public int PrimaryCost { get; set; }
        public int SecondaryCost { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
