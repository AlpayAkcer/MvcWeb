using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWeb.Models.Entity
{
    public class Gallery
    {
        [Key]
        public int GalleryId { get; set; }
        [StringLength(70)]
        public string Name { get; set; }

        public string Picture { get; set; }
        public bool IsActive { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}