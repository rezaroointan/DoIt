using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoIt.Core.DTOs.Account
{
    public class RegisterViewModel
    {

        [Required]
        [MaxLength(120)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(120)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20,MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W_]).{6,}$", ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter and one non alphanumeric letter.")]
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string Confirmation { get; set; }
    }
}
