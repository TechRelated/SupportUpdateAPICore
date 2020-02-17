using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Configuration;
using System.Collections.Generic;
using SupportUpdateAPICore.Models;
using SupportUpdateAPICore.Data;

namespace SupportUpdateAPICore.Models
{
    public class SupportUpdateContext : IdentityDbContext<User>
    {
        public SupportUpdateContext(DbContextOptions<SupportUpdateContext> options) : base(options)
        {

        }

        public DbSet<Client> Client { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<Priorities> Priority { get; set; }

        public DbSet<Staff> Staff { get; set; }

        public DbSet<SupportUpdate> SupportUpdate { get; set; }

        public DbSet<User> User { get; set; }
    }
}
