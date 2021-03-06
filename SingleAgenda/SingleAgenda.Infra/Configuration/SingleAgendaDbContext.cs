using Microsoft.EntityFrameworkCore;
using SingleAgenda.Entities.Location;
using SingleAgenda.Entities.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingleAgenda.Infra.Configuration
{
    public class SingleAgendaDbContext
        : DbContext
    {

        #region Attributes
        private readonly IServiceProvider serviceProvider;
        #endregion

        #region Constructors

        protected SingleAgendaDbContext()
        {
        }

        public SingleAgendaDbContext(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public SingleAgendaDbContext(DbContextOptions options) : base(options)
        {
        }

        public SingleAgendaDbContext(DbContextOptions<SingleAgendaDbContext> options,
            IServiceProvider serviceProvider)
            : base(options)
        {
            this.serviceProvider = serviceProvider;
        }

        #endregion

        public DbSet<NaturalPerson> NaturalPersons { get; set; }
        public DbSet<LegalPerson> LegalPersons { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<StudentCourse>()
            //    .HasKey(sc => new { sc.StudentId, sc.CourseId });

            //modelBuilder.Entity<CourseStatistic>()
            //    .HasOne(cs => cs.Course)
            //    .WithMany()
            //    .HasPrincipalKey(cs => cs.Id)
            //    .HasForeignKey(c => c.CourseId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
