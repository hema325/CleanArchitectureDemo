using Application.Common.Mapping;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Commands.CreateItem
{
    public class CreateItemCommand: IRequest<int>
    {
        public string Name { get; set; }
    }
}
