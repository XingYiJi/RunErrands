using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.Services;
using Services;
using Services.Business;
using Services.Common;
using Services.Data;
using Services.Entity;

namespace RunErrandService
{
    /// <summary>
    /// RunService 的摘要说明 http://localhost:33660/RunService.asmx
    /// </summary>
    [WebService(Namespace = "http://www.ewide.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class RunService : System.Web.Services.WebService
    {
        public MySoapHeader myHeader;

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [WebMethod]
        public string UserLogin(string userData)
        {
            //声明变量
            UserRoleID myUser;
            //执行反序列化 part:2
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            Userlogin _Personnel = jsonSerializer.Deserialize<Userlogin>(userData);

            /////打包成json格式发送：part：3
            Result back = new Result();

            ////////////////////数据调用
            UserBusiness userbusiness = new UserBusiness();
            myUser = userbusiness.GetUserByUserName(_Personnel.UserName);
            if (myUser != null && myUser.PassWord == FormsAuthentication.HashPasswordForStoringInConfigFile(_Personnel.Password, "SHA1"))
            {
                back.resutl = myUser.UserID.ToString();
                back.UserID = myUser.UserID;
                back.UserName = myUser.UserName;
                back.Ps = _Personnel.Password;
                back.UserType = myUser.UserType;
            }
            else
            {
                back.resutl = "0";

            }
            string loginMessage = jsonSerializer.Serialize(back);
            return loginMessage;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [WebMethod]
        public string UserRegister(string userData)
        {
            User user1 = new User();
            //执行反序列化 part:2
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            UserRoleID Personne = jsonSerializer.Deserialize<UserRoleID>(userData);

            /////打包成json格式发送：part：3
            Result back = new Result();

            ////////////////////数据调用
            UserBusiness userbusiness = new UserBusiness();

            if (userbusiness.CheckDuplicatName(Personne.UserName) != 1)
            {                
                Personne.PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(Personne.PassWord, "SHA1");
                back.RegisterMessage = userbusiness.RegisterNewUser(Personne);
            }
            else
            {
                back.RegisterMessage = 2;
            }
            return jsonSerializer.Serialize(back.RegisterMessage);
        }


        /// <summary>
        /// 用户下单
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string UserPlaceOrder(string userData)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            PlaceOrder placeOrder = jsonSerializer.Deserialize<PlaceOrder>(userData);

            OrdersBusiness orderBusiness = new OrdersBusiness();

            WebService ws = new WebService();
            string result;
            int state;
            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                state = orderBusiness.AddOrders(placeOrder);
                if (state != -1)
                {
                    result = "1";//下单成功
                }
                else
                {
                    result = "0";
                }
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }
            return jsonSerializer.Serialize(result);
        }


        /// <summary>
        /// 查询已下的，却没有人接受的订单
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string SearchUnCompleteOrder(string userData)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string state = jsonSerializer.Deserialize<string>(userData);
            int id = Convert.ToInt32(state);

            List<UncompleteOrder> unorder = new List<UncompleteOrder>();
            OrdersBusiness orderBusiness = new OrdersBusiness();
            WebService ws = new WebService();

            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                unorder = orderBusiness.QueryUncompleteOrder(id);

                return jsonSerializer.Serialize(unorder);
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }

        }

        /// <summary>
        /// 查询已经下单并且被接单的订单
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string SearchUnCompleteOrder2(string userData)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string state = jsonSerializer.Deserialize<string>(userData);
            int id = Convert.ToInt32(state);

            List<UncompleteOrder> unorder = new List<UncompleteOrder>();
            OrdersBusiness orderBusiness = new OrdersBusiness();
            WebService ws = new WebService();

            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                unorder = orderBusiness.QueryUncompleteOrder2(id);

                return jsonSerializer.Serialize(unorder);
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }

        }

        /// <summary>
        /// 查询用户所有订单中，已经被完成的订单
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string SearchCompleteOrder(string userData)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string state = jsonSerializer.Deserialize<string>(userData);
            int id = Convert.ToInt32(state);

            List<CompleteOrder> unorder = new List<CompleteOrder>();
            OrdersBusiness orderBusiness = new OrdersBusiness();
            WebService ws = new WebService();

            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                unorder = orderBusiness.QueryCompleteOrder(id);

                return jsonSerializer.Serialize(unorder);
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }

        }

        /// <summary>
        /// 用户删除未有人接受的订单
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string DeleteUnTakedOrder(string userData)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            DeleteOrder takeorder = jsonSerializer.Deserialize<DeleteOrder>(userData);

            OrdersBusiness orderbusiness = new OrdersBusiness();

            WebService ws = new WebService();
            string result;
            int state;
            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                state = orderbusiness.DeleteUnTakedOrder(takeorder.OrderID);
                if (state != -1)
                {
                    result = "0";//下单成功
                }
                else
                {
                    result = "1";
                }
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }
            return jsonSerializer.Serialize(result);

        }

        /// <summary>
        /// 增加评论
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string AddComment(string userData)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            CommentOrder comment = jsonSerializer.Deserialize<CommentOrder>(userData);

            OrdersBusiness orderbusiness = new OrdersBusiness();

            WebService ws = new WebService();
            string result;
            int state;
            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                state = orderbusiness.InsertComment(comment);
                if (state != -1)
                {
                    result = "0"; //增加评论
                }
                else
                {
                    result = "1";
                }
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }
            return jsonSerializer.Serialize(result);

        }

        //***************************************************************************************************//

        /// <summary>
        /// 查询地图上的点
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string SearchMapPoint(string userData)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string state = jsonSerializer.Deserialize<string>(userData);
            List<PointShow> pointshow = new List<PointShow>();
            TakeOrderBusiness TakeBusiness = new TakeOrderBusiness();

            WebService ws = new WebService();
            
            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                if (state == "0")
                {
                    pointshow = TakeBusiness.QueryMapPoint1(0);
                }                
                return jsonSerializer.Serialize(pointshow);
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }
            
        }

        /// <summary>
        /// 用户接单
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string UserTakeOrder(string userData)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            TakeOrder takeorder = jsonSerializer.Deserialize<TakeOrder>(userData);

            TakeOrderBusiness TakeBusiness = new TakeOrderBusiness();

            WebService ws = new WebService();
            string result;
            int state;
            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                state = TakeBusiness.AcceptOrder(takeorder);
                if (state != -1)
                {
                    result = "0";//下单成功
                }
                else
                {
                    result = "1";
                }
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }
            return jsonSerializer.Serialize(result);
        }

        /// <summary>
        /// 查询已下的，且已经接受去配送的单
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string SearchUnCompleteTakedOrder(string userData)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string state = jsonSerializer.Deserialize<string>(userData);
            int id = Convert.ToInt32(state);

            List<UnCompleteTakedOrder> unorder = new List<UnCompleteTakedOrder>();
            TakeOrderBusiness TakeBusiness = new TakeOrderBusiness();
            WebService ws = new WebService();

            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                unorder = TakeBusiness.QueryUncompleteTakedOrder(id);

                return jsonSerializer.Serialize(unorder);
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }

        }

        /// <summary>
        /// 查询已经接收的，并已经送达的订单
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string SearchCompleteTakedOrder(string userData)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string state = jsonSerializer.Deserialize<string>(userData);
            int id = Convert.ToInt32(state);

            List<CompleteTakedOrder> order = new List<CompleteTakedOrder>();
            TakeOrderBusiness TakeBusiness = new TakeOrderBusiness();
            WebService ws = new WebService();

            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                order = TakeBusiness.QueryCompleteTakedOrder(id);

                return jsonSerializer.Serialize(order);
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }

        }

        /// <summary>
        /// 接单人退回订单,不再配送，只需orderid参数
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string BackTakedOrder(string userData)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            TakeOrder takeorder = jsonSerializer.Deserialize<TakeOrder>(userData);

            TakeOrderBusiness TakeBusiness = new TakeOrderBusiness();

            WebService ws = new WebService();
            string result;
            int state;
            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                state = TakeBusiness.BackOrder(takeorder.OrderID);
                if (state != -1)
                {
                    result = "0";//下单成功
                }
                else
                {
                    result = "1";
                }
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }
            return jsonSerializer.Serialize(result);
        }

        /// <summary>
        /// 接单人完成自己所接的订单
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string completeTakedOrder(string userData)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            TakeOrder takeorder = jsonSerializer.Deserialize<TakeOrder>(userData);

            TakeOrderBusiness TakeBusiness = new TakeOrderBusiness();

            WebService ws = new WebService();
            string result;
            int state;
            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                state = TakeBusiness.CompleteOrder(takeorder.OrderID);
                if (state != -1)
                {
                    result = "0";//下单成功
                }
                else
                {
                    result = "1";
                }
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }
            return jsonSerializer.Serialize(result);
        }

        /// <summary>
        /// 获得订单的出发点和到达点的坐标
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string GetPointRoute(string userData)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            int OrderID = jsonSerializer.Deserialize<int>(userData);

            TakeOrderBusiness TakeBusiness = new TakeOrderBusiness();

            WebService ws = new WebService();
            PointRoute pointRoute = new PointRoute();
            
            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                pointRoute = TakeBusiness.QueryMapPoint(OrderID);
                
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }
            return jsonSerializer.Serialize(pointRoute);
        }

        //***************************************************************************************************//
        //后台接口服务

        /// <summary>
        /// 得到评论列表
        /// </summary>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string SearchComment()
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            BackstageBusiness backstage = new BackstageBusiness();

            WebService ws = new WebService();
            List<CommentOrder> comment = new List<CommentOrder>();

            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                comment = backstage.QueryComment();
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }
            return jsonSerializer.Serialize(comment);
        }

        /// <summary>
        /// 得到评论
        /// </summary>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string GetComment(string userData)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            int orderID = jsonSerializer.Deserialize<int>(userData);

            BackstageBusiness backstage = new BackstageBusiness();

            WebService ws = new WebService();
            string comment = null;

            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                comment = backstage.GetCommentByOrderID(orderID);
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }
            return jsonSerializer.Serialize(comment);
        }

        /// <summary>
        /// 得到订单
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string GetOrder(string userData)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            int orderID = jsonSerializer.Deserialize<int>(userData);

            BackstageBusiness backstage = new BackstageBusiness();

            WebService ws = new WebService();
            Order order = new Order();

            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                order = backstage.GetOrderByOrderID(orderID);
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }
            return jsonSerializer.Serialize(order);
        }

        /// <summary>
        /// 修改普通用户的权限
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string ModifyUserType(string userData)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            UserQuest quest = jsonSerializer.Deserialize<UserQuest>(userData);

            BackstageBusiness backstage = new BackstageBusiness();

            WebService ws = new WebService();
            string result = null;

            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                if (quest.state == 3)//解封号
                {
                    result = backstage.ModifyUnlock(quest.UserID);
                }
                if (quest.state == 2)//封号
                {
                    result = backstage.ModifyLock(quest.UserID);
                }
                
                
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }
            return jsonSerializer.Serialize(result);
        }

        /// <summary>
        /// 查询不同类型的用户
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string SearchUserByType(string userData)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            int quest = jsonSerializer.Deserialize<int>(userData);

            BackstageBusiness backstage = new BackstageBusiness();

            WebService ws = new WebService();
            List<UserMessage> message = new List<UserMessage>();

            if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
            {
                message = backstage.QueryUserByType(quest);
            }
            else
            {
                return jsonSerializer.Serialize("loginfalse");
            }
            return jsonSerializer.Serialize(message);
        }

        /// <summary>
        /// 挑选出想要的排序
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        //[System.Web.Services.Protocols.SoapHeader("myHeader")]
        //[WebMethod]
        //public string SortBy(string userData)
        //{
        //    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
        //    int quest = jsonSerializer.Deserialize<int>(userData);

        //    BackstageBusiness backstage = new BackstageBusiness();

        //    WebService ws = new WebService();
        //    List<UserMessage> message = new List<UserMessage>();

        //    if (myHeader != null && ws.VerifyUser(myHeader.UserName, myHeader.Password))
        //    {
        //        message = backstage.SortByType(quest);
        //    }
        //    else
        //    {
        //        return jsonSerializer.Serialize("loginfalse");
        //    }
        //    return jsonSerializer.Serialize(message);
        //}
    }
}
