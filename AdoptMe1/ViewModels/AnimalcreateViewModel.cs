using AdoptMe1.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdoptMe1.ViewModels
{
    public class AnimalcreateViewModelAnimalcreateViewModel
    {

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Must enter Name")]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Must enter type")]
        [Display(Name = "Type")]
        public string? Type { get; set; }

        [Required(ErrorMessage = "Must enter Age")]
        [Range(1, 130)]
        [Display(Name = "Age")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Must enter Description")]
        [StringLength(1000)]
        [Display(Name = "Descrption")]
        public string? Description { get; set; }

        //Relationship
        [Required(ErrorMessage = "Must enter Category")]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
