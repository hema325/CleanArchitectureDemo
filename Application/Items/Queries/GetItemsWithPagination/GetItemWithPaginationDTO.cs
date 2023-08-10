using Application.Common.Mapping;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Queries.GetItemsWithPagination
{
    public class GetItemWithPaginationDTO : IMapFrom<Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        //private class Mapping: Profile
        //{
        //    internal Mapping()
        //    {
        //          profile
        //          .CreateMap<Item, GetItemWithPaginationDTO>()
        //          .ForMember(dto => dto.Name, options => options.MapFrom(i => i.Name.Value));
        //    }
        //}

        public void Mapping(Profile profile)
        {
             profile
            .CreateMap<Item, GetItemWithPaginationDTO>()
            .ForMember(dto => dto.Name, options => options.MapFrom(i => i.Name.Value));
        }
    }
}
