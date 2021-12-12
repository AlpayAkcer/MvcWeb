using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWeb.Models.Entity
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }

        [StringLength(10)]
        public string RoleName { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public ICollection<Admin> Admins { get; set; }
    }
}