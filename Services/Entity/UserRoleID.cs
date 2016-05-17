using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Entity
{
    public class UserRoleID
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int RoleID { get; set; }
        public string PassWord { get; set; }

        public string RealName { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int UserType { get; set; }
    }
}
