using EsercizioWebApiEF.Controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EsercizioWebApiEF.Services
{
    public class LoanService
    {
        private readonly LibraryContext ctx;

        public LoanService(LibraryContext contesto)
        {
            ctx = contesto;
        }

        public bool CheckAvailability(Loan loan)
        {
            Book book = ctx.Books.FirstOrDefault(b => b.Id == loan.BookId);

            if (book != null && book.Available == true && loan.Closed == false)
            {
                book.Available = false;
                ctx.Books.Update(book);
                ctx.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public void ChangeBookAvailable(int id)
        {
            Book book = ctx.Books.FirstOrDefault(b => b.Id == id);
            book.Available = true;
            //ctx.SaveChanges();
        }

        public Loan Check(Loan loan)
        {
            var found = ctx.Loans.Find(loan.Id);

            if (loan.StartDate != DateTime.MinValue && loan.StartDate < loan.EndDate)
                found.StartDate = loan.StartDate;
            if (loan.EndDate != DateTime.MinValue && loan.EndDate > loan.StartDate)
                found.EndDate = loan.EndDate;
            if (found.Closed != loan.Closed)
            {
                found.Closed = loan.Closed;
                Book book = ctx.Books.FirstOrDefault(b => b.Id == loan.BookId);
                book.Available = true;
            }
            return found;
        }
        
        public Loan changeJsonDateFormat(Loan loan)
        {
            DateTime newStartDate = DateTime.ParseExact(loan.StartDate.ToString(), "MM/dd/yyyy hh:mm:ss", CultureInfo.CurrentCulture, DateTimeStyles.None);
            DateTime newEndDate = DateTime.ParseExact(loan.EndDate.ToString(), "MM/dd/yyyy hh:mm:ss", CultureInfo.CurrentCulture, DateTimeStyles.None);
            loan.StartDate = newStartDate;
            loan.EndDate = newEndDate;
            return loan;
        }
    }
}
