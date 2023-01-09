using CryptoProject.Business.Result;
using SwapProject.Entity.DTO.CryptoCurrencyDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Abstract
{
    public interface ICryptoCurrencyService
    {
        IDataResult<bool> Create(CoinsCreateDto cryptoCurrencyCreateDto);
        IDataResult<bool> Update(CoinsUpdateDto cryptoCurrencyUpdateDto);
        IDataResult<bool> Delete(int id);
        IDataResult<CoinsListDto> GetById(int id);
        IDataResult<List<CoinsListDto>> GetList();

        IDataResult<bool> CryptoCurrencyExists(string CurrrencyShortName);
    }
}
