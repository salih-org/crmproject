using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crm.API.Service.Reservation.EventBus
{
    public class ContactEventModelConsumer: IConsumer<ContactEventModel>
    {
        private readonly ILogger<ContactEventModelConsumer> logger;

        public ContactEventModelConsumer(ILogger<ContactEventModelConsumer> Logger)
        {
            logger = Logger;
        }

        public Task Consume(ConsumeContext<ContactEventModel> context)
        {
            logger.LogInformation("Data Consumed from test_queue");

            logger.LogInformation($"Consumed Contact is {context.Message.FullName}");

            return Task.CompletedTask;
        }
    }
}
