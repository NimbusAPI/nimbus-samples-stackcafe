using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using Nimbus;
using Nimbus.Interceptors.Inbound;
using Nimbus.MessageContracts;
using Nimbus.PropertyInjection;

namespace StackCafe.Common.MessageBus.Interceptors
{
    public class CorrelationIdInterceptor : InboundInterceptor, IRequireDispatchContext
    {
        public IDispatchContext DispatchContext { get; set; }

        public override Task OnCommandHandlerExecuting<TBusCommand>(TBusCommand busCommand, NimbusMessage nimbusMessage)
        {
            CallContext.LogicalSetData(nameof(DispatchContext.CorrelationId), DispatchContext.CorrelationId);
            CallContext.LogicalSetData(nameof(DispatchContext.ResultOfMessageId), DispatchContext.ResultOfMessageId);

            return base.OnCommandHandlerExecuting(busCommand, nimbusMessage);
        }

        public override Task OnRequestHandlerExecuting<TBusRequest, TBusResponse>(IBusRequest<TBusRequest, TBusResponse> busRequest, NimbusMessage nimbusMessage)
        {
            CallContext.LogicalSetData(nameof(DispatchContext.CorrelationId), DispatchContext.CorrelationId);
            CallContext.LogicalSetData(nameof(DispatchContext.ResultOfMessageId), DispatchContext.ResultOfMessageId);

            return base.OnRequestHandlerExecuting(busRequest, nimbusMessage);
        }

        public override Task OnEventHandlerExecuting<TBusEvent>(TBusEvent busEvent, NimbusMessage nimbusMessage)
        {
            CallContext.LogicalSetData(nameof(DispatchContext.CorrelationId), DispatchContext.CorrelationId);
            CallContext.LogicalSetData(nameof(DispatchContext.ResultOfMessageId), DispatchContext.ResultOfMessageId);

            return base.OnEventHandlerExecuting(busEvent, nimbusMessage);
        }
    }
}