using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWeb.Models.Entity
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [StringLength(70)]
        [Required(ErrorMessage = "Admin Adını Giriniz")]
        public string UserName { get; set; }

        [StringLength(70)]
        public string Name { get; set; }

        [StringLength(70)]
        public string Surname { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Admin Email Adresini Giriniz")]
        public string Email { get; set; }

        [StringLength(30)]
        public string Password { get; set; }

        [StringLength(150)]
        public string Picture { get; set; }

        [StringLength(70)]
        public string Title { get; set; }

        public int RoleId { get; set; }
        public virtual Role Roles { get; set; }

        public ICollection<UserSocial> UserSocials { get; set; }

    }
}