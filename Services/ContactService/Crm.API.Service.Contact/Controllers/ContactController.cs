using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        [HttpGet()]
        public Service.Contact.Data.Models.Contact Get()
        {
            return contactService.GetFirstContact();
        }

        [HttpGet("{id}")]
        public Service.Contact.Data.Models.Contact Get(int id)
        {
            return contactService.GetContactById(id);
        }
    }
}
