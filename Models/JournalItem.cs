using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace home_journal.Models
{
    public class JournalItem
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        
        [Display(Name = "Planned Date")]
        [DataType(DataType.Date)]
        public DateTime PlanDate { get; set; }

        [StringLength(30)]
        [Required]
        public string Description { get; set; }

        
        [DataType(DataType.Currency)]
        [Display(Name = "Estimated Cost")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$")]
        [StringLength(20)]
        [Required]
        public string Priority { get; set; }
    }
}
