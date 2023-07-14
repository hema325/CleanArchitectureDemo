using Application.Common.Mapping;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommand: IRequest, IMapTo<Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
