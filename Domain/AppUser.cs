using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class AppUser : IdentityUser<int> 
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}