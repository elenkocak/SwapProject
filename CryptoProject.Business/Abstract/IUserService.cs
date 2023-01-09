using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using CryptoProject.Business.Result;
using SwapProject.Core.Entities.Concrete;
using SwapProject.Entity.DTO.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> Get(Expression<Func<User, bool>> filter);
        IDataResult<List<UserListDto>> GetList(Expression<Func<User, bool>> filter=null);
        IDataResult<UserListDto> GetById(int id);
        IDataResult<bool> Create(User user);  
        IDataResult<bool> Update(UserUpdateDto userUpdateDto);
        IDataResult<bool> ChangeUserPassword(User user);
        IDataResult<bool> Delete(int id);
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
