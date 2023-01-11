using CryptoProject.Business.Result;
using SwapProject.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Business.Abstract
{
    public interface IBinanceService
    {
         public IDataResult<ConnectApiDto> RequestBinanceApi(string parity);
        
    }
}
