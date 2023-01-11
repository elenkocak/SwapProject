using CryptoProject.Business.Result;
using SwapProject.Business.Abstract;
using SwapProject.Business.Constants;
using SwapProject.Core.Entities.Concrete;
using SwapProject.Core.Security;
using SwapProject.DataAccess.Abstract;
using SwapProject.Entity.Concrete;
using SwapProject.Entity.DTO.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IUserOperationClaimDal _userOperationClaimDal;
        private IWalletDal _walletDal;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimDal userOperationClaimDal, IWalletDal walletDal)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userOperationClaimDal = userOperationClaimDal;
            _walletDal = walletDal;
        }

        public IDataResult<bool> ChangeUserPassword(UserPasswordChangeDto userChangePasswordDto)
        {
            try
            {
                byte[] passwordsalt, passwordhash;
                HashingHelper.CreatePasswordHash(userChangePasswordDto.Password, out passwordsalt, out passwordhash);

                var user = _userService.Get(u => u.Email == userChangePasswordDto.Email).Data;
                if (user != null)
                {
                    user.PasswordSalt = passwordsalt;
                    user.PasswordHash = passwordhash;
                    var result = _userService.ChangeUserPassword(user);
                    return result.Success == true ? new SuccessDataResult<bool>(true, "Ok", Messages.success) : new ErrorDataResult<bool>(false, result.Message, result.MessageCode);
                }
                return new ErrorDataResult<bool>(false, "User not found", Messages.not_found);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<bool>(false, ex.Message, Messages.unknown_err);
            }
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            try
            {
                var claims = _userService.GetClaims(user);
                if (claims != null)
                {
                    var accessToken = _tokenHelper.CreateToken(user, claims.Data);
                    return new SuccessDataResult<AccessToken>(accessToken, "Ok", Messages.success);
                }
                return new ErrorDataResult<AccessToken>(null, claims.Message, claims.MessageCode);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<AccessToken>(null, ex.Message, Messages.unknown_err);
            }
        }

        public IDataResult<string> Login(UserLoginDto userLoginDto)
        {
            try
            {
                var user = _userService.Get(x => x.Email == userLoginDto.Email).Data;
                if (user==null)
                {
                    return new ErrorDataResult<string>(null, "USER NOT FOUND", Messages.not_found);
                }
                if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, user.PasswordSalt, user.PasswordHash))
                {
                    return new ErrorDataResult<string>(null, "user password is wrong", Messages.wrong_password);
                }
                var tokenGenerator = CreateAccessToken(user);
                return new SuccessDataResult<string>(tokenGenerator.Data.Token, "Ok", Messages.success);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<string>(null, e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<bool> Register(UserRegisterDto userRegisterDto)
        {
            try
            {
                var userCheck = UserExist(userRegisterDto.Email);
                if (userCheck.Success)
                {
                    byte[] passwordsalt, passwordhash;
                    HashingHelper.CreatePasswordHash(userRegisterDto.Password, out passwordsalt, out passwordhash);
                    var user = new User
                    {
                        Name = userRegisterDto.Name,
                        Surname = userRegisterDto.Surname,
                        Email = userRegisterDto.Email,
                        PasswordHash = passwordhash,
                        PasswordSalt = passwordsalt,
                        Username = userRegisterDto.Username,
                        Status = true
                    };
                    var result = _userService.Create(user);
                    if (result.Success)
                    {
                        _userOperationClaimDal.Add(new UserOperationClaim { UserId = user.Id, OperationClaimId = (int)OperationClaims.Member });
                        var addwallet = new Wallet
                        {
                            UserId = user.Id,
                            Status = true,
                        };
                        _walletDal.Add(addwallet);
                        return new SuccessDataResult<bool>(true, "oK", Messages.success);

                      
                    }
                    return new ErrorDataResult<bool>(false, userCheck.Message, userCheck.MessageCode);

                  
                }
                return new ErrorDataResult<bool>(false, userCheck.Message, userCheck.MessageCode);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(false, e.Message, Messages.unknown_err);
            } 
        }

        public IDataResult<bool> UserExist(string email)
        {
            try
            {
                var user = _userService.Get(x => x.Email == email).Data;
                if (user != null)
                {
                    return new ErrorDataResult<bool>(false, "user already registered", Messages.already_registered);
                }
                return new SuccessDataResult<bool>(true, "Ok", Messages.success);

            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(false, e.Message, Messages.unknown_err);
            }
        }

    
    }
}
