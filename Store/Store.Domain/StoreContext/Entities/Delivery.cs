using System;
using FluentValidator;
using Store.Domain.StoreContext.Enum;

namespace Store.Domain.StoreContext.Entities
{
    public class Delivery : Notifiable
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }
        public void Ship()
        {
            Status = EDeliveryStatus.Shipped;
        }
        public void Cancel()
        {
            //Se já foi entregue não pode ser cancelado
            Status = EDeliveryStatus.Cancelled;
        }
    }
}