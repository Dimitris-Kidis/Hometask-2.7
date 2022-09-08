using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hometask_2._7.Entities;
using System.Security.Claims;
using System.Configuration;

namespace Hometask_2._7
{
    public class ScheduleDbContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=.;Database=EFCore;Integrated Security=True");

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Schedule>()
                .HasOne<Client>(client => client.Client)
                .WithMany(schdule => schdule.Schedules)
                .HasForeignKey(schedule => schedule.ClientId);
        }
    }
}

