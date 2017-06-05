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
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 5 до 500 символов")]
        public string Description { get; set; }
        [Required]
        [Range(typeof(int), "0", "500", ErrorMessage = "Диапазон стоимости от 0 до 500")]
        public int PrimaryCost { get; set; }
        [Required]
        [Range(typeof(int), "0", "400", ErrorMessage = "Диапазон стоимости от 0 до 400")]
        public int SecondaryCost { get; set; }
    }
}