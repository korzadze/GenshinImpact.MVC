using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GenshinImpactHelper.Models;

namespace GenshinImpactHelper.Data
{
    public class GenshinImpactHelperContext : DbContext
    {
        public GenshinImpactHelperContext (DbContextOptions<GenshinImpactHelperContext> options)
            : base(options)
        {
        }

        public DbSet<GenshinImpactHelper.Models.GiServer> GiServers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<GenshinImpactHelper.Models.GiElement> Elements { get; set; }
    }
}
