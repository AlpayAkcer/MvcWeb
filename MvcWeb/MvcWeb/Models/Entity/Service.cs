using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWeb.Models.Entity
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [StringLength(70)]
        [Required(ErrorMessage = "Başlık Giriniz")]
        public string Name { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Description Giriniz")]
        public string Description { get; set; }

        [StringLength(150)]
        public string Picture { get; set; }

        public bool IsActive { get; set; }
    }
}