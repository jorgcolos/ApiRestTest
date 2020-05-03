using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}