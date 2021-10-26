using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using home_journal.Models;

namespace home_journal.Data
{
    public class home_journalContext : DbContext
    {
        public home_journalContext (DbContextOptions<home_journalContext> options)
            : base(options)
        {
        }

        public DbSet<home_journal.Models.JournalItem> JournalItem { get; set; }
    }
}
