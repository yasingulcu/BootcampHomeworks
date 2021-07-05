using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public int TC { get; set; }
    }
}
