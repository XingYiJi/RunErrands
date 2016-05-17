using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Entity
{
    public class PlaceOrder
    {
        public int OrderID { get; set; }
        public Nullable<int> CreaterID { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string ProductName { get; set; }
        public string ProductWeight { get; set; }
        public string SenderName { get; set; }
        public string SenderPhone { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverAddress { get; set; }
        public Nullable<int> TakerID { get; set; }
        public DateTime TakeStartDateTime { get; set; }
        public DateTime TakeEndDateTime { get; set; }
        public Nullable<int> State { get; set; }
        public string PointX { get; set; }
        public string PointY { get; set; }
        public string Remarks { get; set; }
        public string PointX2 { get; set; }
        public string PointY2 { get; set; }
        public string Street { get; set; }
    }
}
