using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Common;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class Users : IdentityUser
    {
        public ICollection<Orders> Orders { get; set; }
    }
}