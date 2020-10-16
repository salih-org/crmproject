using Crm.API.Service.Contact.Data.Context;
using Crm.API.Service.Contact.Services.Interfaces;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.API.Service.Contact.Services.Services
{
    public class ContactService : IContactService
    {
        private readonly CrmDbContext context;
        private readonly IBusControl bus;
        private readonly ILogger<ContactService> logger;

        public ContactService(CrmDbContext Context, IBusControl Bus, ILogger<ContactService> Logger)
        {
            context = Context;
            bus = Bus;
            logger = Logger;
        }

        public async Task<Data.Models.Contact> GetContactById(int Id)
        {
            return await context.Contact.FirstOrDefaultAsync(i => i.Id == Id);
        }

        public async Task<Data.Models.Contact> GetFirstContact()
        {
            return await context.Contact.FirstOrDefaultAsync();
        }

        public async Task<Data.Models.Contact> CreateContact(Data.Models.Contact Contact)
        {
            logger.LogInformation("Contact Create initialization");

            context.Contact.Add(Contact);
            await context.SaveChangesAsync();

            logger.LogInformation("Contact Created");

            Uri u = new Uri("rabbitmq://s_rabbitmq/test_queue");

            var endPoint = await bus.GetSendEndpoint(u);
            await endPoint.Send(Contact);

            logger.LogInformation("Event Send");

            return Contact;
        }
    }
}
