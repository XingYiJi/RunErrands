using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Entity
{
    public class TakeOrder
    {
        public int OrderID { get; set; }
        
        public Nullable<int> TakerID { get; set; }
        public DateTime TakeStartDateTime { get; set; }
        public DateTime TakeEndDateTime { get; set; }
        public Nullable<int> State { get; set; }
        
    }
}
