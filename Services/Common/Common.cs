using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Common
{
    public class Common
    {
    }

    public class ServiceResponse<T>
    {
        public T Entity { get; set; }
        public enumResponseStatus Status { get; set; }
        public string Message { get; set; }
        public Exception Exp { get; set; }
    }

    public enum enumResponseStatus
    {

        isFailure,
        isOK
    }
}
