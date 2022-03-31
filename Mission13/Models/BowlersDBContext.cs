using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class BowlersDBContext : DbContext
    {  
        public BowlersDBContext(DbContextOptions<BowlersDBContext> options) : base (options)
        {

        }
        
        public DbSet<Bowler> Bowlers { get; set; }
    }

}
