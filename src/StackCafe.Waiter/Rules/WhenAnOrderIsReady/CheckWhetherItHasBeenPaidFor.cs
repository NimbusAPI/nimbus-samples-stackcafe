using System.Threading.Tasks;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Events;
using StackCafe.Waiter.Services;

namespace StackCafe.Waiter.Rules.WhenAnOrderIsReady
{
    public class CheckWhetherItHasBeenPaidFor : IHandleCompetingEvent<OrderIsReadyEvent>
    {
        private readonly IOrderDeliveryService _orderDeliveryService;

        public CheckWhetherItHasBeenPaidFor(IOrderDeliveryService orderDeliveryService)
        {
            _orderDeliveryService = orderDeliveryService;
        }

        public async Task Handle(OrderIsReadyEvent busEvent)
        {
            _orderDeliveryService.MarkAsMade(busEvent.OrderId);
        }
    }
}