using Application.Common.Specifications;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Specifications
{
    public class GetItemByIdSpecification: SpecificationBase<Item>
    {
        public GetItemByIdSpecification(int id) : base(i => i.Id == id) { }
    }
}
