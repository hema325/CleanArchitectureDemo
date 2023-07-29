using Application.Common.Specifications;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Common.Specifications
{
    public class GetUserByEmailSpecification : SpecificationBase<User>
    {
        public GetUserByEmailSpecification(string email) : base(u=>u.Email == email)
        {
        }
    }
}
