using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Exceptions
{
    public class EmailConfirmationException: Exception
    {
        public EmailConfirmationException():base("Email is Not Confirmed")
        {

        }
    }
}
