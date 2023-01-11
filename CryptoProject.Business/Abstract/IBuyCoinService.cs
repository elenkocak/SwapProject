using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using CryptoProject.Business.Result;
using SwapProject.Entity.Concrete;
using SwapProject.Entity.DTO.BuyCoinDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Abstract
{
    public interface IBuyCoinService
    {
        IDataResult<bool> Create(BuyCoinCreateDto buyCoinCreateDto);
        IDataResult<bool> Update(BuyCoinUpdateDto buyCoinUpdateDto);
        IDataResult<bool> Delete(int id);
        IDataResult<List<BuyCoinListDto>> GetList();
        IDataResult<BuyCoinListDto> GetById(int id);
        IDataResult<BuyCoin> Get(Expression<Func<BuyCoin, bool>> filter = null);
    }
}
