using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Services.Entity;
using WebPages.RunServiceReference;
using System.Data;

namespace WebPages
{
    public partial class MyOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.

                GridViewRow selectedRow = GridView2.Rows[index];
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

                Services.Entity.DeleteOrder DeleteOrder = new Services.Entity.DeleteOrder();
                DeleteOrder.OrderID = orderid;
                DeleteOrder.TakerID = Convert.ToInt32(Session["ID"].ToString());

                string jsonstr = jsonSerializer.Serialize(DeleteOrder);
                string result = testService.DeleteUnTakedOrder(soapHeader, jsonstr);
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
        }
    }

    public class GridViewShow2 : System.Web.UI.Page
    {
        /// <summary>
        /// 查询已下的，但是没人接受去配送的单
        /// </summary>
        /// <returns></returns>
        public List<UncompleteOrder> getDataToGridView1()
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            List<UncompleteOrder> UnOrder = new List<UncompleteOrder>();
            string jsonstr = jsonSerializer.Serialize(Session["ID"].ToString());

            //调用服务  
            RunServiceSoapClient testService = new RunServiceSoapClient();
            //接受json格式的字符串，反序列化

            WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
            soapHeader.UserName = Session["userName"].ToString();
            soapHeader.Password = Session["PS"].ToString();

            string result = testService.SearchUnCompleteOrder(soapHeader, jsonstr);

            UnOrder = jsonSerializer.Deserialize<List<UncompleteOrder>>(result);


            return UnOrder;
        }

    }

    public class GridViewShow3 : System.Web.UI.Page
    {
        /// <summary>
        /// 查询已下单且已有人接单去配送的单
        /// </summary>
        /// <returns></returns>
        public List<UncompleteOrder> getDataToGridView3()
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            List<UncompleteOrder> UnOrder = new List<UncompleteOrder>();
            string jsonstr = jsonSerializer.Serialize(Session["ID"].ToString());

            //调用服务  
            RunServiceSoapClient testService = new RunServiceSoapClient();
            //接受json格式的字符串，反序列化

            WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
            soapHeader.UserName = Session["userName"].ToString();
            soapHeader.Password = Session["PS"].ToString();

            string result = testService.SearchUnCompleteOrder2(soapHeader, jsonstr);

            UnOrder = jsonSerializer.Deserialize<List<UncompleteOrder>>(result);


            return UnOrder;
        }
 
    }
}