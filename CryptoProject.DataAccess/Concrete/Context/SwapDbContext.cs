using Microsoft.EntityFrameworkCore;
using SwapProject.Core.Entities.Concrete;
using SwapProject.Entity.Concrete;
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
        public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
        public DbSet<OperationClaim> OperationClaim { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<Parity> Parities { get; set; }
        public DbSet<SellCoin> SellCoins { get; set; }
        public DbSet<BuyCoin> BuyCoins { get; set; }
        public DbSet<CompanyWallet> CompanyWallets { get; set; }
    }
}
