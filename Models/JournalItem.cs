using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace home_journal.Models
{
    public class JournalItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        [Display(Name = "Planned Date")]
        [DataType(DataType.Date)]
        public DateTime PlanDate { get; set; }
        public string Description { get; set; }

        [Display(Name = "Estimated Cost")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
