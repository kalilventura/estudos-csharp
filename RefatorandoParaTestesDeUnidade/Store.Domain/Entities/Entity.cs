using System;
using Flunt.Notifications;

namespace Store.Domain.Entities
{
    public class Entity : Notifiable
    {
        public Guid Id {get; private set;}
        public Entity()
        {
            Id = new Guid();
        }
    }
}