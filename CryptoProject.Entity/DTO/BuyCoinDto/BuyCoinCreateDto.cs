using CryptoProject.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Entity.DTO.BuyCoinDto
{
    public class BuyCoinCreateDto:IDto
    {
        public int? BuyerId { get; set; }
        //public int? SellerId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Amount { get; set; }
        public decimal? FeePrice { get; set; }
        public int? StatusId { get; set; }
        public int? ParityId { get; set; }
    }
}
