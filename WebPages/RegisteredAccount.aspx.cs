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
    public partial class RegisteredAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void Register_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(name.Text) ||  String.IsNullOrEmpty(Address.Text) || String.IsNullOrEmpty(RealName.Text) || String.IsNullOrEmpty(Phone.Text) || String.IsNullOrEmpty(p1.Text) || String.IsNullOrEmpty(p2.Text))
            {
                this.Page.RegisterStartupScript(" ", "<script>alert(' 请填写完整的信息 '); </script> ");
            }
            else
            {
                if (p1.Text != p2.Text)
                {
                    this.Page.RegisterStartupScript(" ", "<script>alert(' 两次输入的密码不一致 '); </script> ");
                }
                else
                {
                    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

                    UserRoleID userRole = new UserRoleID();
                    userRole.UserName = name.Text;
                    userRole.Address = Address.Text;
                    userRole.RealName = RealName.Text;
                    userRole.Phone = Phone.Text;
                    userRole.PassWord = p1.Text;

                    //执行序列化 part:1
                    string jsonstr = jsonSerializer.Serialize(userRole);

                    //调用服务  
                    RunServiceSoapClient testService = new RunServiceSoapClient();
                    ////接受json格式的字符串，反序列化

                    string result = testService.UserRegister(jsonstr);
                    int _back = jsonSerializer.Deserialize<int>(result);
                    if (_back == 0)
                    {

                        FieldInfo[] infos = GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
                        for (int i = 0; i < infos.Length; i++)
                        {
                            if (infos[i].FieldType == typeof(TextBox))
                            {
                                ((TextBox)infos[i].GetValue(this)).Text = "";
                            }
                        }  

                        this.Page.RegisterStartupScript(" ", "<script>alert(' 注册成功 '); </script> ");
                    }
                    else if (_back == 2)
                    {
                        this.Page.RegisterStartupScript(" ", "<script>alert(' 昵称已被使用 '); </script> ");
                    }
                }
            }

            
        }
    }
}