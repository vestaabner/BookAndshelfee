using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication13.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication13.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly TodoContaxt _contaxt ;
        public UsersController(TodoContaxt contaxt)
        {
            _contaxt = contaxt;
        }
        /// <summary>
        /// For rigrstring 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public string Register([FromBody] User user)
        {
            if (_contaxt.Users.Any(x=>x.UserName ==user.UserName))
            {
                return "This user is exist ";
            }
            
            User user1 = new User
            {
                
                UserName = user.UserName,
                Name = user.Name,
                Addres = user.Addres,
                Password = user.Password
            };
            _contaxt.Users.Add(user1);
            _contaxt.SaveChanges();
            return "register is okey !!!";
        }
        [HttpPost]
        public IActionResult Login([FromBody] string UserName , string PassWord)
        {
            
        }

        // GET: api/<UsersController>
        [HttpGet]
        public List<User> Get()
        {
            var ttt = _contaxt.Users.ToList();
            return ttt;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var ttt = _contaxt.Users
                .Where(x => x.IdDefine == id)
                .Include(x => x.Shelves)
                .Select(x => new User
                {
                    Name = x.Name,
                    UserName = x.UserName,
                    IdDefine = x.IdDefine,
                    Addres = x.Addres,
                    Shelves = x.Shelves.Select(z => new Shelve { Name = z.Name,DateCreate=z.DateCreate }).ToList()
                })
                .FirstOrDefault();
            return ttt;
        }

       

        // PUT api/<UsersController>/5
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public string Update(int id, [FromBody] User user)
        {
            var ttt = _contaxt.Users.Find(id);
            if (ttt==null)
            {
                return "this is not exist";
            }
            ttt.Addres = user.Addres;
            ttt.UserName = user.UserName;
            ttt.Name = user.Name;
            _contaxt.SaveChanges();

            
            return " okey shod !!";


        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public string  Delete(int id)
        {
            var ttt = _contaxt.Users
               .Where(x => x.Id == id)
               .Include(x => x.Shelves).ThenInclude(x =>x.bookAndShelvecs)
               .FirstOrDefault();

            if (ttt == null)
            {
                return "this is not exist";
            }
            
            _contaxt.Users.Remove(ttt);
            _contaxt.SaveChanges();
            return "Delete shod ";
        }
        /// <summary>
        /// delete for bookes in shelve user 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public string DeleteBookInShelveUser(int idshelve,int idbook  )
        {
           
            var qqq = _contaxt.BookAndShelvecs.Where(x => x.IdBook == idbook && x.IdShelf==idshelve ).FirstOrDefault();

            if (qqq == null)
            {
                return "this is not exist";
            }

            _contaxt.BookAndShelvecs.Remove(qqq);
            _contaxt.SaveChanges();
            return "Delete shod ";
        }
        [HttpPost("{IdUser}")]
        public string AddShelveToUser([FromBody] Shelve shelvee,int IdUser)
        {
            if (_contaxt.Shelves.Any(x=>x.id == shelvee.id && x.iduser==IdUser))
            {
                return "this shelf is exist  ";
            }
            else
            {
                Shelve shelve1 = new Shelve
                {
                    Name = shelvee.Name,
                    iduser = IdUser,
                    DateCreate = DateTime.Now,

                };
                _contaxt.Shelves.Add(shelve1);
                _contaxt.SaveChanges();
                return "register is okey !!!";
            }

        }
        //[HttpPut("{id}")]
        //public string Put(int IdUser,int idShelve, [FromBody] Shelve shelve)
        //{
        //    var xxx = _contaxt.Shelves.Find(idShelve);
        //    if (xxx == null)
        //    {
        //        return "This is not exist ";
        //    }
        //    xxx.Name = shelve.Name;
        //    xxx.DateCreate = shelve.DateCreate;
        //    xxx.iduser = shelve.iduser;
        //    _contaxt.SaveChanges();
        //    return "Okey shod ";
        //}

    }
}
