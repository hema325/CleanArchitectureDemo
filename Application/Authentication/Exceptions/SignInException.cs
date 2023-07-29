using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Exceptions
{
    public class SignInException: Exception
    {
        public SignInException() : base("faild to sign in please make sure the data you provide is correct")
        {

        }
    }
}
