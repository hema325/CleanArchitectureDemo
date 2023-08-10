using Domain.Common.Contracts;
using Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Events
{
    public class EntityCreatedEvent<TEntity> : EventBase where TEntity : EntityBase
    {
        public TEntity Entity { get; }

        public EntityCreatedEvent(TEntity entity)
        {
            Entity = entity;
        }
    }
}
