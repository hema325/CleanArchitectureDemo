using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Common.Models
{
    public class TokenResult
    {
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
