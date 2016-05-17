using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Entity
{
    /// <summary>
    /// 存放地点的路线
    /// </summary>
    public class PointRoute
    {
        public int OrderID { get; set; }
        public string PointX { get; set; }
        public string PointY { get; set; }
        public string Remarks { get; set; }
        public string PointX2 { get; set; }
        public string PointY2 { get; set; }
    }
}
