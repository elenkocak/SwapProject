using CryptoProject.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Entity.DTO.ParityDto
{
    public class ParityListDto:IDto
    {
        public int? Id { get; set; }

        public int? ReceivedCoinId { get; set; }
        public int? SoldCoinId { get; set; }
        //public string ReceivedCoinName { get; set; }
        //public string SoldCoinName{ get; set; }
        public bool? IsActive { get; set; }
        public decimal? FeeRate { get; set; }
    }
}
