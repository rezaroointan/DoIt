using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoIt.Data.Entities.Users
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        [MaxLength(120)]
        public string Username { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }


        #region Relations

        #endregion

    }
}
