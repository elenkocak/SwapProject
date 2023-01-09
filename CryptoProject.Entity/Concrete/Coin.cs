﻿using CryptoProject.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Entity.Concrete
{
    public class Coin:IEntity
    {
        public int? Id { get; set; }
        public string? CurrencyName { get; set; }
        public string? CurrencyShortName { get; set; }   
        public bool Status { get; set; }    

    }
}
