using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EsercizioWebApiEF
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public bool Available { get; set; }
        public string Status { get; set; }

        //per relazione one to many Book -> Loan (1 prenotazione ha 1 libro, ma 1 libro può avere più prenotazioni)
        //public virtual ICollection<Loan> Loans { get; set; }

        //[InverseProperty("Books")]
        //public virtual ICollection<Loan> Loans { get; set; }
    }
}
