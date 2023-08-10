using Application.Common.Mapping;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Queries.GetItemById
{
    public class GetItemByIdDTO: IMapFrom<Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public void Mapping(Profile profile)
        {
            profile
           .CreateMap<Item, GetItemByIdDTO>()
           .ForMember(dto => dto.Name, options => options.MapFrom(i => i.Name.Value));
        }
    }
}
