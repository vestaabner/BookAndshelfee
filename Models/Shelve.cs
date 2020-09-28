using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public class Shelve
    {
        public int id { get; set; }
        public string  Name { get; set; }
        public int iduser { get; set; }
        public DateTime DateCreate { get; set; }
        public User User { get; set; }
        public List<BookAndShelvecs> bookAndShelvecs { get; set; }
    }
}
