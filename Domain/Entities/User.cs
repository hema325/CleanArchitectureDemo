using Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class User:EntityBase
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string HashedPassword { get; set; }

        public List<UserRoles> UserRoles { get; set; }
        public List<Token> Tokens { get; set; }

    }
}
