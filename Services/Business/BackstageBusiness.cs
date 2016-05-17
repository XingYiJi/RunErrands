using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using Services.Data;
using Services.Entity;

namespace Services.Business
{
    /// <summary>
    /// 后台服务
    /// </summary>
    public class BackstageBusiness
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
        /// 得到评论列表
        /// </summary>
        /// <param name="CreaterID"></param>
        /// <returns></returns>
        public List<CommentOrder> QueryComment()
        {
            var query = (from c in HouseAppEntities.CommentOrder
                         where c.Comment!=null
                         select c);
            

            List<CommentOrder> comment = new List<CommentOrder>();
            comment = query.ToList();
            return comment;
        }

        /// <summary>
        /// 得到评论
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetCommentByOrderID(int ID)
        {
            var query = (from c in HouseAppEntities.CommentOrder
                         where c.OrderID == ID
                         select c);
            string comment = query.First().Comment;
            return comment;
 
        }

        /// <summary>
        /// 得到订单
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Order GetOrderByOrderID(int ID)
        {
            var query = (from c in HouseAppEntities.Order
                         where c.OrderID == ID
                         select c);
            Order order = new Order();
            order = query.First();
            return order;
        }

        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<UserMessage> QueryUserByType(int ID)
        {
            var query = (from c in HouseAppEntities.User
                         where c.UserTypeID == ID
                         select new UserMessage
                         {
                             UserID=c.UserID,
                             UserName=c.UserName,
                             Adress=c.Adress,
                             RealName=c.RealName,
                             Phone=c.Phone
                         });
            List<UserMessage> message = new List<UserMessage>();
            message = query.ToList();
            return message;
        }

        /// <summary>
        /// 解封号
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string ModifyUnlock(int ID)
        {
            var query = (from c in HouseAppEntities.User
                         where c.UserID == ID
                         select c);
            query.First().UserTypeID = 2;
            int effect = -1;
            effect = HouseAppEntities.SaveChanges();
            return effect.ToString();
        }

        /// <summary>
        /// 封号
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string ModifyLock(int ID)
        {
            var query = (from c in HouseAppEntities.User
                         where c.UserID == ID
                         select c);
            query.First().UserTypeID = 3;
            int effect = -1;
            effect = HouseAppEntities.SaveChanges();
            return effect.ToString();
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        //public List<UserMessage> SortByType(int ID)
        //{
        //    List<UserMessage> message = new List<UserMessage>();
        //    if (ID == 1)//下单人
        //    {
        //        var query = (from c in HouseAppEntities.DataCount
        //                     group c by c.TakerID into g
        //                     select new { 
        //                     g.Key,
        //                     Num=g.Count()
        //                     }
        //                       );

                

        //         message = query.ToList();
        //    }
        //    if (ID == 2)//下单地址
        //    {
        //        var query = (from c in HouseAppEntities.User
        //                     where c.UserID == ID
        //                     select c);

        //        message = query.ToList();
        //    }
            

            
           
        //    return message;
        //}
    }
}
