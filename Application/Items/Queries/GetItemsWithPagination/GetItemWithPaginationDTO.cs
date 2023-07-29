using Application.Common.Interfaces.Mapping;
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

        //private class Mapping: Profile
        //{
        //    internal Mapping()
        //    {
        //        CreateMap<Item, GetItemWithPaginationDTO>(); //same as IMapFrom this is just a demo
        //    }
        //}

        //public void Mapping(Profile profile) => profile.CreateMap<Item, GetItemWithPaginationDTO>(); we can customize it or use just the default implementation
    }
}
