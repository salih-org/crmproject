using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm.API.Service.Contact.Results;
using Crm.API.Service.Contact.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crm.API.Services.Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactController(IContactService ContactService)
        {
            contactService = ContactService;
        }

        [HttpPost]
        public async Task<Result<Service.Contact.Data.Models.Contact>> Create(Service.Contact.Data.Models.Contact Contact)
        {
            return new Result<Service.Contact.Data.Models.Contact>()
            {
                Value = await contactService.CreateContact(Contact)
            };
        }

        [HttpGet()]
        public async Task<Result<Service.Contact.Data.Models.Contact>> Get()
        {
            return new Result<Service.Contact.Data.Models.Contact>()
            {
                Value = await contactService.GetFirstContact()
            };
        }

        [HttpGet("{id}")]
        public async Task<Result<Service.Contact.Data.Models.Contact>> Get(int id)
        {
            return new Result<Service.Contact.Data.Models.Contact>()
            {
                Value = await contactService.GetContactById(id)
            };
        }
    }
}
