using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BowlsApp.Models;

namespace BowlsApp.Data
{
    public class BowlsAppContext : DbContext
    {
        public BowlsAppContext (DbContextOptions<BowlsAppContext> options)
            : base(options)
        {
        }
        public DbSet<Bowl> Bowl { get; set; }
    }
}
