using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.ItemEvents
{
    public class ItemCreatedEvent: BaseEvent
    {
        public Item Item { get; }

        public ItemCreatedEvent(Item item)
        {
            Item = item;
        }
    }
}
