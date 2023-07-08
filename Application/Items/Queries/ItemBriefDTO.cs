using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Queries
{
    public class ItemBriefDTO : IMapFrom<Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
