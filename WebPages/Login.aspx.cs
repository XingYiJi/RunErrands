using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services.Entity;
using Services.Data;
using System.Web.Script.Serialization;
using WebPages.RunServiceReference;
using System.Reflection;  

namespace WebPages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TextBox1.Text) || String.IsNullOrEmpty(TextBox2.Text))
            {
                this.Page.RegisterStartupScript(" ", "<script>alert(' 请填写用户名和密码 '); </script> ");
               
            }
            else
            {
                
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

                Userlogin personnel = new Userlogin();
                personnel.UserName = TextBox1.Text;
                personnel.Password = TextBox2.Text;

                //执行序列化 part:1
                string jsonstr = jsonSerializer.Serialize(personnel);

                //调用服务  
                RunServiceSoapClient testService = new RunServiceSoapClient();
                ////接受json格式的字符串，反序列化

                string result = testService.UserLogin(jsonstr);
                Result _back = jsonSerializer.Deserialize<Result>(result);
                if (_back.resutl !="0" )
                {
                    Session["userName"] = _back.UserName;
                    Session["PS"] = _back.Ps;
                    Session["ID"] = _back.UserID;
                    if (_back.UserType == 2)
                    {
                        Response.Redirect("PlaceOrder.aspx");
                    }
                    if (_back.UserType == 1)
                    {
                        Response.Redirect("CommentPage.aspx");
                    }
                    

                }
                else
                {
                    this.Page.RegisterStartupScript(" ", "<script>alert(' 登录失败 '); </script> ");
                }
                 
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisteredAccount.aspx");
        }
    }
}