using System.ComponentModel.DataAnnotations;

namespace PrivateHospital.Models
{
    public class SpecializationModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 15 символов")]
        [RegularExpression("[a-zA-ZА-Яа-я]*", ErrorMessage = "Неверный формат ввода")]
        public string NameSpecialization { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 5 до 50 символов")]
        public string Description { get; set; }
        [Required]
        [Range(typeof(int), "0", "500")]
        public int PrimaryCost { get; set; }
        [Required]
        [Range(typeof(int), "0", "500")]
        public int SecondaryCost { get; set; }
    }
}