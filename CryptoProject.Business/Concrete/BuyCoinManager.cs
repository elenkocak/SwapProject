using CryptoProject.Business.Result;
using SwapProject.Business.Abstract;
using SwapProject.Business.Constants;
using SwapProject.DataAccess.Abstract;
using SwapProject.Entity.Concrete;
using SwapProject.Entity.DTO.BuyCoinDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Concrete
{
    public class BuyCoinManager : IBuyCoinService
    {
        IBuyCoinDal _buyCoinDal;
        IParityService _parityService;
        public BuyCoinManager(IBuyCoinDal buyCoinDal, IParityService parityService)
        {
            _buyCoinDal = buyCoinDal;
            _parityService = parityService;
        }

        public IDataResult<bool> Create(BuyCoinCreateDto buyCoinCreateDto)
        {
            try
            {
                if (buyCoinCreateDto != null)
                {
                    //var check = _parityService.Get(x => x.IsActive == true);
                    var parity = _parityService.Get(x => x.Id == buyCoinCreateDto.ParityId).Data;
                
                    if (parity.IsActive==true)
                    {
                     
                        decimal feeRateEth = 0.3m;
                        decimal feeRateBTC = 1.0m;
                        decimal feeRateTRY = 0.1m;
                        decimal feeRateADA = 0.2m;


                        var coins = _parityService.Get(x => x.Id == buyCoinCreateDto.ParityId).Data;
                        var buyorder = new BuyCoin();
                        if (coins.ReceivedCoinId==1)
                        {
                           

                            var price = buyCoinCreateDto.Price;
                            buyorder.Amount -= (price) +(price * feeRateEth);
                        }
                        else if (coins.ReceivedCoinId == 2)
                        {
                            var price = buyCoinCreateDto.Price;
                            buyorder.Amount -= (price) + (price * feeRateBTC);
                        }
                        else if (coins.ReceivedCoinId==3)
                        {
                            var price = buyCoinCreateDto.Price;
                            buyorder.Amount -= (price) + (price * feeRateTRY);
                        }
                        else if (coins.ReceivedCoinId==4)
                        {
                            var price = buyCoinCreateDto.Price;
                            buyorder.Amount -= (price) + (price * feeRateADA);
                        }
                        var buycoin = new BuyCoin
                        {
                            Amount = buyCoinCreateDto.Amount,
                            //SellerId = buyCoinCreateDto.SellerId,
                            BuyerId = buyCoinCreateDto.BuyerId,
                            //FeePrice = buyCoinCreateDto.FeePrice,
                            ParityId = buyCoinCreateDto.ParityId,
                            Price = buyCoinCreateDto.Price,
                            StatusId = buyCoinCreateDto.StatusId,


                        };
                        _buyCoinDal.Add(buycoin);
                        return new SuccessDataResult<bool>(true, "oK", Messages.success);
                    }
                    else
                    {
                        return new ErrorDataResult<bool>(false, "Almak istediğiniz coin aktif değil", Messages.operation_fail);

                    }

                }
                return new ErrorDataResult<bool>(false, "fail", Messages.operation_fail);
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
                var delete = _buyCoinDal.Get(x => x.Id == id);
                if (delete != null)
                {
                    _buyCoinDal.Delete(delete);
                    return new SuccessDataResult<bool>(true);
                }
                return new ErrorDataResult<bool>(false, "fail", Messages.operation_fail);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(false, e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<BuyCoin> Get(Expression<Func<BuyCoin, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<BuyCoinListDto> GetById(int id)
        {
            try
            {
                var buy = _buyCoinDal.Get(x => x.Id == id);
                if (buy !=null)
                {
                    var listDto = new BuyCoinListDto
                    {
                        Id = buy.Id,
                        SellerId = buy.SellerId,
                        BuyerId = buy.BuyerId,
                        ParityId = buy.ParityId,
                        StatusId = buy.StatusId,
                        Amount = buy.Amount,
                        FeePrice = buy.FeePrice,
                        Price = buy.Price,

                    };
                    return new SuccessDataResult<BuyCoinListDto>(listDto, "Ok", Messages.success);

                }
                return new ErrorDataResult<BuyCoinListDto>(null, "not found", Messages.not_found);

            }

            catch (Exception e)
            {

                return new ErrorDataResult<BuyCoinListDto>(null, e.Message, Messages.unknown_err);
                
            }
        }

        public IDataResult<List<BuyCoinListDto>> GetList()
        {
            try
            {
                var buy = _buyCoinDal.GetList().ToList();
                if (buy != null)
                {
                    var buylistdto = new List<BuyCoinListDto>();
                    foreach (var item in buy)
                    {
                        buylistdto.Add(new BuyCoinListDto
                        {
                            Id=item.Id,
                            FeePrice=item.FeePrice,
                            Amount=item.Amount,
                            BuyerId=item.BuyerId,
                            ParityId=item.ParityId,
                            Price=item.Price,
                            SellerId=item.SellerId,
                            StatusId=item.StatusId
                           
                            
                        });

                    }
                    return new SuccessDataResult<List<BuyCoinListDto>>(buylistdto, "oK", Messages.success);
                }
                return new ErrorDataResult<List<BuyCoinListDto>>(null, "fail", Messages.operation_fail);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<List<BuyCoinListDto>>(null, e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<bool> Update(BuyCoinUpdateDto buyCoinUpdateDto)
        {
            try
            {
                if (buyCoinUpdateDto != null)
                {
                    var buycoin = _buyCoinDal.Get(x => x.Id == buyCoinUpdateDto.Id);
                    if (buycoin != null)
                    {
                        _buyCoinDal.Update(new BuyCoin()
                        {
                           
                            Amount= buyCoinUpdateDto.Amount,
                            BuyerId = buyCoinUpdateDto.BuyerId,
                            FeePrice= buyCoinUpdateDto.FeePrice,
                            Id= buyCoinUpdateDto.Id,
                            ParityId= buyCoinUpdateDto.ParityId,
                            Price= buyCoinUpdateDto.Price,
                            SellerId= buyCoinUpdateDto.SellerId,
                            StatusId= buyCoinUpdateDto.StatusId,
                            
                        });
                        return new SuccessDataResult<bool>(true);   
                    }
                    return new ErrorDataResult<bool>(false, "fail", Messages.operation_fail);
                }
                return new ErrorDataResult<bool>(false, "DATA İS NULL", Messages.err_null);

            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(false, e.Message, Messages.unknown_err);
            }
        }
        }
    }

