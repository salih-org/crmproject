using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crm.API.Services.Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        

        [HttpGet()]
        public Service.Contact.Data.Models.Contact Get()
        {
            return new Service.Contact.Data.Models.Contact();
        }
    }
}
