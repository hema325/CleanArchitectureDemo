using Application.Common.Mapping;
using Domain.Entities;

namespace Application.Items.Queries.GetItemsWithPagination
{
    public class GetItemWithPaginationDTO: IMapFrom<Item>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ImagePath { get; private set; } 

        public void Mapping(Profile profile)
        {
             profile
            .CreateMap<Item, GetItemWithPaginationDTO>()
            .ForMember(dto => dto.Name, options => options.MapFrom(i => i.Name.Value));
        }
    }
}
