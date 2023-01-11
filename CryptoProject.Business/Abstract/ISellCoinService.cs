using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using CryptoProject.Business.Result;
using SwapProject.Core.Entities.Concrete;
using SwapProject.Entity.Concrete;
using SwapProject.Entity.DTO.SellCoinDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Abstract
{
    public interface ISellCoinService
    {
        IDataResult<bool> Create(SellCoinCreateDto sellCoinCreateDto);
        IDataResult<bool> Update(SellCoinUpdateDto sellCoinUpdateDto);
        IDataResult<bool> Delete(int id);
        IDataResult<List<SellCoinListDto>> GetList();
        IDataResult<SellCoinListDto> GetById(int id);
        IDataResult<SellCoin> Get(Expression<Func<SellCoin, bool>> filter= null);
    }
}
