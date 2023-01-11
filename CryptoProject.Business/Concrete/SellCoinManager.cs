using CryptoProject.Business.Result;
using SwapProject.Business.Abstract;
using SwapProject.Business.Constants;
using SwapProject.DataAccess.Abstract;
using SwapProject.Entity.Concrete;
using SwapProject.Entity.DTO.SellCoinDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Concrete
{
    public class SellCoinManager : ISellCoinService
    {
        private readonly ISellCoinDal _sellCoinDal;
        private readonly IParityService _parityService;

        public SellCoinManager(ISellCoinDal sellCoinDal, IParityService parityService)
        {
            _sellCoinDal = sellCoinDal;
            _parityService = parityService;
        }

        public IDataResult<bool> Create(SellCoinCreateDto sellCoinCreateDto)
        {
            try
            {
                if (sellCoinCreateDto != null)
                {
                    var statuscheck = _parityService.Get(x => x.Id == sellCoinCreateDto.ParityId).Data;
                    if (statuscheck.IsActive==true)
                    {
                        var addSellCoin = new SellCoin
                        {
                            SellerId = sellCoinCreateDto.SellerId,
                            BuyerId = sellCoinCreateDto.BuyerId,
                            Price = sellCoinCreateDto.Price,
                            Amount = sellCoinCreateDto.Amount,
                            FeePrice = sellCoinCreateDto.FeePrice,
                            ParityId = sellCoinCreateDto.ParityId,
                            StatusId = sellCoinCreateDto.StatusId,
                            SellRequestDate = sellCoinCreateDto.SellRequestDate,
                            SoldDate = sellCoinCreateDto.SoldDate,
                        };
                        _sellCoinDal.Add(addSellCoin);
                        return new SuccessDataResult<bool>(true, "OK", Messages.success);
                    }
                    return new ErrorDataResult<bool>(false, "Satmak istediğiniz coin aktif değil", Messages.operation_fail);
                 
                }
                return new ErrorDataResult<bool>(false, "Sell Coin Operation Fail", Messages.operation_fail);

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
                var delete = _sellCoinDal.Get(X => X.Id == id);
                if (delete != null)
                {
                    _sellCoinDal.Delete(delete);
                    return new SuccessDataResult<bool>(true);
                }
                return new ErrorDataResult<bool>(false);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(false,e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<SellCoin> Get(Expression<Func<SellCoin, bool>> filter = null)
        {
            try
            {
                var sellcoin = _sellCoinDal.Get(filter);
                if (sellcoin != null)
                {
                    return new SuccessDataResult<SellCoin>(sellcoin, "Ok", Messages.success);
                }
                return new ErrorDataResult<SellCoin>(null, "fail", Messages.operation_fail);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<SellCoin>(null, e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<SellCoinListDto> GetById(int id)
        {
            try
            {
                var sellcoin = _sellCoinDal.Get(x => x.Id == id);
                if (sellcoin != null)
                {
                    var sellcoinlistdto = new SellCoinListDto
                    {
                        Id=sellcoin.Id,
                        SellerId=sellcoin.SellerId,
                        BuyerId=sellcoin.BuyerId,
                        Price=sellcoin.Price,   
                        Amount=sellcoin.Amount,
                        FeePrice=sellcoin.FeePrice,
                        ParityId=sellcoin.ParityId,
                        StatusId=sellcoin.StatusId,
                        SellRequestDate=DateTime.Now,
                        SoldDate=DateTime.Now,
                    };
                    return new SuccessDataResult<SellCoinListDto>(sellcoinlistdto);
                }
                return new ErrorDataResult<SellCoinListDto>(null, "operation fail", Messages.operation_fail);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<SellCoinListDto>(null, e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<List<SellCoinListDto>> GetList()
        {
            try
            {
                var sellCoin = _sellCoinDal.GetList();
                if (sellCoin != null)
                {
                    var sellcoinlistdto = new List<SellCoinListDto>();
                    foreach (var sell in sellCoin)
                    {
                        sellcoinlistdto.Add(new SellCoinListDto
                        {
                            Id = sell.Id,
                            SellerId = sell.SellerId,
                            BuyerId = sell.BuyerId,
                            Amount = sell.Amount,
                            StatusId = sell.StatusId,
                            FeePrice = sell.FeePrice,
                            ParityId = sell.ParityId,
                            Price=sell.Price,
                            SoldDate=DateTime.Now,  
                            SellRequestDate=sell.SellRequestDate,
                        }) ;
                    }
                    return new SuccessDataResult<List<SellCoinListDto>>(sellcoinlistdto, "OK", Messages.success);

                }
                return new ErrorDataResult<List<SellCoinListDto>>(null, "Fail", Messages.operation_fail);

            }
            catch (Exception e)
            {

                return new ErrorDataResult<List<SellCoinListDto>>(null, e.Message, Messages.unknown_err);

            }
        }

        public IDataResult<bool> Update(SellCoinUpdateDto sellCoinUpdateDto)
        {
            try
            {
               
                if (sellCoinUpdateDto != null)
                {
                    var sellorder = _sellCoinDal.Get(x => x.Id == sellCoinUpdateDto.Id);
                    if (sellorder != null)
                    {
                        _sellCoinDal.Update(new SellCoin()
                        {
                            Id=sellCoinUpdateDto.Id,
                            SellerId=sellCoinUpdateDto.SellerId,
                            BuyerId=sellCoinUpdateDto.BuyerId,
                             StatusId=sellCoinUpdateDto.StatusId,   
                            Amount=sellCoinUpdateDto.Amount,
                            FeePrice=sellCoinUpdateDto.FeePrice,
                            ParityId=sellCoinUpdateDto.ParityId,
                            Price=sellCoinUpdateDto?.Price,
                          
                        });


                        return new SuccessDataResult<bool>(true, "OK", Messages.success);
                    }
                    return new ErrorDataResult<bool>(false, "Update operation fail", Messages.operation_fail);
                }
                return new ErrorDataResult<bool>(false, "ata is null", Messages.err_null);


            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(false,e.Message, Messages.unknown_err);
            }
        }
    }
}
