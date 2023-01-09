using SwapProject.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Core.Security
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User users, List<OperationClaim> operationClaims);
    }
}
