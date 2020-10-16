using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crm.API.Service.Contact.Results
{
    public abstract class BaseResult
    {
        public BaseResult()
        {
            Success = true;
        }

        public virtual Guid Guid { get; set; }

        public virtual bool Success { get; set; }

        public virtual String Message { get; set; }

        public virtual void SetException(Exception Ex)
        {
            Success = false;
            Message = Ex.Message;
        }
    }
}
