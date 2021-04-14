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
        public DbSet<Admins> Admins { set; get; }
        public DbSet<ContactUs> ContactUs { set; get; }
        public DbSet<GaithAlQuraniProject.Models.NewRegisteredStudent> NewRegisteredStudent { get; set; }
        public DbSet<GaithAlQuraniProject.Models.ProgramConditionsDefinition> ProgramConditionsDefinitions { get; set; }
        public DbSet<GaithAlQuraniProject.Models.Attendence> Attendences { get; set; }
        public object ProgramConditionsDefinition { get; internal set; }
    }
}
