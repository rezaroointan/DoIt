using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoIt.Core.DTOs.Tasks
{
    public class InboxItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime Created { get; set; }

        public DateOnly Duration { get; set; }

        public TimeOnly Reminder { get; set; }

        public TimeSpan TimeBlock { get; set; }

        public bool Done { get; set; }
    }
}
