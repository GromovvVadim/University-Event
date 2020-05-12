using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using University_Event.Domain;
using University_Event.Persistence.Extensions;

namespace University_Event.Persistence
{
    public class UEDbContext : DbContext
    {
        public UEDbContext(DbContextOptions<UEDbContext> options)
            : base(options)
        {
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventStudent> EventStudents { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
