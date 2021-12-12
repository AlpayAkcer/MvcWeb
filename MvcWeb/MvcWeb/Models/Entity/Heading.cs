using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWeb.Models.Entity
{
    public class Heading
    {
        [Key]
        public int HeadingId { get; set; }

        [StringLength(70)]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Content> Contents { get; set; }
    }
}