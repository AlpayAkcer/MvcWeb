using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWeb.Models.Entity
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [StringLength(70)]
        public string Namesurname { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }
        public DateTime ContactDate { get; set; }
        public string Message { get; set; }
        public bool IsActive { get; set; }
    }
}