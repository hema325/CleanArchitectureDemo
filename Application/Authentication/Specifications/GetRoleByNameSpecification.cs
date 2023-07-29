using Application.Common.Specifications;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Specifications
{
    public class GetRoleByNameSpecification : SpecificationBase<Role>
    {
        public GetRoleByNameSpecification(Roles role) : base(r => r.Name == role.ToString())
        {
        }
    }
}
