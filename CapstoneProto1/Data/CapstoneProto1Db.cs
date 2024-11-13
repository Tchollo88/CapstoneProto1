using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapstoneProto1;

namespace CapstoneProto1.Data
{
    public class CapstoneProto1Db : DbContext
    {
        public CapstoneProto1Db (DbContextOptions<CapstoneProto1Db> options)
            : base(options)
        {
        }

        public DbSet<CapstoneProto1.ArmorPiece> ArmorPiece { get; set; } = default!;
    }
}
