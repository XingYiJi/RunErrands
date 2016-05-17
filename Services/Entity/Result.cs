using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Entity
{
    /// <summary>
    /// 返回的信息：0失败，messaged的值是“原因”，1成功
    /// </summary>
    public class Result
    {
        public string resutl { get; set; }             //判断是否登录成功
        public string message { get; set; }
        public bool resultModifyMessage { get; set; }
        public string bindGuidMessage { get; set; }  //判断是否绑定二维码成功与否
        public int RegisterMessage { get; set; }  //判断是否注册成功与否
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Ps { get; set; }
        public int UserType { get; set; }
    }
}
