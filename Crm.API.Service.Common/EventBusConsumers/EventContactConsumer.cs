using Crm.API.Service.Common.EventBusModels.ContactServiceModels;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.API.Service.Common.EventBusConsumers
{
    public class EventContactConsumer : IConsumer<EventContact>
    {
        private readonly ILogger<EventContactConsumer> logger;

        public EventContactConsumer(ILogger<EventContactConsumer> Logger)
        {
            logger = Logger;
        }

        public Task Consume(ConsumeContext<EventContact> context)
        {
            logger.LogInformation("Data Consumed from test_queue");

            logger.LogInformation($"Consumed Contact is {context.Message.FullName}");

            return Task.CompletedTask;
        }
    }
}
