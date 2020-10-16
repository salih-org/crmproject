using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Crm.API.Service.Contact.Data.Models;

namespace Crm.API.Service.Contact.Services.Interfaces
{
    public interface IContactService
    {
        Task<Data.Models.Contact> GetContactById(int Id);

        Task<Data.Models.Contact> GetFirstContact();

        Task<Data.Models.Contact> CreateContact(Data.Models.Contact Contact);
    }
}
