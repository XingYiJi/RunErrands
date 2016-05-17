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
    public partial class CountPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gridViewCPImportPercent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (e.Row.RowIndex + 1).ToString();

                ////如果使用了分页控件且希望序号在翻页后不重新计算，使用下面方法  
                //int indexID = (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize + e.Row.RowIndex + 1;  
                //e.Row.Cells[0].Text = indexID.ToString();  
            }
        }

        protected void gridViewCPImportPercent_RowDataBound2(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (e.Row.RowIndex + 1).ToString();

                ////如果使用了分页控件且希望序号在翻页后不重新计算，使用下面方法  
                //int indexID = (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize + e.Row.RowIndex + 1;  
                //e.Row.Cells[0].Text = indexID.ToString();  
            }
        }  
    }

    //public class GridViewShow9 : System.Web.UI.Page
    //{
    //    /// <summary>
    //    /// 前三下单人
    //    /// </summary>
    //    /// <returns></returns>
    //    public List<UserMessage> getDataToGridView9()
    //    {
    //        JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

    //        List<UserMessage> message = new List<UserMessage>();
    //        //string jsonstr = jsonSerializer.Serialize(Session["ID"].ToString());

    //        //调用服务  
    //        RunServiceSoapClient testService = new RunServiceSoapClient();
    //        //接受json格式的字符串，反序列化
    //        int i = 1;

    //        WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
    //        soapHeader.UserName = Session["userName"].ToString();
    //        soapHeader.Password = Session["PS"].ToString();

    //        string jsonstr = jsonSerializer.Serialize(i);

    //        string result = testService.SortBy(soapHeader, jsonstr);

    //        message = jsonSerializer.Deserialize<List<UserMessage>>(result);
    //        return message;
    //    }

    //    /// <summary>
    //    /// 前三下单街道
    //    /// </summary>
    //    /// <returns></returns>
    //    public List<UserMessage> getDataToGridView99()
    //    {
    //        JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

    //        List<UserMessage> message = new List<UserMessage>();
    //        //string jsonstr = jsonSerializer.Serialize(Session["ID"].ToString());

    //        //调用服务  
    //        RunServiceSoapClient testService = new RunServiceSoapClient();
    //        //接受json格式的字符串，反序列化

    //        WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
    //        soapHeader.UserName = Session["userName"].ToString();
    //        soapHeader.Password = Session["PS"].ToString();
    //        int i = 2;

    //        string jsonstr = jsonSerializer.Serialize(i);
    //        string result = testService.SortBy(soapHeader, jsonstr);

    //        message = jsonSerializer.Deserialize<List<UserMessage>>(result);
    //        return message;
    //    }

    //}
}