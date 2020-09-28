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
    [Route("api/[controller]")]
    [ApiController]
    public class ShelveController : ControllerBase
    {
        private readonly TodoContaxt contaxt1;
        public ShelveController(TodoContaxt contaxt)
        {
            contaxt1 = contaxt;
        }
        // GET: api/<ShelveController>
        [HttpGet]
        public List<Shelve> Get()
        {
            var xxx = contaxt1.Shelves.ToList();
            return xxx;
        }

        // GET api/<ShelveController>/5
        [HttpGet("{id}")]
        public Shelve Get(int id)
        {
            var res = contaxt1.Shelves
                .Where(x => x.id == id)
                .Include(x => x.bookAndShelvecs)
                .ThenInclude(x =>x.Booke)
                .FirstOrDefault();

            return res;
        }

        // POST api/<ShelveController>
        /// <summary>
        /// For add shelve 
        /// </summary>
        /// <param name="shelve"></param>
        [HttpPost]
        public string  Post([FromBody] Shelve shelve)
        {
            Shelve shelve1 = new Shelve
            {
                Name = shelve.Name,
                DateCreate = shelve.DateCreate,
                iduser=shelve.iduser
                
            };
            contaxt1.Shelves.Add(shelve1);
            contaxt1.SaveChanges();
            return "its Okey !!";
            
        }

        // PUT api/<ShelveController>/5
        /// <summary>
        /// Update 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public string  Put(int id, [FromBody] Shelve shelve)
        {
            var xxx = contaxt1.Shelves.Find(id);
            if (xxx==null)
            {
                return "This is not exist ";
            }
            xxx.Name = shelve.Name;
            xxx.DateCreate = shelve.DateCreate;
            xxx.iduser = shelve.iduser;
            contaxt1.SaveChanges();
            return "Okey shod ";
        }

        // DELETE api/<ShelveController>/5
        [HttpDelete("{id}")]
        public string  Delete(int id)
        {
            var xxx = contaxt1.Shelves.Find(id);
            if (xxx == null)
            {
                return "This is not Okey !!";
            }
            contaxt1.Shelves.Remove(xxx);
            contaxt1.SaveChanges();
            return "Okey shod "; 
        }
    }
}
