using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Services.Entity;
using WebPages.RunServiceReference;
using System.Data;
using System.Web.UI.WebControls;

namespace WebPages
{
    public partial class TakeOrder : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AjaxPro.Utility.RegisterTypeForAjax(typeof(TakeOrder));
            }
            
        }

        [AjaxPro.AjaxMethod]
        public List<PointShow> getData()
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            List<PointShow> pointshow = new List<PointShow>();
            string jsonstr = jsonSerializer.Serialize("0");

            //调用服务  
            RunServiceSoapClient testService = new RunServiceSoapClient();
            //接受json格式的字符串，反序列化

            WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
            soapHeader.UserName = Session["userName"].ToString();
            soapHeader.Password = Session["PS"].ToString();

            string result = testService.SearchMapPoint(soapHeader, jsonstr);
           
            pointshow = jsonSerializer.Deserialize<List<PointShow>>(result);

            
            return pointshow;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
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

                Services.Entity.TakeOrder takeOrder = new Services.Entity.TakeOrder();
                takeOrder.OrderID = orderid;
                takeOrder.TakerID = Convert.ToInt32(Session["ID"].ToString());

                string jsonstr = jsonSerializer.Serialize(takeOrder);
                string result = testService.UserTakeOrder(soapHeader, jsonstr);
                string result2 = jsonSerializer.Deserialize<string>(result);


                if (result2 == "0")//下单成功
                {
                    Response.Redirect(Request.Url.ToString()); //刷新页面
                }
                else               //下单失败
                {
                    this.Page.RegisterStartupScript(" ", "<script>alert(' 下单失败 '); </script> ");
                }
            }
        }

      

        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex; //刷新页面？？
        //    //InitPage(); //重新绑定GridView数据的函数
        //}

    }

    public class GridViewShow : System.Web.UI.Page
    {
        public List<PointShow> getData2()
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            List<PointShow> pointshow = new List<PointShow>();
            string jsonstr = jsonSerializer.Serialize("0");

            //调用服务  
            RunServiceSoapClient testService = new RunServiceSoapClient();
            //接受json格式的字符串，反序列化

            WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
            soapHeader.UserName = Session["userName"].ToString();
            soapHeader.Password = Session["PS"].ToString();

            string result = testService.SearchMapPoint(soapHeader, jsonstr);

            pointshow = jsonSerializer.Deserialize<List<PointShow>>(result);


            return pointshow;
        }

        
 
    }
}