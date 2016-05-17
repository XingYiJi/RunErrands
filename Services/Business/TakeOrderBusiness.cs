using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using Services.Data;
using Services.Entity;

namespace Services.Business
{
    public class TakeOrderBusiness
    {
        #region Context
        /// <summary>
        /// 防止UserDBEntities没有创建
        /// </summary>
        /// 
        private Entities houseAppEntities;        // UserDBEntities IBusinessService.HouseDAContext
        Entities HouseAppEntities
        {
            set
            {
                houseAppEntities = value;
            }
            get
            {
                if (houseAppEntities == null)
                {
                    houseAppEntities = new Entities();
                }
                return houseAppEntities;
            }
        }
        #endregion

        /// <summary>
        /// 查询状态符合的起始点，“0”，“1”，“2”，“3”
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public List<PointShow> QueryMapPoint1(int i)
        {
            var query = (from t in HouseAppEntities.Order
                         where t.State == i
                         select new PointShow
                         {
                             OrderID = t.OrderID,
                             ProductName = t.ProductName,
                             ProductWeight = t.ProductWeight,
                             pointx = t.PointX,
                             pointy = t.PointY,
                             pointx2 = t.PointX2,
                             pointy2 = t.PointY2,
                             Message = t.Remarks,
                             Address = t.SenderAddress,
                             Destination = t.ReceiverAddress,
                         });
            List<PointShow> pointshow = new List<PointShow>();
            pointshow = query.ToList();
            return pointshow;
        }

        /// <summary>
        /// 接受订单
        /// </summary>
        /// <returns></returns>
        public int AcceptOrder(TakeOrder takeorder)
        {
            var query = (from t in HouseAppEntities.Order
                         where t.OrderID == takeorder.OrderID
                         select t);
            query.First().TakerID = takeorder.TakerID;
            query.First().TakeStartDateTime = DateTime.Now;
            query.First().State = 1;
            int effect=-1;
            effect = HouseAppEntities.SaveChanges();
            return effect; 
        }

        /// <summary>
        /// 查询已下的，且已经接受去配送的单
        /// </summary>
        /// <param name="CreaterID"></param>
        /// <returns></returns>
        public List<UnCompleteTakedOrder> QueryUncompleteTakedOrder(int TakerID)
        {
            var query = (from c in HouseAppEntities.Order
                         where c.TakerID == TakerID
                         && c.State == 1
                         select new
                         {
                             OrderID = c.OrderID,
                             CreateDateTime = c.CreateDateTime,
                             ProductName = c.ProductName,
                             ProductWeight = c.ProductWeight,
                             SenderName = c.SenderName,
                             SenderPhone = c.SenderPhone,
                             SenderAddress = c.SenderAddress,
                             ReceiverName = c.ReceiverName,
                             ReceiverPhone = c.ReceiverPhone,
                             ReceiverAddress = c.ReceiverAddress,
                             TakeStartDateTime = c.TakeStartDateTime,
                             Remarks = c.Remarks
                         });
            var result = query.AsEnumerable().Select(c => new UnCompleteTakedOrder()
            {
                OrderID = c.OrderID,
                CreateDateTime = c.CreateDateTime.ToString(),
                ProductName = c.ProductName,
                ProductWeight = c.ProductWeight,
                SenderName = c.SenderName,
                SenderPhone = c.SenderPhone,
                SenderAddress = c.SenderAddress,
                ReceiverName = c.ReceiverName,
                ReceiverPhone = c.ReceiverPhone,
                ReceiverAddress = c.ReceiverAddress,
                TakeStartDateTime = c.TakeStartDateTime.ToString(),
                Remarks = c.Remarks
            });

            List<UnCompleteTakedOrder> Uncom = new List<UnCompleteTakedOrder>();
            Uncom = result.ToList();
            return Uncom;
        }

        /// <summary>
        /// 查询已经接收的，并已经送达的订单
        /// </summary>
        /// <param name="TakerID"></param>
        /// <returns></returns>
        public List<CompleteTakedOrder> QueryCompleteTakedOrder(int TakerID)
        {
            var query = (from c in HouseAppEntities.Order
                         where c.TakerID == TakerID
                         && c.State == 2
                         select new
                         {
                             OrderID = c.OrderID,
                             CreateDateTime = c.CreateDateTime,
                             ProductName = c.ProductName,
                             ProductWeight = c.ProductWeight,
                             SenderName = c.SenderName,
                             SenderPhone = c.SenderPhone,
                             SenderAddress = c.SenderAddress,
                             ReceiverName = c.ReceiverName,
                             ReceiverPhone = c.ReceiverPhone,
                             ReceiverAddress = c.ReceiverAddress,
                             TakeStartDateTime = c.TakeStartDateTime,
                             TakeEndDateTime = c.TakeEndDateTime,
                             Remarks = c.Remarks
                         });
            var result = query.AsEnumerable().Select(c => new CompleteTakedOrder()
            {
                OrderID = c.OrderID,
                CreateDateTime = c.CreateDateTime.ToString(),
                ProductName = c.ProductName,
                ProductWeight = c.ProductWeight,
                SenderName = c.SenderName,
                SenderPhone = c.SenderPhone,
                SenderAddress = c.SenderAddress,
                ReceiverName = c.ReceiverName,
                ReceiverPhone = c.ReceiverPhone,
                ReceiverAddress = c.ReceiverAddress,
                TakeStartDateTime = c.TakeStartDateTime.ToString(),
                TakeEndDateTime = c.TakeEndDateTime.ToString(),
                Remarks = c.Remarks
            });

            List<CompleteTakedOrder> Com = new List<CompleteTakedOrder>();
            Com = result.ToList();
            return Com;
        }

        /// <summary>
        /// 接单人退回订单
        /// </summary>
        /// <param name="takeorder"></param>
        /// <returns></returns>
        public int BackOrder(int OrderID)
        {
            var query = (from t in HouseAppEntities.Order
                         where t.OrderID == OrderID
                         select t);
            
            query.First().State = 0;
            int effect = -1;
            effect = HouseAppEntities.SaveChanges();
            return effect;
        }

        /// <summary>
        /// 完成订单
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public int CompleteOrder(int OrderID)
        {
            var query = (from t in HouseAppEntities.Order
                         where t.OrderID == OrderID
                         select t);
            int effect = -1;
            query.First().State = 2;
            query.First().TakeEndDateTime = DateTime.Now;

            DataCount dataCount = new DataCount();
            dataCount.OrderID = query.First().OrderID;
            dataCount.CreaterID = query.First().CreaterID;
            dataCount.TakerID = query.First().TakerID;
            dataCount.Street = query.First().Street;
            HouseAppEntities.DataCount.Add(dataCount);

            CommentOrder comment = new CommentOrder();
            comment.OrderID = query.First().OrderID;
            comment.CreaterID = query.First().CreaterID;
            comment.TakerID = query.First().TakerID;
            HouseAppEntities.CommentOrder.Add(comment);

           
            effect = HouseAppEntities.SaveChanges();
            return effect;
        }

        /// <summary>
        /// 查询订单的两个点的坐标
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public PointRoute QueryMapPoint(int i)
        {
            var query = (from t in HouseAppEntities.Order
                         where t.OrderID == i
                         select new PointRoute
                         {
                             OrderID = t.OrderID,
                             PointX = t.PointX,
                             PointY = t.PointY,
                             PointX2 = t.PointX2,
                             PointY2 = t.PointY2                            
                         });
            PointRoute route = new PointRoute();
            route = query.First();
            return route;
        }
    }
}
