using Autofac;
using SwapProject.Business.Abstract;
using SwapProject.Business.Concrete;
using SwapProject.Core.Security;
using SwapProject.DataAccess.Abstract;
using SwapProject.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProject.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyWalletManager>().As<ICompanyWalletService>();
            builder.RegisterType<EfCompanyWalletDal>().As<ICompanyWalletDal>();

            builder.RegisterType<BinanceManager>().As<IBinanceService>();

            builder.RegisterType<BuyCoinManager>().As<IBuyCoinService>();
            builder.RegisterType<EfBuyCoinDal>().As<IBuyCoinDal>();

            builder.RegisterType<SellCoinManager>().As<ISellCoinService>();
            builder.RegisterType<EfSellCoinDal>().As<ISellCoinDal>();   

            builder.RegisterType<ParityManager>().As<IParityService>();
            builder.RegisterType<EfParityDal>().As<IParityDal>();
            builder.RegisterType<CoinManager>().As<ICoinService>();
            builder.RegisterType<EfCryptoCurrencyDal>().As<ICryptoCurrencyDal>();

            builder.RegisterType<WalletManager>().As<IWalletService>();
            builder.RegisterType<EfWalletDal>().As<IWalletDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfUserOpreationClaimDal>().As<IUserOperationClaimDal>();



        }
    }
}
