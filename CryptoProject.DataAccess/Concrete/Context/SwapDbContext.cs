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
            optionsBuilder.UseSqlServer(@"Server=your-server-name;Database=your-db-name;Uid=sa;Password=your-password;TrustServerCertificate=True");
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
