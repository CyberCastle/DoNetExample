using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoNetExample.Persistence.connection
{
    public class SessionHandlerException : Exception
    {
        public String code { 
            get;
            private set;
        }

        public SessionHandlerException(String message, String code)
            : base(message)
        {
            this.code = code;
        }

        public SessionHandlerException(String message, Exception innerException, String code)
            : base(message, innerException)
        {
            this.code = code;
        }
    }
}
