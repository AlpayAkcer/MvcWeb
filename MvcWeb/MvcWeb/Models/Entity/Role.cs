using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWeb.Models.Entity
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [StringLength(10)]
        public string RoleName { get; set; }

        [StringLength(250)]
        [AllowHtml]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Admin> Admins { get; set; }
    }
}