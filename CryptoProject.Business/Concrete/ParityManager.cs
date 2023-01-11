using CryptoProject.Business.Result;
using SwapProject.Business.Abstract;
using SwapProject.Business.Constants;
using SwapProject.DataAccess.Abstract;
using SwapProject.Entity.Concrete;
using SwapProject.Entity.DTO.ParityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Concrete
{
    public class ParityManager : IParityService
    {
		IParityDal _parityDal;
		ICoinService _coinService;

		public ParityManager(IParityDal parityDal, ICoinService coinService)
		{
			_parityDal = parityDal;
			_coinService = coinService;
		}

		public IDataResult<bool> Create(ParityCreateDto parityCreateDto)
        {
			try
			{
				if (parityCreateDto != null)
				{
					var addParity = new Parity
					{
						ReceivedCoinId = parityCreateDto.ReceivedCoinId,
						SoldCoinId = parityCreateDto.SoldCoinId,
						//FeeRate = parityCreateDto.FeeRate,
						//UnitPrice = parity.UnitPrice,
						IsActive = parityCreateDto.IsActive,
					};
				
					_parityDal.Add(addParity);
					return new SuccessDataResult<bool>(true);
				}
				return new ErrorDataResult<bool>(false);
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
				var delete = _parityDal.Get(x => x.Id == id);
				if (delete != null)
				{
					_parityDal.Delete(delete);
					return new SuccessDataResult<bool>(true);
				}
				return new ErrorDataResult<bool>(false, "Delete operation fail", Messages.operation_fail);
			}
			catch (Exception e)
			{

                return new ErrorDataResult<bool>(false,e.Message, Messages.unknown_err);
            }
		}

		public IDataResult<Parity> Get(Expression<Func<Parity, bool>> filter)
		{
			try
			{
				var parity = _parityDal.Get(filter);
				if (parity ==null)
				{
					return new ErrorDataResult<Parity>(null, "user not found", Messages.not_found);
				}
				return new SuccessDataResult<Parity>(new Parity
				{
					Id=parity.Id,
					FeeRate=parity.FeeRate,
					SoldCoinId=parity.SoldCoinId,
					IsActive=parity.IsActive,
					ReceivedCoinId=parity.ReceivedCoinId
				}, Messages.success, "Ok");
			}
			catch (Exception e)
			{

				return new ErrorDataResult<Parity>(null, e.Message, Messages.unknown_err);
			}
		}

		public IDataResult<ParityListDto> GetById(int id)
		{
			try
			{
				var parity = _parityDal.Get(x => x.Id == id);
				var paritylistdto = new ParityListDto
				{
					Id = parity.Id,
                    ReceivedCoinId = parity.ReceivedCoinId,
                    SoldCoinId = parity.SoldCoinId,
					FeeRate = parity.FeeRate,
					IsActive = parity.IsActive
				};
				return new SuccessDataResult<ParityListDto>(paritylistdto);
			}
			catch (Exception e)
			{

				throw;
			}
		}

		public IDataResult<List<ParityListDto>> GetList()
		{
			try
			{
                var parities = _parityDal.GetList().ToList();
                if (parities != null)
                {
                    var paritieslistdto = new List<ParityListDto>();
                    foreach (var parity in parities)
                    {
                        paritieslistdto.Add(new ParityListDto
                        {
                            Id = parity.Id,
                            FeeRate = parity.FeeRate,
                            IsActive = parity.IsActive,
							ReceivedCoinId = parity.ReceivedCoinId,
							SoldCoinId = parity.SoldCoinId,
                            //ReceivedCoinName = _coinService.Get(x => x.Id == parity.ReceivedCoinId).Data.CoinShortName,
                            //SoldCoinName = _coinService.Get(x => x.Id == parity.SoldCoinId).Data.CoinShortName,
                        });
                    }
                    return new SuccessDataResult<List<ParityListDto>>(paritieslistdto);
                }
                return new ErrorDataResult<List<ParityListDto>>(null);
            }
			catch (Exception e)
			{

                return new ErrorDataResult<List<ParityListDto>>(null, e.Message, Messages.unknown_err);
            }
        }

		public IDataResult<bool> Update(ParityUpdateDto parityUpdateDto)
		{
			try
			{
				if (parityUpdateDto != null)
				{
					var parity = _parityDal.Get(x => x.Id == parityUpdateDto.Id);
					if (parity != null)
					{
						_parityDal.Update(new Parity()
						{
							Id=parityUpdateDto.Id,
							FeeRate=parityUpdateDto.FeeRate,
							SoldCoinId=parityUpdateDto.SoldCoinId,
							ReceivedCoinId=parityUpdateDto.ReceivedCoinId,
							IsActive=parityUpdateDto.IsActive
						});

						return new SuccessDataResult<bool>(true, "OK", Messages.success);
				
					}
					return new ErrorDataResult<bool>(false, "Update operation fail", Messages.operation_fail);
				}
                return new ErrorDataResult<bool>(false, "data is null", Messages.err_null);
            }
			catch (Exception e)
			{

                return new ErrorDataResult<bool>(false,e.Message, Messages.unknown_err);
            }
		}
	}
}
