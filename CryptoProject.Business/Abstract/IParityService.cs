using CryptoProject.Business.Result;
using SwapProject.Core.Entities.Concrete;
using SwapProject.Entity.Concrete;
using SwapProject.Entity.DTO.CryptoCurrencyDto;
using SwapProject.Entity.DTO.ParityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Abstract
{
    public interface IParityService
    {
        //IDataResult<Parity> Get(Expression<Func<Parity, bool>> filter);
        IDataResult<bool> Create(ParityCreateDto parityCreateDto);  
        IDataResult<bool> Update(ParityUpdateDto parityUpdateDto);
        IDataResult<bool> Delete(int id);
        IDataResult<ParityListDto> GetById(int id);
        IDataResult<List<ParityListDto>> GetList();
        IDataResult<Parity> Get(Expression<Func<Parity, bool>> filter );
    }
    
}
