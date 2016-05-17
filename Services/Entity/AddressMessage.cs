using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Entity
{
    public class AddressMessage
    {
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
    }
}
