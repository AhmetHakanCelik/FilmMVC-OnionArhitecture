using FilmMVC.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmMVC.Application.Features.auth.Exceptions
{
    public class EmailShouldBeValidException:BaseExceptions
    {
        public EmailShouldBeValidException() : base("Email adresniniz geçersizdir.") { }
    }
}
