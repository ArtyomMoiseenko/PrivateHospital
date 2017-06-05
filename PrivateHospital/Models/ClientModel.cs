using System;
using System.ComponentModel.DataAnnotations;

namespace PrivateHospital.Models
{
    public class ClientModel
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
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 30 символов")]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Required]
        [RegularExpression("^[0-9 ]+$", ErrorMessage = "Неверный формат ввода")]
        public long Phone { get; set; }
        [Required]
        [Range(typeof(int), "0", "100", ErrorMessage = "Диапазон скидки от 0 до 100")]
        public int Discount { get; set; }
        [Required]
        public int SumAllMoney { get; set; }
    }
}