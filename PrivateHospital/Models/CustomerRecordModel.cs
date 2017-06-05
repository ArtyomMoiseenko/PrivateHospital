using PrivateHospital.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrivateHospital.Models
{
    public class CustomerRecordModel
    {
        public int Id { get; set; }
        [Required]
        public string PaymentState { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime DateAndTimeOfRecord { get; set; }
        [Required]
        public int ClientId { get; set; }
        public IEnumerable<Client> Clients { get; set; }
        [Required]
        public int DoctorId { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public string Type { get; set; }
        public List<string> VisitType { get; } = new List<string> { "Первичный осмотр", "Вторичный осмотр" };

        public Consultation Consultation { get; set; }
    }
}