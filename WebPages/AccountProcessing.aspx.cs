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
    public partial class AccountProcessing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Lock")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = GridView1.Rows[index];
                TableCell contactName = selectedRow.Cells[0];
                string contact = contactName.Text;
                int userid = Convert.ToInt32(contact);
                UserQuest quest = new UserQuest();
                quest.UserID = userid;
                quest.state = 2;
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();


                //调用服务  
                RunServiceSoapClient testService = new RunServiceSoapClient();
                //接受json格式的字符串，反序列化
                WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
                soapHeader.UserName = Session["userName"].ToString();
                soapHeader.Password = Session["PS"].ToString();

                string jsonstr = jsonSerializer.Serialize(quest);
                string result = testService.ModifyUserType(soapHeader, jsonstr);
                string result2 = jsonSerializer.Deserialize<string>(result);

                if (result2 != null || result2 != "loginfalse")
                {
                    Response.Redirect(Request.Url.ToString());
                    this.Page.RegisterStartupScript(" ", "<script>alert('  修改成功 '); </script> ");
                }
                else
                {
                    this.Page.RegisterStartupScript(" ", "<script>alert(' 修改失败 '); </script> ");
                }
            }            
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UnLock")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = GridView2.Rows[index];
                TableCell contactName = selectedRow.Cells[0];
                string contact = contactName.Text;
                int userid = Convert.ToInt32(contact);
                UserQuest quest = new UserQuest();
                quest.UserID = userid;
                quest.state = 3;
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();


                //调用服务  
                RunServiceSoapClient testService = new RunServiceSoapClient();
                //接受json格式的字符串，反序列化
                WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
                soapHeader.UserName = Session["userName"].ToString();
                soapHeader.Password = Session["PS"].ToString();

                string jsonstr = jsonSerializer.Serialize(quest);
                string result = testService.ModifyUserType(soapHeader, jsonstr);
                string result2 = jsonSerializer.Deserialize<string>(result);

                if (result2 != null || result2 != "loginfalse")
                {
                    Response.Redirect(Request.Url.ToString());
                    this.Page.RegisterStartupScript(" ", "<script>alert('  修改成功 '); </script> ");
                }
                else
                {
                    this.Page.RegisterStartupScript(" ", "<script>alert(' 修改失败 '); </script> ");
                }
            }
        }

    }

    public class GridViewShow8 : System.Web.UI.Page
    {
        /// <summary>
        /// 正常状态的用户
        /// </summary>
        /// <returns></returns>
        public List<UserMessage> getDataToGridView8()
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            List<UserMessage> message = new List<UserMessage>();
            //string jsonstr = jsonSerializer.Serialize(Session["ID"].ToString());

            //调用服务  
            RunServiceSoapClient testService = new RunServiceSoapClient();
            //接受json格式的字符串，反序列化
            int i = 2;

            WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
            soapHeader.UserName = Session["userName"].ToString();
            soapHeader.Password = Session["PS"].ToString();

            string jsonstr = jsonSerializer.Serialize(i);

            string result = testService.SearchUserByType(soapHeader,jsonstr);

            message = jsonSerializer.Deserialize<List<UserMessage>>(result);
            return message;
        }

        /// <summary>
        /// 封号中的用户
        /// </summary>
        /// <returns></returns>
        public List<UserMessage> getDataToGridView88()
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            List<UserMessage> message = new List<UserMessage>();
            //string jsonstr = jsonSerializer.Serialize(Session["ID"].ToString());

            //调用服务  
            RunServiceSoapClient testService = new RunServiceSoapClient();
            //接受json格式的字符串，反序列化

            WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
            soapHeader.UserName = Session["userName"].ToString();
            soapHeader.Password = Session["PS"].ToString();
            int i = 3;

            string jsonstr = jsonSerializer.Serialize(i);
            string result = testService.SearchUserByType(soapHeader, jsonstr);

            message = jsonSerializer.Deserialize<List<UserMessage>>(result);
            return message;
        }

    }
}