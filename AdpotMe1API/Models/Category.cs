using System.ComponentModel.DataAnnotations;

namespace AdoptMe1.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Animal>? Animals { get; set; }
    }
}
