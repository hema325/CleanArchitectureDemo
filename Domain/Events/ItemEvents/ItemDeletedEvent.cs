using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.ItemEvents
{
    public class ItemDeletedEvent: BaseEvent
    {
        public Item Item { get; }

        public ItemDeletedEvent(Item item)
        {
            Item = item;
        }
    }
}
