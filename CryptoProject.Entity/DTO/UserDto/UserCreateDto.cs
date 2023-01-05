using CryptoProject.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Entity.DTO.UserDto
{
    public class UserCreateDto:IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool Status { get; set; }

    }
}
