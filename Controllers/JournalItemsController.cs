using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using home_journal.Data;
using home_journal.Models;

namespace home_journal.Controllers
{
    public class JournalItemsController : Controller
    {
        private readonly home_journalContext _context;

        public JournalItemsController(home_journalContext context)
        {
            _context = context;
        }

        // GET: JournalItems
        public async Task<IActionResult> Index(string journalDescription, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> descriptionQuery = from j in _context.JournalItem
                                            orderby j.Description
                                            select j.Description;

            var journalItems = from j in _context.JournalItem
                         select j;

            if (!string.IsNullOrEmpty(searchString))
            {
                journalItems = journalItems.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(journalDescription))
            {
                journalItems = journalItems.Where(x => x.Description.Contains(journalDescription));
            }

            var journalDescriptionVM = new JournalDescriptionViewModel
            {
                Description = new SelectList(await descriptionQuery.Distinct().ToListAsync()),
                JournalItems = await journalItems.ToListAsync()
            };

            return View(journalDescriptionVM);
        }

        // GET: JournalItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journalItem = await _context.JournalItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (journalItem == null)
            {
                return NotFound();
            }

            return View(journalItem);
        }

        // GET: JournalItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JournalItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,PlanDate,Description,Price")] JournalItem journalItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(journalItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(journalItem);
        }

        // GET: JournalItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journalItem = await _context.JournalItem.FindAsync(id);
            if (journalItem == null)
            {
                return NotFound();
            }
            return View(journalItem);
        }

        // POST: JournalItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,PlanDate,Description,Price")] JournalItem journalItem)
        {
            if (id != journalItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(journalItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JournalItemExists(journalItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(journalItem);
        }

        // GET: JournalItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journalItem = await _context.JournalItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (journalItem == null)
            {
                return NotFound();
            }

            return View(journalItem);
        }

        // POST: JournalItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var journalItem = await _context.JournalItem.FindAsync(id);
            _context.JournalItem.Remove(journalItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JournalItemExists(int id)
        {
            return _context.JournalItem.Any(e => e.Id == id);
        }
    }
}
