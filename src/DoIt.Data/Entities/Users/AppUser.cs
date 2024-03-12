using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Task = DoIt.Data.Entities.Tasks.Task;

namespace DoIt.Data.Entities.Users
{
    public class AppUser : IdentityUser
    {


        #region Relations

        public ICollection<Task> Tasks { get; set; }

        #endregion

    }
}
