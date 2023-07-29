using Application.Common.Specifications;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Common.Specifications
{
    public class GetUserByIdSpecification: SpecificationBase<User>
    {
        public GetUserByIdSpecification(string id):base(u=>u.Id == id)
        {

        }
    }
}
