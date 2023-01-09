using CryptoProject.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Entity.Concrete
{
    public class Parity:IEntity
    {
        public int ReceivedCoinId { get; set; }
        public int SoldCoinId { get; set; }    
        public bool IsActive { get; set; }  
        public decimal FeeRate { get; set; }
        //public decimal UnitPrice { get; set; }
    }
}
