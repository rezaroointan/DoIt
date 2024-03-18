using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoIt.Core.DTOs.Tasks
{
    public class AddTaskViewModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateOnly Duration { get; set; }

        public TimeOnly Reminder { get; set; }

        [Range(minimum:0,maximum:12)]
        public int TimeBlockHours { get; set; }

        [Range(minimum: 0, maximum: 59)]
        public int TimeBlockMinutes { get; set; }

        public string UserId { get; set; }
    }
}
