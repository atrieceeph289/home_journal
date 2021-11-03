using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace home_journal.Models
{
    public class JournalDescriptionViewModel
    {
        public List<JournalItem> JournalItems { get; set; }
        public SelectList Description { get; set; }
        public string ItemDescription{ get; set; }
        public string SearchString { get; set; }
    }
}