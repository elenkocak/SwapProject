using CryptoProject.Business.Result;
using SwapProject.Business.Abstract;
using SwapProject.Business.Constants;
using SwapProject.DataAccess.Abstract;
using SwapProject.Entity.Concrete;
using SwapProject.Entity.DTO.CompanyWalletDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Concrete
{
    public class CompanyWalletManager : ICompanyWalletService
    {
        ICompanyWalletDal _companyWalletDal;

        public CompanyWalletManager(ICompanyWalletDal companyWalletDal)
        {
            _companyWalletDal = companyWalletDal;
        }

        public IDataResult<bool> Create(CompanyWalletCreateDto companyWalletCreateDto)
        {

            try
            {
                if (companyWalletCreateDto != null)
                {
                    var addwallet = new CompanyWallet
                    {
                        CoinId = companyWalletCreateDto.CoinId,
                        Amount = companyWalletCreateDto.Amount,

                    };
                    _companyWalletDal.Add(addwallet);
                    return new SuccessDataResult<bool>(true, "oK", Messages.success);
                    
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
                var delete = _companyWalletDal.Get(x => x.Id == id);
                if (delete !=  null)
                {
                    _companyWalletDal.Delete(delete);
                    return new SuccessDataResult<bool>(true, "Ok", Messages.success);
                }
                return new ErrorDataResult<bool>(false, "fail", Messages.operation_fail);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(false, e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<CompanyWalletListDto> GetById(int id)
        {
            try
            {
                var wallet = _companyWalletDal.Get(x => x.Id == id);
                var walletlistdto = new CompanyWalletListDto
                {
                    Id = wallet.Id,
                    Amount = wallet.Amount,
                    CoinId = wallet.CoinId,
                };
                return new SuccessDataResult<CompanyWalletListDto>(walletlistdto);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<CompanyWalletListDto>(null, e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<List<CompanyWalletListDto>> GetList()
        {
            try
            {
                var wallet=_companyWalletDal.GetList().ToList();
                if (wallet!= null)
                {
                    var walletlistdto = new List<CompanyWalletListDto>();
                    foreach (var item in wallet)
                    {
                        walletlistdto.Add(new CompanyWalletListDto
                        {
                            Id = item.Id,
                            Amount=item.Amount,
                            CoinId=item.CoinId
                        });
                    }
                    return new SuccessDataResult<List<CompanyWalletListDto>>(walletlistdto);
                }
                return new ErrorDataResult<List<CompanyWalletListDto>>(null);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<List<CompanyWalletListDto>>(null, e.Message, Messages.unknown_err);

            }
        }

        public IDataResult<bool> Update(CompanyWalletUpdateDto companyWalletUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
