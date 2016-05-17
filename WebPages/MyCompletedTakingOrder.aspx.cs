using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services.Entity;
using WebPages.RunServiceReference;


namespace WebPages
{
    public partial class MyCompletedTakingOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

    public class GridViewShow6 : System.Web.UI.Page
    {
        /// <summary>
        /// 查询已下的，且已经完成的
        /// </summary>
        /// <returns></returns>
        public List<CompleteTakedOrder> getDataToGridView6()
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            List<CompleteTakedOrder> UnOrder = new List<CompleteTakedOrder>();
            string jsonstr = jsonSerializer.Serialize(Session["ID"].ToString());

            //调用服务  
            RunServiceSoapClient testService = new RunServiceSoapClient();
            //接受json格式的字符串，反序列化

            WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
            soapHeader.UserName = Session["userName"].ToString();
            soapHeader.Password = Session["PS"].ToString();

            string result = testService.SearchCompleteTakedOrder(soapHeader, jsonstr);

            UnOrder = jsonSerializer.Deserialize<List<CompleteTakedOrder>>(result);


            return UnOrder;
        }

    }
}