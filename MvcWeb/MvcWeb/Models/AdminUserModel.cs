using MvcWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWeb.Models
{
    public class AdminUserModel
    {
        public IEnumerable<Admin> Admins { get; set; }
        public IEnumerable<UserSocial> UserSocials { get; set; }
    }
}