using PrivateHospital.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrivateHospital.Models
{
    public class DoctorModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 15 символов")]
        [RegularExpression("[a-zA-ZА-Яа-я]*", ErrorMessage = "Неверный формат ввода")]
        public string LastName { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 15 символов")]
        [RegularExpression("[a-zA-ZА-Яа-я]*", ErrorMessage = "Неверный формат ввода")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 15 символов")]
        [RegularExpression("[a-zA-ZА-Яа-я]*", ErrorMessage = "Неверный формат ввода")]
        public string MiddleName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Required]
        [RegularExpression("^[0-9 ]+$", ErrorMessage = "Неверный формат ввода")]
        public long Phone { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDateOfWork { get; set; }

        [Required]
        public int SpecializationId { get; set; }
        public IEnumerable<Specialization> Specializations { get; set; }
        [Required]
        public int SumAllMoney { get; set; }
    }
}