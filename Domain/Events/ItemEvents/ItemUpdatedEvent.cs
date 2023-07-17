using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.ItemEvents
{
    public class ItemUpdatedEvent: BaseEvent
    {
        public Item Item { get; }

        public ItemUpdatedEvent(Item item)
        {
            Item = item;
        }
    }
}
