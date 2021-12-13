using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWeb.Models.Entity
{
    public class UserSocial
    {
        [Key]
        public int UserSocialId { get; set; }
        public string Name { get; set; }
        public string IconCss { get; set; }
        public string Url { get; set; }

        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; }
    }
}