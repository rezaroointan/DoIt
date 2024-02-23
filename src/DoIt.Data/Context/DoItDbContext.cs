using DoIt.Data.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoIt.Data.Context
{
    public class DoItDbContext : DbContext
    {
        public DoItDbContext(DbContextOptions<DoItDbContext> options) : base(options) { }

        #region DB Sets

        public DbSet<User> Users { get; set; }

        #endregion
    }
}
