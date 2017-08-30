using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skateboard.Models
{
    [Table("Boards")]
    public class Board
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Year { get; set; }
        public string Rider { get; set; }
        public string Series { get; set; }
        public string Size { get; set; }
        public string Img { get; set; }
        public string ForSale { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
