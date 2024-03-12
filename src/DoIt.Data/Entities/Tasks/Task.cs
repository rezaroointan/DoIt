using DoIt.Data.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoIt.Data.Entities.Tasks
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateOnly Duration { get; set; }

        public TimeOnly Reminder { get; set; }

        public TimeOnly TimeBlock { get; set; }

        public string UserId { get; set; }

        #region Relations

        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }

        #endregion
    }
}
