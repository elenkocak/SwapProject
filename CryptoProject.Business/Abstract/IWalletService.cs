using CryptoProject.Business.Result;
using SwapProject.Business.Concrete;
using SwapProject.Entity.Concrete;
using SwapProject.Entity.DTO.WalletDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Abstract
{
    public interface IWalletService
    {
        IDataResult<bool> Create(WalletCreateDto walletCreateDto);
        IDataResult<Wallet> Update(WalletUpdateDto walletUpdateDto);
        IDataResult<List<WalletListDto>> GetList();
        IDataResult<List<WalletListDto>> ActiveGetList();
        IDataResult<bool> Delete(int walletId);
        IDataResult<WalletListDto> GetById(int id);
    }
}
