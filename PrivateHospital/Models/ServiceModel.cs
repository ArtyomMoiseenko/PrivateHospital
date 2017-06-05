using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrivateHospital.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 15 символов")]
        [RegularExpression("[a-zA-ZА-Яа-я]*", ErrorMessage = "Неверный формат ввода")]
        public string NameService { get; set; }
        [Required]
        [Range(typeof(int), "0", "1000")]
        public int Cost { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 15 символов")]
        public string Description { get; set; }
        [Required]
        [Range(typeof(int), "0", "100")]
        public int Discount { get; set; }
    }
}