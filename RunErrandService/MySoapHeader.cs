using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RunErrandService
{
    public class MySoapHeader : System.Web.Services.Protocols.SoapHeader
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}