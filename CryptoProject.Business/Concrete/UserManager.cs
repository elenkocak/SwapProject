using CryptoProject.Business.Result;
using SwapProject.Business.Abstract;
using SwapProject.Business.Constants;
using SwapProject.Core.Entities.Concrete;
using SwapProject.DataAccess.Abstract;
using SwapProject.Entity.DTO.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<bool> ChangeUserPassword(User user)
        {
            try
            {
                var checkUser = _userDal.Get(u => u.Id == user.Id);
                if (checkUser != null)
                {
                    _userDal.Update(user);
                    return new SuccessDataResult<bool>(true, "Ok", Messages.success);
                }
                return new ErrorDataResult<bool>(false, "User not found", Messages.not_found);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<bool>(false, ex.Message, Messages.unknown_err);
                throw;
            }
        }

        public IDataResult<bool> Create(User user)
        {
           

                try
                {
                    if (user != null)
                    {
                        _userDal.Add(user);
                        return new SuccessDataResult<bool>(true, "Ok", Messages.success);
                    }
                    return new ErrorDataResult<bool>(false, "Given Dto is null", Messages.err_null);
                }
                catch (Exception ex)
                {
                    return new ErrorDataResult<bool>(false, ex.Message, Messages.unknown_err);
                }

        

        }

        public IDataResult<bool> Delete(int id)
        {
            try
            {
                var user = _userDal.Get(x => x.Id == id);
                if (user != null)
                {
                    user.Status = false;
                    _userDal.Update(user);
                    return new SuccessDataResult<bool>(true, "Ok", Messages.success);
                }
                return new ErrorDataResult<bool>(false, "delete operation fail", Messages.operation_fail);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(false, e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<User> Get(Expression<Func<User, bool>> filter)
        {
            try
            {
                var user = _userDal.Get(filter);
                if (user !=null)
                {
                    return new SuccessDataResult<User>(user, "Ok", Messages.success);
                }
                return new ErrorDataResult<User>(null, "fail", Messages.not_found);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<User>(null, e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<UserListDto> GetById(int id)
        {
            try
            {
                var user = _userDal.Get(x => x.Id == id);
                if (user!= null)
                {
                    var userListDto = new UserListDto
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Username = user.Username,
                        Surname = user.Surname,
                        Email = user.Email,
                        Status = user.Status,

                    };
                    return new SuccessDataResult<UserListDto>(userListDto);
                   
                }
                return new SuccessDataResult<UserListDto>(null, "user not found", Messages.not_found);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<UserListDto>(null, e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            try
            {
                if (user != null)
                {
                    var claims = _userDal.GetClaims(user);
                    return new ErrorDataResult<List<OperationClaim>>(claims, "Ok", Messages.success);
                }
                return new ErrorDataResult<List<OperationClaim>>(null, "Operation claims not found", Messages.not_found);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<OperationClaim>>(null, ex.Message, Messages.unknown_err);
            }
        }

        public IDataResult<List<UserListDto>> GetList(Expression<Func<User, bool>> filter = null)
        {

            try
            {
                var users = _userDal.GetList();
                if (users != null)
                {
                    var userListDto = new List<UserListDto>();
                    foreach (var user in users)
                    {
                        userListDto.Add(new UserListDto
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Surname = user.Surname,
                            Username = user.Username,
                            Email = user.Email,
                            Status = user.Status

                        });
                    }
                    return new SuccessDataResult<List<UserListDto>>(userListDto, "OK", Messages.success);

                }
                return new ErrorDataResult<List<UserListDto>>(null, "Fail", Messages.operation_fail);
            }
            catch (Exception E)
            {

                return new ErrorDataResult<List<UserListDto>>(null, E.Message, Messages.unknown_err);
            }
        }

        public IDataResult<bool> Update(UserUpdateDto userUpdateDto)
        {
            try
            {
                var user = _userDal.Get(x => x.Id == userUpdateDto.Id);
                if (user != null)
                {
                    _userDal.Update(new User()
                    {
                        Id=userUpdateDto.Id,
                        Name=userUpdateDto.Name,
                        Surname=userUpdateDto.Surname,
                        Username=userUpdateDto.Username,
                        Email=userUpdateDto.Email,
                        Status=userUpdateDto.Status,
                        PasswordHash=user.PasswordHash,
                        PasswordSalt=user.PasswordSalt
                        
                    });
                    //_userDal.Update(user);
                    return new SuccessDataResult<bool>(true, "Ok", Messages.success);
                }
                return new ErrorDataResult<bool>(false, "Fail", Messages.operation_fail);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unknown_err);
            }
        }
    }
}
