﻿using System;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Events
{
    public class OrderPaidForEvent : IBusEvent
    {
        public OrderPaidForEvent()
        {
        }

        public OrderPaidForEvent(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; set; }
    }
}