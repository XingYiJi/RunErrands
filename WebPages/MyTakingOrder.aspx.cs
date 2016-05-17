using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;
using Services.Entity;
using WebPages.RunServiceReference;

namespace WebPages
{
    public partial class MyTakingOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView1.Rows[index];
                TableCell contactName = selectedRow.Cells[0];
                string contact = contactName.Text;
                int orderid = Convert.ToInt32(contact);

                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

                //调用服务  
                RunServiceSoapClient testService = new RunServiceSoapClient();
                //接受json格式的字符串，反序列化
                WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
                soapHeader.UserName = Session["userName"].ToString();
                soapHeader.Password = Session["PS"].ToString();

                Services.Entity.TakeOrder takeOrder = new Services.Entity.TakeOrder();
                takeOrder.OrderID = orderid;
                takeOrder.TakerID = Convert.ToInt32(Session["ID"].ToString());

                string jsonstr = jsonSerializer.Serialize(takeOrder);
                string result = testService.BackTakedOrder(soapHeader, jsonstr);
                string result2 = jsonSerializer.Deserialize<string>(result);


                if (result2 == "0")//退单成功
                {
                    Response.Redirect(Request.Url.ToString()); //刷新页面
                }
                else               //退单失败
                {
                    this.Page.RegisterStartupScript(" ", "<script>alert(' 退单失败 '); </script> ");
                }
            }
            if (e.CommandName == "Choose")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView1.Rows[index];
                TableCell contactName = selectedRow.Cells[0];
                string contact = contactName.Text;
                int orderid = Convert.ToInt32(contact);

                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

                //调用服务  
                RunServiceSoapClient testService = new RunServiceSoapClient();
                //接受json格式的字符串，反序列化
                WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
                soapHeader.UserName = Session["userName"].ToString();
                soapHeader.Password = Session["PS"].ToString();

                Services.Entity.TakeOrder takeOrder = new Services.Entity.TakeOrder();
                takeOrder.OrderID = orderid;
                takeOrder.TakerID = Convert.ToInt32(Session["ID"].ToString());

                string jsonstr = jsonSerializer.Serialize(takeOrder);
                string result = testService.completeTakedOrder(soapHeader, jsonstr);
                string result2 = jsonSerializer.Deserialize<string>(result);


                if (result2 == "0")//下单成功
                {
                    Response.Redirect(Request.Url.ToString()); //刷新页面
                }
                else               //下单失败
                {
                    this.Page.RegisterStartupScript(" ", "<script>alert(' 确认完成失败 '); </script> ");
                }
 
            }
            if (e.CommandName == "Show")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView1.Rows[index];
                TableCell contactName = selectedRow.Cells[0];
                string contact = contactName.Text;
                int orderid = Convert.ToInt32(contact);

                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

                //调用服务  
                RunServiceSoapClient testService = new RunServiceSoapClient();
                //接受json格式的字符串，反序列化
                WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
                soapHeader.UserName = Session["userName"].ToString();
                soapHeader.Password = Session["PS"].ToString();


                string jsonstr = jsonSerializer.Serialize(orderid);
                string result = testService.GetPointRoute(soapHeader, jsonstr);
                PointRoute route = jsonSerializer.Deserialize<PointRoute>(result);
                //http://api.map.baidu.com/direction?origin=latlng:34.264642646862,108.95108518068|name:
                //我家&destination=大雁塔&mode=transit&region=西安&output=html
                //http://api.map.baidu.com/direction/v1?mode=driving&origin=清华大学&destination=北京大学&origin_region=北京&
                //destination_region=北京&output=json&ak=E4805d16520de693a3fe707cdc962045
                string str0 = "http://api.map.baidu.com/direction?origin=latlng:";
                string str1 = route.PointX +","+ route.PointY;
                string str2 = "|起点&destination=latlng:";
                string str3 = route.PointX2 + "," + route.PointY2;
                string str4 = "|终点&mode=walking&region=宁波&output=html";
                string str = str0 + str1 + str2 + str3 + str4;

                Response.Write("<script>window.open('" + str + "','_blank')</script>");

                //Response.Redirect(str,true);
                
            }
        }
    }
    public class GridViewShow5 : System.Web.UI.Page
    {
        /// <summary>
        /// 查询已下的，且已经接受去配送的单
        /// </summary>
        /// <returns></returns>
        public List<UnCompleteTakedOrder> getDataToGridView5()
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            List<UnCompleteTakedOrder> UnOrder = new List<UnCompleteTakedOrder>();
            string jsonstr = jsonSerializer.Serialize(Session["ID"].ToString());

            //调用服务  
            RunServiceSoapClient testService = new RunServiceSoapClient();
            //接受json格式的字符串，反序列化

            WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
            soapHeader.UserName = Session["userName"].ToString();
            soapHeader.Password = Session["PS"].ToString();

            string result = testService.SearchUnCompleteTakedOrder(soapHeader, jsonstr);

            UnOrder = jsonSerializer.Deserialize<List<UnCompleteTakedOrder>>(result);


            return UnOrder;
        }

    }
}