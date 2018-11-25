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
    [Route("books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryContext ctx;

        public BookController(LibraryContext contesto)
        {
            ctx = contesto;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return ctx.Books.ToList();
        }

        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return ctx.Books.FirstOrDefault(b => b.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] Book book)
        {
            ctx.Books.Add(book);
            ctx.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book book)
        {
            var found = ctx.Books.Find(id);
            if(book.Title != null)
                found.Title = book.Title;
            if(book.Author != null)
                found.Author = book.Author;
            if(book.Year != found.Year)
                found.Year = book.Year;
            if(found.Available != book.Available)
                found.Available = book.Available;
            if (found.Status != book.Status)
                found.Status = book.Status;
            ctx.Books.Update(found);
            //ctx.Entry(found).CurrentValues.SetValues(book);
            ctx.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var found = ctx.Books.Find(id);
            ctx.Books.Remove(found);
            ctx.SaveChanges();
        }
    }
}
