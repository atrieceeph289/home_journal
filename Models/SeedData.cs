using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using home_journal.Data;
using System;
using System.Linq;

namespace home_journal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new home_journalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<home_journalContext>>()))
            {
                // Look for any journal items.
                if (context.JournalItem.Any())
                {
                    return;   // DB has been seeded
                }

                context.JournalItem.AddRange(
                    new JournalItem
                    {
                        Title = "Fix Shower Tile",
                        PlanDate = DateTime.Parse("2021-11-6"),
                        Description = "Repair",
                        Price = 250.00M
                    },

                    new JournalItem
                    {
                        Title = "Fix floor in boys room",
                        PlanDate = DateTime.Parse("2022-1-20"),
                        Description = "Upgrade",
                        Price = 300.00M
                    },

                    new JournalItem
                    {
                        Title = "Clear out basement",
                        PlanDate = DateTime.Parse("2021-11-12"),
                        Description = "Cleaning/Organizing",
                        Price = 0.00M
                    },

                    new JournalItem
                    {
                        Title = "Finish Floor in Dining Room",
                        PlanDate = DateTime.Parse("2021-11-23"),
                        Description = "Upgrade",
                        Price = 0.00M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}