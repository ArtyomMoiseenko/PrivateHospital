using PrivateHospital.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrivateHospital.Models
{
    public class PurposeModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DatePurposeService { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DatePerformService { get; set; }
        [Required]
        public string PaymentState { get; set; }

        [Required]
        public int ServiceId { get; set; }
        public IEnumerable<Service> Services { get; set; }

        [Required]
        public int DoctorPurposeId { get; set; }
        [Required]
        public int DoctorPerformId { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }

        [Required]
        public int ClientId { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}