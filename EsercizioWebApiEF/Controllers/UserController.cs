using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsercizioWebApiEF.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LibraryContext ctx;

        public UserController(LibraryContext contesto)
        {
            ctx = contesto;
        }
        
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return ctx.Users.ToList();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return ctx.Users.FirstOrDefault(u => u.Id == id);
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] User user)
        {
            ctx.Users.Add(user);
            ctx.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            var found = ctx.Users.Find(id);
            if (user.Name != null && user.Name != found.Name)
                found.Name = user.Name;
            if (user.Surname != null && user.Surname != found.Surname)
                found.Surname = user.Surname;
            if (user.DateOfBirth != DateTime.MinValue && user.DateOfBirth != found.DateOfBirth)
                found.DateOfBirth = user.DateOfBirth;
            if (user.Phone != found.Phone)
                found.Phone = user.Phone;
            if (user.Email != found.Email)
                found.Email = user.Email;
            if (user.City != found.City)
                found.City = user.City;
            if (user.Address != found.Address)
                found.Address = user.Address;
            if (user.Status != found.Status)
                found.Status = user.Status;
            ctx.Users.Update(found);
            //ctx.Entry(found).CurrentValues.SetValues(user);
            ctx.SaveChanges();
        }

        //[HttpPut("{id}")]
        //public void ChangeStatus(int id, User user, string status)
        //{
        //    var found = ctx.Users.Find(id);
        //    found.Status = status;
        //    ctx.Users.Update(found);
        //    //ctx.Entry(found).CurrentValues.SetValues(user);
        //    ctx.SaveChanges();
        //}

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var found = ctx.Users.Find(id);
            ctx.Users.Remove(found);
            ctx.SaveChanges();
        }
    }
}
