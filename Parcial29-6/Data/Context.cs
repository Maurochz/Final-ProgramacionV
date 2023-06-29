using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parcial29_6.Models;

namespace Parcial29_6.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Parcial29_6.Models.Socios> Socios { get; set; } = default!;

        public DbSet<Parcial29_6.Models.Pagos>? Pagos { get; set; }
    }
}
