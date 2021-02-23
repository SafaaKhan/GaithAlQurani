using GaithAlQuraniProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaithAlQuraniProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<News> News { set; get; }
        public DbSet<GaithGroup> GaithGroups { set; get; }
        public DbSet<RegistrationForm> RegistrationForms { set; get; }
        public DbSet<HadeethCarousel> hadeethCarousels { set; get; }
    }
}
