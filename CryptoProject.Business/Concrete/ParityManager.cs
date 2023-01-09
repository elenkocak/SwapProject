using CryptoProject.Business.Result;
using SwapProject.Business.Abstract;
using SwapProject.Business.Constants;
using SwapProject.DataAccess.Abstract;
using SwapProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Concrete
{
    public class ParityManager : IParityService
    {
		IParityDal _parityDal;

		public ParityManager(IParityDal parityDal)
		{
			_parityDal = parityDal;
		}

		public IDataResult<bool> Crete(Parity parity)
        {
			try
			{
				if (parity != null)
				{
					var addParity = new Parity
					{
						ReceivedCoinId = parity.ReceivedCoinId,
						SoldCoinId = parity.SoldCoinId,
						FeeRate = parity.FeeRate,
						//UnitPrice = parity.UnitPrice,
						IsActive = parity.IsActive,
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
    }
}
