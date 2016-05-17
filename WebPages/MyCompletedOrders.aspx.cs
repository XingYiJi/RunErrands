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
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Services.Entity;
using WebPages.RunServiceReference;
using System.Data;
using System.Web.UI.WebControls;

namespace WebPages
{
    public partial class MyCompletedOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Comment")
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

                Services.Data.CommentOrder comment = new Services.Data.CommentOrder();
                comment.OrderID = orderid;
                comment.Comment = TextBox1.Text;

                string jsonstr = jsonSerializer.Serialize(comment);
                string result = testService.AddComment(soapHeader, jsonstr);
                string result2 = jsonSerializer.Deserialize<string>(result);


                if (result2 == "0")//退单成功
                {
                    Response.Redirect(Request.Url.ToString()); //刷新页面
                }
                else               //退单失败
                {
                    this.Page.RegisterStartupScript(" ", "<script>alert(' 评论失败 '); </script> ");
                }
            }
        }
    }

    public class GridViewShow4 : System.Web.UI.Page
    {
        /// <summary>
        /// 查询已下的，但是没人接受去配送的单
        /// </summary>
        /// <returns></returns>
        public List<CompleteOrder> getDataToGridView4()
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            List<CompleteOrder> UnOrder = new List<CompleteOrder>();
            string jsonstr = jsonSerializer.Serialize(Session["ID"].ToString());

            //调用服务  
            RunServiceSoapClient testService = new RunServiceSoapClient();
            //接受json格式的字符串，反序列化

            WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
            soapHeader.UserName = Session["userName"].ToString();
            soapHeader.Password = Session["PS"].ToString();

            string result = testService.SearchCompleteOrder(soapHeader, jsonstr);

            UnOrder = jsonSerializer.Deserialize<List<CompleteOrder>>(result);


            return UnOrder;
        }

    }
}