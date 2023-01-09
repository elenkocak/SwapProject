using CryptoProject.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Entity.DTO.UserDto
{
    public class UserPasswordChangeDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
