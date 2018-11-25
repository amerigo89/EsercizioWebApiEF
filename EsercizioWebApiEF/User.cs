using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EsercizioWebApiEF
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }

        //richiama la FK in UserLoan per non creare colonne aggiuntive
        //[InverseProperty("Users")]
        //public ICollection<UserLoan> UserLoan { get; set; }

        //[InverseProperty("Users")]
        //public virtual ICollection<Loan> Loans { get; set; }
    }
}
