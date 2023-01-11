using CryptoProject.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Entity.DTO.ParityDto
{
    public class ParityUpdateDto:IDto
    {
        public int? Id { get; set; }
        public int? ReceivedCoinId { get; set; }
        public int? SoldCoinId { get; set; }
        public bool? IsActive { get; set; }
        public decimal? FeeRate { get; set; }
    }
}
