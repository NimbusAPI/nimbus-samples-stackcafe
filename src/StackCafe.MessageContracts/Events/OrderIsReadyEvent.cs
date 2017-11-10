using System;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Events
{
    public class OrderIsReadyEvent : IBusEvent
    {
        public OrderIsReadyEvent()
        {
        }

        public OrderIsReadyEvent(Guid orderId, string coffeeType, string customerName)
        {
            OrderId = orderId;
            CoffeeType = coffeeType;
            CustomerName = customerName;
        }

        public Guid OrderId { get; set; }
        public string CoffeeType { get; set; }
        public string CustomerName { get; set; }
    }
}