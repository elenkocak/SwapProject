using CryptoProject.Business.Result;
using SwapProject.Business.Abstract;
using SwapProject.Business.Constants;
using SwapProject.DataAccess.Abstract;
using SwapProject.Entity.Concrete;
using SwapProject.Entity.DTO.WalletDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Concrete
{
    public class WalletManager : IWalletService
    {
        private readonly IWalletDal _walletDal;
        private readonly IUserService _userService;
        public WalletManager(IWalletDal walletDal, IUserService userService)
        {
            _walletDal = walletDal;
            _userService = userService;
        }

        public IDataResult<List<WalletListDto>> ActiveGetList()
        {
            throw new NotImplementedException();
        }

        public IDataResult<bool> Create(WalletCreateDto walletCreateDto)
        {
            try
            {
                if (walletCreateDto != null)
                {
                    var addwallet = new Wallet
                    {
                        CoinId = walletCreateDto.CoinId,  
                        Amount=walletCreateDto.Amount,
                        UserId=walletCreateDto.UserId,
                        Status=true
                    };
                    _walletDal.Add(addwallet);
                    return new SuccessDataResult<bool>(true, "Ok", Messages.success);
                }
                return new ErrorDataResult<bool>(false, "Fail", Messages.operation_fail);
            }
            catch (Exception e )
            {

                return new ErrorDataResult<bool>(false, e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<bool> Delete(int walletId)
        {
            try
            {
                var deleteWallet = _walletDal.Get(x => x.Id == walletId);
                if (deleteWallet != null)
                {
                    deleteWallet.Status = false;
                    _walletDal.Update(deleteWallet);
                    return new SuccessDataResult<bool>(true, "Ok", Messages.success);
                }
                return new ErrorDataResult<bool>(false, "Delete operation fail", Messages.operation_fail);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(false,e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<WalletListDto> GetById(int id)
        {
            var wallet = _walletDal.Get(x => x.Id == id);
            var walletlistDto = new WalletListDto
            {
                Id = wallet.Id,
                UserId = wallet.UserId,
                Amount = wallet.Amount,
                CoinId = wallet.CoinId,
                Status = wallet.Status
            };
            return new SuccessDataResult<WalletListDto>(walletlistDto);
        }

        public IDataResult<List<WalletListDto>> GetList()
        {
            try
            {
                var wallets = _walletDal.GetList().ToList();
                if (wallets != null)
                {
                    var walletlistdto = new List<WalletListDto>();
                    foreach (var wallet in wallets)
                    {
                        walletlistdto.Add(new WalletListDto
                        {

                            Id = wallet.Id,
                            UserId = wallet.UserId,
                            Status = wallet.Status,
                            Amount = wallet.Amount,
                            CoinId = wallet.CoinId

                        }) ;
                    }
                    return new SuccessDataResult<List<WalletListDto>>(walletlistdto);   
                }
                return new ErrorDataResult<List<WalletListDto>>(null, "error", Messages.operation_fail);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<List<WalletListDto>>(null, e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<Wallet> Update(WalletUpdateDto walletUpdateDto)
        {
            try
            {
                if (walletUpdateDto != null)
                {
                    var wallet = _walletDal.Get(x => x.Id == walletUpdateDto.Id);
                    var walletlist = new Wallet()
                    {
                        Id = walletUpdateDto.Id,
                        Amount = walletUpdateDto.Amount,
                        Status = walletUpdateDto.Status,
                        CoinId = walletUpdateDto.CoinId,
                        UserId = walletUpdateDto.UserId
                    };
                    _walletDal.Update(walletlist);
                    return new SuccessDataResult<Wallet>(walletlist, "Ok", Messages.success);

                }
                return new ErrorDataResult<Wallet>(null, "null", Messages.err_null);

            }
            catch (Exception e)
            {

                return new ErrorDataResult<Wallet>(null, "error", Messages.unknown_err);
            }
        }
    }
}
