using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProjectEventAssos.Domain.Models;
namespace ProjectEventAssos.Infrastucture.DataBase.DataContext
{
    public class AssocEventContext : DbContext
    {
        public AssocEventContext(DbContextOptions options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssocEventContext).Assembly);
        }
    }
}
