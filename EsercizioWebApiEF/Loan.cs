using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EsercizioWebApiEF
{
    public class Loan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[ForeignKey("Book")]

        public int BookId { get; set; }
        //[ForeignKey("User")]

        public int UserId { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        public bool Closed { get; set; }

        //richiama la FK in UserLoan per non creare colonne aggiuntive
        //[InverseProperty("Loans")]
        //public ICollection<UserLoan> UserLoan { get; set; }

        //[ForeignKey("BookId")]
        //[InverseProperty("Loans")]
        //public Book Books { get; set; }

        //[ForeignKey("UserId")]
        //[InverseProperty("Loans")]
        //public User Users { get; set; }

        
        //public void CheckAvailable(Book book)
        //{
        //    if (book.Available == true)
        //    {
        //        book.Available = false;
        //        //return true;
        //    }
        //    else
        //        //return false;
        //        BookId = 0;
        //}

        //public void SetAvailable(Book book)
        //{
        //    if (Closed == true)
        //        book.Available = true;
        //}
    }
}