using CryptoProject.Business.Result;
using SwapProject.Core.Entities.Concrete;
using SwapProject.Entity.Concrete;
using SwapProject.Entity.DTO.CryptoCurrencyDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Abstract
{
    public interface ICoinService
    {
        IDataResult<bool> Create(CoinsCreateDto cryptoCurrencyCreateDto);
        IDataResult<bool> Update(CoinsUpdateDto cryptoCurrencyUpdateDto);
        IDataResult<bool> Delete(int id);
        IDataResult<CoinsListDto> GetById(int id);
        IDataResult<List<CoinsListDto>> GetList();
        IDataResult<Coin> Get(Expression<Func<Coin, bool>> filter);
        IDataResult<bool> CryptoCurrencyExists(string CurrrencyShortName);
    }
}
