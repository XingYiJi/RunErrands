using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Entity
{
    public class DeleteOrder
    {
        public int OrderID { get; set; }

        public int TakerID { get; set; }
        public string TakeStartDateTime { get; set; }
        public string TakeEndDateTime { get; set; }
        public int State { get; set; }
    }
}
