using System.Threading.Tasks;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Events;
using StackCafe.Waiter.Services;

namespace StackCafe.Waiter.Rules.WhenAnOrderIsPaidFor
{
    public class CheckWhetherItHasAlreadyBeenMade : IHandleCompetingEvent<OrderPaidForEvent>
    {
        private readonly IOrderDeliveryService _orderDeliveryService;

        public CheckWhetherItHasAlreadyBeenMade(IOrderDeliveryService orderDeliveryService)
        {
            _orderDeliveryService = orderDeliveryService;
        }

        public async Task Handle(OrderPaidForEvent busEvent)
        {
            _orderDeliveryService.MarkAsPaid(busEvent.OrderId);
        }
    }
}