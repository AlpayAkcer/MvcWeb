using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWeb.Models.Entity
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [StringLength(70)]
        [Required(ErrorMessage = "Başlık Giriniz")]
        public string Name { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Description Giriniz")]
        public string Description { get; set; }

        [StringLength(150)]
        public string Picture { get; set; }

        public bool IsActive { get; set; }

        public int CategoryId { get; set; }
        public virtual Categories Categories { get; set; }

        public ICollection<Gallery> Galleries { get; set; }
    }
}