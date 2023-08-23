using Microsoft.EntityFrameworkCore;
using Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class VMCurrencyDBContext : DbContext
    {
        public VMCurrencyDBContext(DbContextOptions<VMCurrencyDBContext> options)
            : base(options)
        { 
        
        }

        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}
