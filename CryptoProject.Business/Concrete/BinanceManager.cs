using CryptoProject.Business.Result;
using Newtonsoft.Json;
using SwapProject.Business.Abstract;
using SwapProject.Business.Constants;
using SwapProject.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SwapProject.Business.Concrete
{
    public class BinanceManager : IBinanceService
    {


        public IDataResult<ConnectApiDto> RequestBinanceApi(string parity)
        {
            var url = $"https://api.binance.com/api/v3/ticker/price?symbol={parity}";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers = {
                        { "Accept", "application/json" }
                    }
            };
                var response = client.SendAsync(request).Result;
                var test = response.Content.ReadAsStringAsync().Result;
                ConnectApiDto connect = JsonConvert.DeserializeObject<ConnectApiDto>(test);
            return new SuccessDataResult<ConnectApiDto>(new ConnectApiDto
            {
                price = connect.price
            });
            

            return new ErrorDataResult<ConnectApiDto>(default, "fail", Messages.operation_fail);



        }
    }
}
	

