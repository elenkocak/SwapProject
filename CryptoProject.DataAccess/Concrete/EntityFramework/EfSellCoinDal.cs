using CryptoProject.Core.EntityFramework;
using CryptoProject.DataAccess.Concrete.Context;
using SwapProject.DataAccess.Abstract;
using SwapProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.DataAccess.Concrete.EntityFramework
{
    public class EfSellCoinDal:EfEntityRepositoryBase<SellCoin,SwapDbContext>, ISellCoinDal
    {
    }
}
