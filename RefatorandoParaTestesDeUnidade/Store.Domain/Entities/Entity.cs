using System;

namespace Store.Domain.Entities
{
    public class Entity
    {
        public Guid Id {get; private set;}
        public Entity()
        {
            Id = new Guid();
        }
    }
}