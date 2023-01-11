using CryptoProject.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Entity.DTO.CryptoCurrencyDto
{
    public class CoinsUpdateDto:IDto
    {
        public int Id { get; set; }
        public string? CoinName { get; set; }
        public string? CoinShortName { get; set; }
        public bool Status { get; set; }
    }
}
