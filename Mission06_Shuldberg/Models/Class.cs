using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Shuldberg.Models
{
    public class Class
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Please enter a Title")]
        public string Title { get; set; }

        [Required]
        [Range(1888, 3000, ErrorMessage = "Please enter a year after 1888")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please enter a Director")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Please enter a Rating")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "Please enter whether or not this is edited")]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Please enter whether or not this is edited")]
        public bool CopiedToPlex { get; set; }

        public string? Notes { get; set; }

    }
}
