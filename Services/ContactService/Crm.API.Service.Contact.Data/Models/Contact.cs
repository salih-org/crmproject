using System;
using System.Collections.Generic;

namespace Crm.API.Service.Contact.Data.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
