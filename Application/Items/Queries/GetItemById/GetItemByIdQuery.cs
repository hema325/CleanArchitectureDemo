using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Queries.GetItemById
{
    public class GetItemByIdQuery: IRequest<GetItemByIdDTO>
    {
        public int Id { get; set; }

    }
}
