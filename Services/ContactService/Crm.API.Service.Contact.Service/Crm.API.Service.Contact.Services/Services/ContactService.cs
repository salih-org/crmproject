using Crm.API.Service.Contact.Data.Context;
using Crm.API.Service.Contact.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crm.API.Service.Contact.Services.Services
{
    public class ContactService : IContactService
    {
        private readonly CrmDbContext context;

        public ContactService(CrmDbContext Context)
        {
            context = Context;
        }

        public Data.Models.Contact GetContactById(int Id)
        {
            return context.Contact.FirstOrDefault(i => i.Id == Id);
        }

        public Data.Models.Contact GetFirstContact()
        {
            return context.Contact.FirstOrDefault();
        }
    }
}
