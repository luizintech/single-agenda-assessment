using Microsoft.EntityFrameworkCore;
using SingleAgenda.Entities.Location;
using SingleAgenda.Entities.Contact;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using SingleAgenda.Entities.UsersAndRoles;

namespace SingleAgenda.EFPersistence.Configuration
{
    public class SingleAgendaDbContext
        : DbContext
    {

        #region Attributes
        private readonly IServiceProvider serviceProvider;
        #endregion

        #region Constructors

        //protected SingleAgendaDbContext()
        //{
        //}

        //public SingleAgendaDbContext(IServiceProvider serviceProvider)
        //{
        //    this.serviceProvider = serviceProvider;
        //}

        public SingleAgendaDbContext(DbContextOptions options) : base(options)
        {
        }

        //public SingleAgendaDbContext(DbContextOptions<SingleAgendaDbContext> options,
        //    IServiceProvider serviceProvider)
        //    : base(options)
        //{
        //    this.serviceProvider = serviceProvider;
        //}

        #endregion

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Person)
                .WithMany(p => p.Addresses)
                .HasPrincipalKey(p => p.Id)
                .HasForeignKey(a => a.PersonId);

        }

        //Use this just to setup initial database.
        //Just uncomment this lines bellow.

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SingleAgenda;Persist Security Info=True;");
        //}


    }
}
