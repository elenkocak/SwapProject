using CryptoProject.Business.Result;
using SwapProject.Entity.DTO.CompanyWalletDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Abstract
{
    public  interface ICompanyWalletService
    {
        IDataResult<bool> Create(CompanyWalletCreateDto companyWalletCreateDto);
        IDataResult<bool> Update(CompanyWalletUpdateDto companyWalletUpdateDto);
        IDataResult<bool> Delete(int id);
        IDataResult<List<CompanyWalletListDto>> GetList();
        IDataResult<CompanyWalletListDto> GetById(int id);  
    }
}
