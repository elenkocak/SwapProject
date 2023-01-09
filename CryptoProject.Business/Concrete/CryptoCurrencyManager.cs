using CryptoProject.Business.Result;
using SwapProject.Business.Abstract;
using SwapProject.Business.Constants;
using SwapProject.DataAccess.Abstract;
using SwapProject.DataAccess.Concrete.EntityFramework;
using SwapProject.Entity.Concrete;
using SwapProject.Entity.DTO.CryptoCurrencyDto;
using SwapProject.Entity.DTO.WalletDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Concrete
{
    public class CryptoCurrencyManager : ICryptoCurrencyService
    {
        ICryptoCurrencyDal _cryptoCurrencyDal;

        public CryptoCurrencyManager(ICryptoCurrencyDal cryptoCurrencyDal)
        {
            _cryptoCurrencyDal = cryptoCurrencyDal;
        }

        public IDataResult<bool> Create(CoinsCreateDto cryptoCurrencyCreateDto)
        {
            try
            {
                if (cryptoCurrencyCreateDto != null)
                {
                    var cryptocurrencyCheck = CryptoCurrencyExists(cryptoCurrencyCreateDto.CurrencyShortName);
                    if (cryptocurrencyCheck.Success)
                    {
                        var addCryptoCurrency = new Coin
                        {
                            CurrencyName = cryptoCurrencyCreateDto.CurrencyName,
                            CurrencyShortName = cryptoCurrencyCreateDto.CurrencyShortName,
                            Status = true
                        };
                        _cryptoCurrencyDal.Add(addCryptoCurrency);
                        return new SuccessDataResult<bool>(true, "Ok", Messages.success);

                    }
                    return new ErrorDataResult<bool>(false, "Already register", Messages.success);
                }
                return new ErrorDataResult<bool>(false, "Add operation fail", Messages.operation_fail);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(false, e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<bool> CryptoCurrencyExists(string CurrrencyShortName)
        {
            try
            {
                var crypto = _cryptoCurrencyDal.Get(x => x.CurrencyShortName == CurrrencyShortName);
                if (crypto != null)
                {
                    return new ErrorDataResult<bool>(false, "crypto currency already registered", Messages.operation_fail);
                }
                return new SuccessDataResult<bool>(true, "Ok", Messages.success);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(false, e.Message, Messages.unknown_err);

            }
        }

        public IDataResult<bool> Delete(int id)
        {
            try
            {
                var delete = _cryptoCurrencyDal.Get(x => x.Id == id);
                if (delete != null)
                {
                    delete.Status = false;
                    _cryptoCurrencyDal.Update(delete);
                    return new SuccessDataResult<bool>(true, "Ok", Messages.success);
                }
                return new ErrorDataResult<bool>(false, "Delete operation fail", Messages.operation_fail);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(false, e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<CoinsListDto> GetById(int id)
        {
            var cryptocurrency = _cryptoCurrencyDal.Get(x => x.Id == id);
            var cryptocurrencylistdto = new CoinsListDto
            {
                Id = cryptocurrency.Id,
                CurrencyShortName = cryptocurrency.CurrencyShortName,
                CurrencyName = cryptocurrency.CurrencyName,
                Status = cryptocurrency.Status,
            };
            return new SuccessDataResult<CoinsListDto>(cryptocurrencylistdto);

        }



        public IDataResult<List<CoinsListDto>> GetList()
        {
            try
            {
                var cryptocurrencies = _cryptoCurrencyDal.GetList().ToList();
                if (cryptocurrencies != null)
                {
                    var cryptoCurrencyListDto = new List<CoinsListDto>();
                    foreach (var cryptocurrency in cryptocurrencies)
                    {
                        cryptoCurrencyListDto.Add(new  CoinsListDto
                        {
                            Id = cryptocurrency.Id,

                            CurrencyName = cryptocurrency.CurrencyName,
                            CurrencyShortName=cryptocurrency.CurrencyShortName,
                           Status=cryptocurrency.Status,

                        });
                    }
                    return new SuccessDataResult<List<CoinsListDto>>(cryptoCurrencyListDto);
                }
                return new ErrorDataResult<List<CoinsListDto>>(null, "error", Messages.operation_fail);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<List<CoinsListDto>>(null, e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<bool> Update(CoinsUpdateDto cryptoCurrencyUpdateDto)
        {
            try
            {
                if (cryptoCurrencyUpdateDto != null)
                {
                    var cryptoCurrency = _cryptoCurrencyDal.Get(x => x.Id == cryptoCurrencyUpdateDto.Id);
                    if (cryptoCurrency != null)
                    {
                        cryptoCurrency.Id = cryptoCurrencyUpdateDto.Id;
                        cryptoCurrency.CurrencyName = cryptoCurrencyUpdateDto.CurrencyName; 
                        cryptoCurrency.CurrencyShortName = cryptoCurrencyUpdateDto.CurrencyShortName;
                       
                        cryptoCurrency.Status = cryptoCurrencyUpdateDto.Status;

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
