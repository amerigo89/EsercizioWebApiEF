using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EsercizioWebApiEF.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsercizioWebApiEF.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("loans")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly LibraryContext ctx;

        public LoanController(LibraryContext contesto)
        {
            ctx = contesto;
        }

        // GET: api/Loan
        [HttpGet]
        public IEnumerable<Loan> Get()
        {
            return ctx.Loans.ToList();
        }

        // GET: api/Loan/5
        [HttpGet("{id}")]
        public Loan Get(int id)
        {
            return ctx.Loans.FirstOrDefault(l => l.Id == id);
        }

        // POST: api/Loan
        [HttpPost]
        public void Post([FromBody] Loan loan)
        {

            LoanService ls = new LoanService(ctx);

            if (ls.CheckAvailability(loan))
            {                
                ctx.Loans.Add(loan);
                ctx.SaveChanges();
            }
            else
            {
                NotFound();
            }

            //Book book = ctx.Books.FirstOrDefault(b => b.Id == loan.BookId);
            //BookController bc = new BookController(ctx);
            //if (book != null && book.Available == true && loan.Closed == false)
            //{
            //    if (loan.StartDate < loan.EndDate)
            //    {
            //        ctx.Loans.Add(loan);
            //        book.Available = false;
            //        bc.Put(book.Id, book);
            //        ctx.SaveChanges();
            //    }
            //}
        }

        // PUT: api/Loan/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Loan loan)
        {
            LoanService ls = new LoanService(ctx);

            //var found = ctx.Loans.Find(id);
            //if (loan.StartDate != DateTime.MinValue)
            //{
            //    found.StartDate = loan.StartDate;
            //}
                
            //if (loan.EndDate != DateTime.MinValue)
            //    found.EndDate = loan.EndDate;
            //if (found.Closed != loan.Closed)
            //{
            //    found.Closed = loan.Closed;
            //    ls.ChangeBookAvailable(found.BookId);                
            //}

            ctx.Loans.Update(ls.Check(loan));
            ctx.SaveChanges();
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var found = ctx.Loans.Find(id);
            ctx.Loans.Remove(found);
            ctx.SaveChanges();
        }
    }
}
