using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crm.API.Service.Contact.Results
{
    public class Result<T>: BaseResult
    {
        public T Value { get; set; }
    }
}
