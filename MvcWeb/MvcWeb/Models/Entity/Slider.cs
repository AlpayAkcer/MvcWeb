using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWeb.Models.Entity
{
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }

        [StringLength(70)]
        [Required(ErrorMessage = "Başlık Giriniz")]
        public string Name { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Description Giriniz")]
        public string Description { get; set; }

        [StringLength(150)]
        public string Picture { get; set; }

        [StringLength(100)]
        public string Url { get; set; }

        public bool IsActive { get; set; }
    }
}