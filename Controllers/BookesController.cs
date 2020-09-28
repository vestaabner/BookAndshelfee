using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication13.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication13.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookesController : ControllerBase
    {
        private readonly TodoContaxt _context;
        public BookesController(TodoContaxt contaxt)
        {
            _context = contaxt;
        }
        // GET: api/<BookesController>
        [HttpGet()]
        public List<Booke> GetAll()
        {
            var book = _context.Bookes.ToList();
            return book;
        }

        // GET api/<BookesController>/5
        [HttpGet("{id}")]
        public Booke Get(int id)
        {
            var book = _context.Bookes.Find(id);
            return book;
        }

        // POST api/<BookesController>
        /// <summary>
        /// for adding 
        /// </summary>
        /// <param name="booke"></param>
        [HttpPost]
        public string  Post([FromBody] Booke booke)
        {
            Booke booke1 = new Booke
            {
                Name = booke.Name,
                Publisher = booke.Publisher
            };
            _context.Bookes.Add(booke1);
            _context.SaveChanges();
            return "The book is saved ";
        }

        // PUT api/<BookesController>/5
        /// <summary>
        /// Update 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public string  Put(int id, [FromBody] Booke booke)
        {
            var book = _context.Bookes.Find(id);
            if (book==null)
            {
                return "This is not exist";
            }
            book.Name = booke.Name;
            book.Publisher = booke.Publisher;
            _context.SaveChanges();
            return "Okey shod!! ";
        }

        // DELETE api/<BookesController>/5
        [HttpDelete("{id}")]
        public string  Delete(int id)
        {
            var book = _context.Bookes.Find(id);
            if (book==null)
            {
                return "This is not exist ";

            }
            _context.Bookes.Remove(book);
            _context.SaveChanges();
            return "Delete shod ";
        }
    }
}
