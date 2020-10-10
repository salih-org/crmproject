using System;
using System.Collections.Generic;
using System.Text;
using Crm.API.Service.Contact.Data.Models;

namespace Crm.API.Service.Contact.Services.Interfaces
{
    public interface IContactService
    {
        Data.Models.Contact GetContactById(int Id);

        Data.Models.Contact GetFirstContact();
    }
}
