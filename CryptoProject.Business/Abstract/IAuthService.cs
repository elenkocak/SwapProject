using CryptoProject.Business.Result;
using SwapProject.Core.Entities.Concrete;
using SwapProject.Core.Security;
using SwapProject.Entity.DTO.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<bool> Register(UserRegisterDto userRegisterDto);
        IDataResult<bool> ChangeUserPassword(UserPasswordChangeDto userChangePasswordDto);
        IDataResult<string> Login(UserLoginDto userLoginDto);
        IDataResult<bool> UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
