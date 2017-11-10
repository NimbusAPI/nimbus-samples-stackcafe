using System;
using System.Runtime.Remoting.Messaging;
using Serilog.Core;
using Serilog.Events;

namespace StackCafe.Common.Logging.Enrichers
{
    public class CorrelationIdEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var correlationId = CallContext.LogicalGetData("CorrelationId") as Guid?;
            var resultOfMessageId = CallContext.LogicalGetData("ResultOfMessageId") as Guid?;

            logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("CorrelationId", correlationId));
            logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("ResultOfMessageId", resultOfMessageId));
        }
    }
}