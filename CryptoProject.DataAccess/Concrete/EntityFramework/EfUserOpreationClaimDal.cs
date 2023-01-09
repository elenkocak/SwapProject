using CryptoProject.Core.EntityFramework;
using CryptoProject.DataAccess.Concrete.Context;
using SwapProject.Core.Entities.Concrete;
using SwapProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.DataAccess.Concrete.EntityFramework
{
    public class EfUserOpreationClaimDal : EfEntityRepositoryBase<UserOperationClaim, SwapDbContext>, IUserOperationClaimDal
    {
    }
}
