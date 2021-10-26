using System;
using System.ComponentModel.DataAnnotations;

namespace home_journal.Models
{
    public class JournalItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime PlanDate { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
