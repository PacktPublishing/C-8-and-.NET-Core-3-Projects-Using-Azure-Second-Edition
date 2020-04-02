using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebResearch.Models;

namespace WebResearch.Controllers
{
    public class ResearchController : Controller
    {
        private readonly ResearchContext _context;

        public ResearchController(ResearchContext context)
        {
            _context = context;
        }

        // GET: Research
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResearchLinks.ToListAsync());
        }

        // GET: Research/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var research = await _context.ResearchLinks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (research == null)
            {
                return NotFound();
            }

            return View(research);
        }

        // GET: Research/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Research/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Url,DateSaved,Note")] Research research)
        {
            if (ModelState.IsValid)
            {
                _context.Add(research);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(research);
        }

        // GET: Research/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var research = await _context.ResearchLinks.SingleOrDefaultAsync(m => m.Id == id);
            if (research == null)
            {
                return NotFound();
            }
            return View(research);
        }

        // POST: Research/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Url,DateSaved,Note")] Research research)
        {
            if (id != research.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(research);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResearchExists(research.Id))
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
            return View(research);
        }

        // GET: Research/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var research = await _context.ResearchLinks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (research == null)
            {
                return NotFound();
            }

            return View(research);
        }

        // POST: Research/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var research = await _context.ResearchLinks.SingleOrDefaultAsync(m => m.Id == id);
            _context.ResearchLinks.Remove(research);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResearchExists(int id)
        {
            return _context.ResearchLinks.Any(e => e.Id == id);
        }
    }
}
