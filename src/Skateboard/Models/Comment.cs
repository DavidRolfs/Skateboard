using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skateboard.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Remark { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int BoardId { get; set; }
        public virtual Board Board { get; set; }
    }
}
