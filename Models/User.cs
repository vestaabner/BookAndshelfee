using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication13.Models
{

    public class User : IdentityUser
    {
        public string  Name { get; set; }
        public string  Addres { get; set; }
        public List<Shelve> Shelves { get; set; }
    }
}
