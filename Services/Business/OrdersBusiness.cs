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
    public class OrdersBusiness
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
        /// 添加订单
        /// </summary>
        /// <param name="OrderData"></param>
        /// <returns></returns>
        public int AddOrders(PlaceOrder OrderData)
        {
            Order order = new Order();
            //var query = (from c in HouseAppEntities.Order
            //             orderby c.UserID descending
            //             select c);
            //u1.UserID = query.First<User>().UserID + 1;
            //order.OrderID ;
            order.CreaterID = OrderData.CreaterID ;
            order.CreateDateTime = DateTime.Now;
            order.ProductName = OrderData.ProductName;
            order.ProductWeight = OrderData.ProductWeight;
            order.Remarks = OrderData.Remarks;
            order.SenderName = OrderData.SenderName;
            order.SenderPhone = OrderData.SenderPhone;
            order.SenderAddress = OrderData.SenderAddress;
            order.ReceiverName = OrderData.ReceiverName;
            order.ReceiverPhone = OrderData.ReceiverPhone;
            order.ReceiverAddress = OrderData.ReceiverAddress;
            order.State = 0;                                   //刚下单，状态为"0"
            order.PointX = OrderData.PointX;
            order.PointY = OrderData.PointY;
            order.PointX2 = OrderData.PointX2;
            order.PointY2 = OrderData.PointY2;
            order.Street = OrderData.Street;

            HouseAppEntities.Order.Add(order);
            int effect = -1;
            effect = HouseAppEntities.SaveChanges();
            return effect;
        }

        /// <summary>
        /// 查询未完成的订单
        /// </summary>
        /// <param name="CreaterID"></param>
        /// <returns></returns>
        public List<UncompleteOrder> QueryUncompleteOrder(int CreaterID)
        {
            var query = (from c in HouseAppEntities.Order
                         where c.CreaterID == CreaterID
                         && c.State == 0
                         select new  
                         {
                            OrderID =c.OrderID,
                            CreateDateTime =c.CreateDateTime,
                            ProductName = c.ProductName,
                            ProductWeight = c.ProductWeight,
                            SenderAddress = c.SenderAddress,
                            ReceiverAddress = c.ReceiverAddress,
                            //TakerID=0,
                            //TakerName="",
                            //TakeStartDateTime="",
                         });
            var result = query.AsEnumerable().Select(p => new UncompleteOrder()
            {
                OrderID = p.OrderID,
                CreateDateTime = p.CreateDateTime.ToString(),
                ProductName = p.ProductName,
                ProductWeight = p.ProductWeight,
                SenderAddress = p.SenderAddress,
                ReceiverAddress = p.ReceiverAddress,
                //TaskEnd = p.TaskEnd.ToString("yyyy-MM-dd"),
                //Submited = p.Submited.HasValue ? p.Submited.Value.ToString("yyyy-MM-dd") : ("0000-00-00"),
                
            });

            List<UncompleteOrder> Uncom = new List<UncompleteOrder>();
            Uncom = result.ToList();
            return Uncom;
        }

        /// <summary>
        /// 查询已经下单并且被接单的订单
        /// </summary>
        /// <param name="CreaterID"></param>
        /// <returns></returns>
        public List<UncompleteOrder> QueryUncompleteOrder2(int CreaterID)
        {
            var query = (from c in HouseAppEntities.Order
                         join p in HouseAppEntities.User
                         on c.TakerID equals p.UserID
                         where c.CreaterID == CreaterID
                         && c.State == 1
                         select new
                         {
                             OrderID = c.OrderID,
                             CreateDateTime = c.CreateDateTime,
                             ProductName = c.ProductName,
                             ProductWeight = c.ProductWeight,
                             SenderAddress = c.SenderAddress,
                             ReceiverAddress = c.ReceiverAddress,
                             TakerName=p.UserName,
                             TakeStartDateTime=c.TakeStartDateTime,
                         });
            var result = query.AsEnumerable().Select(p => new UncompleteOrder()
            {
                OrderID = p.OrderID,
                CreateDateTime = p.CreateDateTime.ToString(),
                ProductName = p.ProductName,
                ProductWeight = p.ProductWeight,
                SenderAddress = p.SenderAddress,
                ReceiverAddress = p.ReceiverAddress,
                TakerName = p.TakerName,
                TakeStartDateTime = p.TakeStartDateTime.ToString(),
            });

            List<UncompleteOrder> Uncom = new List<UncompleteOrder>();
            Uncom = result.ToList();
            return Uncom;
        }

        /// <summary>
        /// 查询用户已经下单并且被接单的订单
        /// </summary>
        /// <param name="CreaterID"></param>
        /// <returns></returns>
        public List<CompleteOrder> QueryCompleteOrder(int CreaterID)
        {
            var query = (from c in HouseAppEntities.Order
                         join p in HouseAppEntities.User
                         on c.TakerID equals p.UserID
                         where c.CreaterID == CreaterID
                         && c.State == 2
                         select new
                         {
                             OrderID = c.OrderID,
                             CreateDateTime = c.CreateDateTime,
                             ProductName = c.ProductName,
                             ProductWeight = c.ProductWeight,
                             SenderAddress = c.SenderAddress,
                             ReceiverAddress = c.ReceiverAddress,
                             TakerName = p.UserName,
                             TakeStartDateTime = c.TakeStartDateTime,
                             TakeEndDateTime = c.TakeEndDateTime,
                         });
            var result = query.AsEnumerable().Select(p => new CompleteOrder()
            {
                OrderID = p.OrderID,
                CreateDateTime = p.CreateDateTime.ToString(),
                ProductName = p.ProductName,
                ProductWeight = p.ProductWeight,
                SenderAddress = p.SenderAddress,
                ReceiverAddress = p.ReceiverAddress,
                TakerName = p.TakerName,
                TakeStartDateTime = p.TakeStartDateTime.ToString(),
                TakeEndDateTime = p.TakeEndDateTime.ToString(),
            });

            List<CompleteOrder> Com = new List<CompleteOrder>();
            Com = result.ToList();
            return Com;
        }

        /// <summary>
        /// 用户删除未有人接受的订单,只需传递OrderID
        /// </summary>
        /// <param name="CreaterID"></param>
        /// <returns></returns>
        public int DeleteUnTakedOrder(int OrderID)
        {
            var query = (from c in HouseAppEntities.Order
                         where c.OrderID == OrderID
                         select c);
            query.First().State = 3;
            int effect = -1;
            effect = HouseAppEntities.SaveChanges();
            return effect; 
        }

        public int InsertComment(CommentOrder Order)
        {
            var query = (from c in HouseAppEntities.CommentOrder
                         where c.OrderID == Order.OrderID
                         select c);
            query.First().Comment = Order.Comment;
            int effect = -1;
            effect = HouseAppEntities.SaveChanges();
            return effect;
        }
    }
}
