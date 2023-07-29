using Application.Common.Specifications;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Common.Specifications
{
    public class GetTokenByValueSpecification: SpecificationBase<Token>
    {
        public GetTokenByValueSpecification(string value) : base(t => t.Value == value)
        {

        }
    }
}
