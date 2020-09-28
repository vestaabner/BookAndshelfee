using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication13.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication13.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookAndShelveController : ControllerBase
    {
        private readonly TodoContaxt contaxt1;
        public BookAndShelveController(TodoContaxt contaxt)
        {
            contaxt1 = contaxt;
        }
        // GET: api/<BookAndShelveController>
        [HttpGet]
        public List<BookAndShelvecs> Get()
        {
            var xxx = contaxt1.BookAndShelvecs.ToList();
           return xxx;
        }

        // GET api/<BookAndShelveController>/5
       

        // POST api/<BookAndShelveController>
        [HttpPost]
        /// for add bookandshelve 
        public string  Post([FromBody] BookAndShelvecs bookAndShelvecs)
        {
            BookAndShelvecs bookAndShelvecs1 = new BookAndShelvecs
            {
                IdBook = bookAndShelvecs.IdBook,
                IdShelf = bookAndShelvecs.IdShelf
            };
            contaxt1.BookAndShelvecs.Add(bookAndShelvecs1);
            contaxt1.SaveChanges();
            return "Okey shod ";

        }

        // PUT api/<BookAndShelveController>/5
        [HttpPut("{id}")]
        /// for update 
        public string  Put(int id, [FromBody]BookAndShelvecs bookAndShelvecs)
        {
            //var xxx = contaxt1.Bookes.Find(id);
            //var qqq = contaxt1.Shelves.Find(id);

            //if (xxx==null)
            //{
            //    return "this is not exist ";
            //}
            //xxx.Publisher = bookAndShelvecs.Booke.Publisher;
            //xxx.Name = bookAndShelvecs.Booke.Name;
            //qqq.Name = bookAndShelvecs.shelve.Name;
            //qqq.id = bookAndShelvecs.shelve.id;
            //qqq.DateCreate = bookAndShelvecs.shelve.DateCreate;
            //contaxt1.SaveChanges();
            return "Okey shod !!!";
        }

        // DELETE api/<BookAndShelveController>/5
        [HttpDelete("{id}")]
        public string  Delete(int id)
        {
            //var xxx = contaxt1.BookAndShelvecs.Find(id);
            //var ttt = contaxt1.Bookes.Find(id);
            //var qqq = contaxt1.Shelves.Find(id);

            //if (xxx==null)
            //{
            //    return "This BookAndShelve  not exist ";
            //}
            //else if (ttt == null)
            //{
            //    return "This dont have any book  ";
            //}
            //else if (qqq == null)
            //{
            //    return "This dont have any book  ";
            //}
            //contaxt1.BookAndShelvecs.Remove(xxx);
            //contaxt1.Bookes.Remove(ttt);
            //contaxt1.Shelves.Remove(qqq);
            //contaxt1.SaveChanges();
            return "delete shod ";
        }
    }
}
