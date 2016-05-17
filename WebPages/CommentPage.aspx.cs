using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Services.Entity;
using WebPages.RunServiceReference;
using System.Data;
using Services.Data;

namespace WebPages.Admin
{
    public partial class CommentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Search")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.

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
                string result = testService.GetComment(soapHeader, jsonstr);
                string result2 = jsonSerializer.Deserialize<string>(result);


                if (result2 != null || result2 != "loginfalse")
                {
                    this.Page.RegisterStartupScript(" ", "<script>alert(' " + result2 + " '); </script> ");
                }
                else               
                {
                    this.Page.RegisterStartupScript(" ", "<script>alert(' 查看失败 '); </script> ");
                }
            }
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

                string jsonstr = jsonSerializer.Serialize(orderid);
                string result = testService.GetOrder(soapHeader, jsonstr);

                Order result2 = jsonSerializer.Deserialize<Order>(result);


                if (result2 != null )
                {
                    string str = "订单号：" + result2.OrderID.ToString() + "建单人ID：" + result2.CreaterID.ToString() + "货物名："  + result2.ProductName + "货物重量：" + result2.ProductWeight + "发件人名：" + result2.SenderName + "发件人手机号：" + result2.SenderPhone + "发件地址：" + result2.SenderAddress + "收件人姓名：" + result2.ReceiverName + "收件人手机号：" + result2.ReceiverPhone + "收件人地址：" + result2.ReceiverAddress + "接单人ID：" + result2.TakerID  + "备注：" + result2.Remarks;

                    this.Page.RegisterStartupScript(" ", "<script>alert(' "+ str +" '); </script> ");
                }
                else               
                {
                    this.Page.RegisterStartupScript(" ", "<script>alert(' 查看失败 '); </script> ");
                }
            }
        }

    }

    public class GridViewShow7 : System.Web.UI.Page
    {
        /// <summary>
        /// 查询已下单且已有人接单去配送的单
        /// </summary>
        /// <returns></returns>
        public List<CommentOrder> getDataToGridView7()
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            List<CommentOrder> comment = new List<CommentOrder>();
            //string jsonstr = jsonSerializer.Serialize(Session["ID"].ToString());

            //调用服务  
            RunServiceSoapClient testService = new RunServiceSoapClient();
            //接受json格式的字符串，反序列化

            WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
            soapHeader.UserName = Session["userName"].ToString();
            soapHeader.Password = Session["PS"].ToString();

            string result = testService.SearchComment(soapHeader);

            comment = jsonSerializer.Deserialize<List<CommentOrder>>(result);
            return comment;
        }

    }
}