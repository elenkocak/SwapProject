using CryptoProject.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Entity.DTO
{
    public class ConnectApiDto:IDto
    {
        public decimal price { get; set; }
    }
}
