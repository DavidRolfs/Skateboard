using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skateboard.Models
{
    [Table("Images")]
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
