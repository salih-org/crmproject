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
        public async Task<Result<Service.Contact.Data.Models.Contact>> Create()
        {
            return new Result<Service.Contact.Data.Models.Contact>()
            {
                Value = await contactService.GetFirstContact()
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
