using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoIt.Core.DTOs
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        [MaxLength(120)]
        [RegularExpression("^[a-zA-Z0-9]+$",ErrorMessage = "Username must have at least one letter or number");
        public string Username { get; set; }

        [Required]
        [StringLength(64)]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W_]).{6,}$", ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter and one non alphanumeric letter.")]
        public string Password { get; set; }

        [Required]
        [StringLength(64)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string Confirmation { get; set; }
    }
}
