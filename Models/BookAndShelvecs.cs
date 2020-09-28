using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public class BookAndShelvecs
    {
        public int Id { get; set; }
        public int IdBook { get; set; }
        public int IdShelf { get; set; }
        public Booke Booke { get; set; }
        public Shelve shelve { get; set; }
    }
}
