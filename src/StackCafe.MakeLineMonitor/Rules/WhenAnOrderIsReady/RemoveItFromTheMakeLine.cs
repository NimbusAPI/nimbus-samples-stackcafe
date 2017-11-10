using System.Threading.Tasks;
using Nimbus.Handlers;
using StackCafe.MakeLineMonitor.Services;
using StackCafe.MessageContracts.Events;

namespace StackCafe.MakeLineMonitor.Rules.WhenAnOrderIsReady
{
    public class RemoveItFromTheMakeLine : IHandleMulticastEvent<OrderIsReadyEvent>
    {
        readonly IMakeLineService _makeLine;

        public RemoveItFromTheMakeLine(IMakeLineService makeLine)
        {
            _makeLine = makeLine;
        }

        public Task Handle(OrderIsReadyEvent busEvent)
        {
            _makeLine.Remove(busEvent.OrderId);
            return Task.CompletedTask;
        }
    }
}
