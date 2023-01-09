using CryptoProject.Business.Result;
using CryptoProject.Core.Repository;
using SwapProject.Entity.Concrete;
using SwapProject.Entity.DTO.WalletDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.DataAccess.Abstract
{
    public interface IWalletDal:IEntityRepository<Wallet>
    {
        
    }
}
