using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public class Booke
    {
        public int ID { get; set; }
        public string  Name { get; set; }
        public string  Publisher { get; set; }
        public List<BookAndShelvecs> bookAndShelvecs { get; set; }
    }
}
