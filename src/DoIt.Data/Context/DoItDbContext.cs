using DoIt.Data.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = DoIt.Data.Entities.Tasks.Task;

namespace DoIt.Data.Context
{
    public class DoItDbContext : IdentityDbContext<AppUser>
    {
        public DoItDbContext(DbContextOptions<DoItDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        #region DB Sets

        public DbSet<Task> Tasks { get; set; }

        #endregion
    }
}
