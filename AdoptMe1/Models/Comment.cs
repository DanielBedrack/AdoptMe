using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AdoptMe1.Models
{
    public class Comment
    {
        //Relationship
        [Key]
        public int CommentId { get; set; }
        public int AnimalId { get; set; }

        [ForeignKey("AnimalId")]
        public virtual Animal? Animal { get; set; }

        [Required(ErrorMessage = "Cannot enter an empty comment")]
        [DataType(DataType.MultilineText)]
        public string? Comments { get; set; }

    }
}
