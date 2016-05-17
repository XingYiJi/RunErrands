using System;
using System.Web.Script.Serialization;
using System.Net;
using System.Text;
using Services.Entity;
using WebPages.RunServiceReference;
using RunErrandService;
using System.Reflection;
using System.Web.UI.WebControls;

namespace WebPages
{
    public partial class PlaceOrder : System.Web.UI.Page
    {
        
        int userID;
        string ps;
        string uName;
        protected void Page_Load(object sender, EventArgs e)
        {
            HideTextBox1.Attributes.Add("style", "display:none");
            HideTextBox2.Attributes.Add("style", "display:none");

            uName = Session["userName"].ToString();
            ps = Session["PS"].ToString();
            userID = Convert.ToInt32(Session["ID"].ToString());
        }

        protected void Sure_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            AddressMessage addressMessage = new AddressMessage();

            if (String.IsNullOrEmpty(HideTextBox1.Text))
            {
                ReadSAddress.Text ="请选取地址";
            }
            else
            {
                string url1 = "http://api.map.baidu.com/geocoder/v2/?ak=q6P5QgqiGo7d3hYanna6uAQnYVB4nLf6&callback=renderReverse&location=";
                string url2="&output=json&pois=1";
                string url = url1 + HideTextBox1.Text + url2;
                client.Encoding = Encoding.UTF8;
                string responseTest = client.DownloadString(url);
                responseTest=responseTest.Replace(@"""", "");

                int lngStart = responseTest.IndexOf("lng:");
                int lngEnd = responseTest.IndexOf(",lat:");
                int latEnd = responseTest.IndexOf("},formatted");

                addressMessage.longitude = responseTest.Substring(lngStart + 4, lngEnd - lngStart-4);
                addressMessage.latitude = responseTest.Substring(lngEnd + 5, latEnd - lngEnd - 5);

                addressMessage.Address = responseTest.Substring(responseTest.IndexOf("formatted_address:") + 18, responseTest.IndexOf(",business") - responseTest.IndexOf("formatted_address:") - 18);
                addressMessage.Street = responseTest.Substring(responseTest.IndexOf("street:") + 7, responseTest.IndexOf(",street_number") - responseTest.IndexOf("street:") - 7);

                ReadSAddress.Text = addressMessage.Address;
                TextBox14.Text = addressMessage.Address;

                ViewState["pointX1"] = addressMessage.latitude;
                ViewState["pointY1"] = addressMessage.longitude;
                ViewState["Street"] = addressMessage.Street;
            }
        }

        protected void Sure2_Click2(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            AddressMessage addressMessage = new AddressMessage();

            if (String.IsNullOrEmpty(HideTextBox1.Text))
            {
                ReadRAddress2.Text = "请选取地址";
            }
            else
            {
                string url1 = "http://api.map.baidu.com/geocoder/v2/?ak=q6P5QgqiGo7d3hYanna6uAQnYVB4nLf6&callback=renderReverse&location=";
                string url2 = "&output=json&pois=1";
                string url = url1 + HideTextBox2.Text + url2;
                client.Encoding = Encoding.UTF8;
                string responseTest = client.DownloadString(url);
                responseTest = responseTest.Replace(@"""", "");

                int lngStart = responseTest.IndexOf("lng:");
                int lngEnd = responseTest.IndexOf(",lat:");
                int latEnd = responseTest.IndexOf("},formatted");

                addressMessage.longitude = responseTest.Substring(lngStart + 4, lngEnd - lngStart - 4);
                addressMessage.latitude = responseTest.Substring(lngEnd + 5, latEnd - lngEnd - 5);   

                addressMessage.Address = responseTest.Substring(responseTest.IndexOf("formatted_address:") + 18, responseTest.IndexOf(",business") - responseTest.IndexOf("formatted_address:") - 18);
                ReadRAddress2.Text = addressMessage.Address;
                TextBox15.Text = addressMessage.Address;

                ViewState["pointX2"] = addressMessage.latitude;
                ViewState["pointY2"] = addressMessage.longitude;
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TextBox11.Text) || String.IsNullOrEmpty(TextBox13.Text) || String.IsNullOrEmpty(TextBox6.Text) || String.IsNullOrEmpty(TextBox8.Text) || String.IsNullOrEmpty(TextBox14.Text)
                    || String.IsNullOrEmpty(TextBox7.Text) || String.IsNullOrEmpty(TextBox9.Text) || String.IsNullOrEmpty(TextBox15.Text))
            {
                this.Page.RegisterStartupScript(" ", "<script>alert(' 请填写完整信息 '); </script> ");
            }
            else
            {
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

                Services.Entity.PlaceOrder placeOrder = new Services.Entity.PlaceOrder();
                //placeOrder.OrderID 
                placeOrder.CreaterID = userID;
                //placeOrder.CreateDateTime = DateTime.Now;
                placeOrder.ProductName = TextBox11.Text;
                placeOrder.ProductWeight = DropDownList1.Text;
                placeOrder.Remarks = TextBox13.Text;
                placeOrder.SenderName = TextBox6.Text;
                placeOrder.SenderPhone = TextBox8.Text;
                placeOrder.SenderAddress = TextBox14.Text;
                placeOrder.ReceiverName = TextBox7.Text;
                placeOrder.ReceiverPhone = TextBox9.Text;
                placeOrder.ReceiverAddress = TextBox15.Text;
                placeOrder.PointX = ViewState["pointX1"].ToString();
                placeOrder.PointY = ViewState["pointY1"].ToString();
                placeOrder.PointX2 = ViewState["pointX2"].ToString();
                placeOrder.PointY2 = ViewState["pointY2"].ToString();
                placeOrder.Street = ViewState["Street"].ToString();

                //执行序列化 part:1
                string jsonstr = jsonSerializer.Serialize(placeOrder);


                //调用服务  
                RunServiceSoapClient testService = new RunServiceSoapClient();
                //接受json格式的字符串，反序列化

                WebPages.RunServiceReference.MySoapHeader soapHeader = new WebPages.RunServiceReference.MySoapHeader();
                soapHeader.UserName = uName;
                soapHeader.Password = ps;

                string result = testService.UserPlaceOrder(soapHeader, jsonstr);

                if (result != "0")
                {
                    FieldInfo[] infos = GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
                    for (int i = 0; i < infos.Length; i++)
                    {
                        if (infos[i].FieldType == typeof(TextBox))
                        {
                            ((TextBox)infos[i].GetValue(this)).Text = "";
                        }
                    }
                    this.Page.RegisterStartupScript(" ", "<script>alert(' 下单成功 '); </script> ");

                }
                else
                {
                    this.Page.RegisterStartupScript(" ", "<script>alert(' 下单失败 '); </script> ");
                }
            }



        }
       
    }
}