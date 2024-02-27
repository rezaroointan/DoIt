using DoIt.Data.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoIt.Data.Context
{
    public class DoItDbContext : IdentityDbContext<AppUser>
    {
        public DoItDbContext(DbContextOptions<DoItDbContext> options) : base(options) { }

        #region DB Sets


        #endregion
    }
}
