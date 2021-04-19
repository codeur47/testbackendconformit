using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Infrastructures
{
    public class ConformitContext : DbContext
    {
        public ConformitContext(DbContextOptions options) : base(options)
        {
        }
    

        public DbSet<Event> Event { get; set; }

        public DbSet<Comment> Comment { get; set; }
    }
}
