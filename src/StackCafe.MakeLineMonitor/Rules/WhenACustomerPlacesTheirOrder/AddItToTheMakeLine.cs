using System.Threading.Tasks;
using Nimbus;
using Nimbus.Handlers;
using StackCafe.MakeLineMonitor.Services;
using StackCafe.MessageContracts.Events;

namespace StackCafe.MakeLineMonitor.Rules.WhenACustomerPlacesTheirOrder
{
    public class AddItToTheMakeLine : IHandleMulticastEvent<OrderPlacedEvent>
    {
        private readonly IMakeLineService _makeLine;

        public AddItToTheMakeLine(IMakeLineService makeLine)
        {
            _makeLine = makeLine;
        }

        public Task Handle(OrderPlacedEvent busEvent)
        {
            _makeLine.Add(busEvent.OrderId, busEvent.CoffeeType);
            return Task.CompletedTask;
        }
    }
}
