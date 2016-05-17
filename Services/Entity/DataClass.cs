using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Runtime.Serialization;

namespace Services.Entity
{
    public class DataClass
    {
        [DataContract]
        public class BehaviourInfo
        {
            [DataMember(Order = 0)]
            public string Behaviour { get; set; }
            [DataMember(Order = 1)]
            public int Lev1 { get; set; }
            [DataMember(Order = 2)]
            public int Lev2 { get; set; }
            [DataMember(Order = 3)]
            public bool IsAuto { get; set; }
        }

        [DataContract]
        public class User
        {
            [DataMember(Order = 0)]
            public string Name { get; set; }
            [DataMember(Order = 1)]
            public string Address { get; set; }
            [DataMember(Order = 2)]
            public string Sex { get; set; }
        }
    }
}
