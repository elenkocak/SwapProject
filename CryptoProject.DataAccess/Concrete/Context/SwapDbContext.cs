using Microsoft.EntityFrameworkCore;
using SwapProject.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProject.DataAccess.Concrete.Context
{
    public class SwapDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=coinodb-dev.cjq6i1xxy6zz.eu-central-1.rds.amazonaws.com;Database=ElenSwapDb;Uid=sa;Password=DtzsCI3HF9n4WIX7O3dj6SSdC43PdpwpMtcaXtDlj8TJy3KDSJ;TrustServerCertificate=True");
        }
        public DbSet<User> Users { get; set; }

    }
}
