using JobApplicationPortal.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplicationPortal.DAL.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<AddressDetail> AddressDetails { get; set; }
        public DbSet<EducationalDetail> EducationalDetails { get; set; }
    }
}
