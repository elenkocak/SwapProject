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

        public WalletManager(IWalletDal walletDal)
        {
            _walletDal = walletDal;
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
                        CryptoCurrencyId=walletCreateDto.CryptoCurrencyId,  
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
                CryptoCurrencyId = wallet.CryptoCurrencyId,
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

                            Id=wallet.Id,
                            UserId=wallet.UserId,
                            Status=wallet.Status,
                            Amount=wallet.Amount,
                            CryptoCurrencyId=wallet.CryptoCurrencyId
                           
                        });
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

        public IDataResult<bool> Update(WalletUpdateDto walletUpdateDto)
        {
            try
            {
                if (walletUpdateDto != null)
                {
                    var wallet = _walletDal.Get(x => x.Id == walletUpdateDto.Id);
                    if (wallet != null)
                    {
                        wallet.Id = walletUpdateDto.Id;
                        wallet.UserId = walletUpdateDto.UserId;
                        wallet.CryptoCurrencyId = walletUpdateDto.CryptoCurrencyId;
                        wallet.Status=walletUpdateDto.Status;

                        return new SuccessDataResult<bool>(true, "Ok", Messages.success);
                    }
                    return new ErrorDataResult<bool>(false, "eror", Messages.not_found);
                }
                return new ErrorDataResult<bool>(false, "eror", Messages.err_null);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(false, "eror", Messages.unknown_err);
            }
        }
    }
}
