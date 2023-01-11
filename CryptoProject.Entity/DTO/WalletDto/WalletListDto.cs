using CryptoProject.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Entity.DTO.WalletDto
{
    public class WalletListDto:IDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }


        public int? CoinId { get; set; }
        public decimal? Amount { get; set; }
        public bool Status { get; set; }
    }
}
