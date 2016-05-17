using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Entity
{
    public class CompleteOrder
    {
        public int OrderID { get; set; }
        public string CreateDateTime { get; set; }
        public string ProductName { get; set; }
        public string ProductWeight { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverAddress { get; set; }
        
        public string TakerName { get; set; }
        public string TakeStartDateTime { get; set; }
        public string TakeEndDateTime { get; set; }
    }
}
