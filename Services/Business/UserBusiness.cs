using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using Services.Data;
using Services.Entity;

namespace Services.Business
{
    public class UserBusiness
    {
        #region Context
        /// <summary>
        /// 防止UserDBEntities没有创建
        /// </summary>
        /// 
        private Entities houseAppEntities;        // UserDBEntities IBusinessService.HouseDAContext
        Entities HouseAppEntities
        {
            set
            {         
                houseAppEntities = value;
            }
            get
            {
                if (houseAppEntities == null)
                {
                    houseAppEntities = new Entities();
                }
                return houseAppEntities;
            }
        }
        #endregion

        /// <summary>
        /// 通过用户名来调取相应的用户信息，如果重复，那么只取一条
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public UserRoleID GetUserByUserName(string loginName)
        {
            var query = (from c in HouseAppEntities.User
                         where c.UserName == loginName
                         select new UserRoleID
                         {
                             PassWord = c.Password,
                             UserName = c.UserName,
                             UserID = c.UserID,
                             UserType = c.UserTypeID
                         });
            return query.FirstOrDefault();
        }


        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public int  RegisterNewUser(UserRoleID ReData)
        {
            User u1 = new User();
            u1.UserName = ReData.UserName;
            u1.Adress = ReData.Address;
            u1.RealName = ReData.RealName;
            u1.Phone = ReData.Phone;
            u1.Password = ReData.PassWord;
            u1.UserTypeID = 2;
            var query = (from c in HouseAppEntities.User
                         orderby c.UserID descending
                         select c);
            u1.UserID = query.First<User>().UserID + 1;
            
            HouseAppEntities.User.Add(u1);
            HouseAppEntities.SaveChanges();
            return 0;
        }

        /// <summary>
        /// 检查是否用户名重复
        /// </summary>
        /// <param name="ReData"></param>
        /// <returns></returns>
        public int CheckDuplicatName(string ChData)
        {
            var query = (from c in HouseAppEntities.User
                         where c.UserName == ChData
                         select c);
            
            if (query.Count() > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
