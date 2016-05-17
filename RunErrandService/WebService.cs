using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using Services.Business;
using Services;
using Services.Entity;
using Services.Data;
using System.Web.Security;

namespace RunErrandService
{
    public class WebService
    {
        #region 验证身份
        ///<summary>
        /// 验证接入用户身份
        /// </summary>
        /// <param name="VerifyJson"></param>
        /// <returns></returns>
        public bool VerifyUser(string UserName, string PassWord)
        {
            UserRoleID myUser;
            //PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PassWord, "MD5").ToLower();

            UserBusiness userBusiness = new UserBusiness();
            myUser = userBusiness.GetUserByUserName(UserName);
            if (myUser.PassWord == FormsAuthentication.HashPasswordForStoringInConfigFile(PassWord, "SHA1"))
            {

                return true;
            }
            else
            {
                return false;

            }

        }
        #endregion
    }
}