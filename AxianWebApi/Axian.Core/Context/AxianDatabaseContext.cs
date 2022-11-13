using Axian.Models.DatabaseModels.Main;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Axian.Core.Context
{
    public class AxianDatabaseContext:IdentityDbContext<IdentityUser>
    {
        public AxianDatabaseContext() : base() { }

        public AxianDatabaseContext(DbContextOptions<AxianDatabaseContext> options) : base(options) { }


        public DbSet<AxianEmployee> AxianEmployees { get; set; }
        public DbSet<AxianUser> AxianUsers{ get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AxianUser>().HasKey(u => u.UserId);
            builder.Entity<AxianEmployee>().HasKey(e => e.EmpId);
        }
    }
}
