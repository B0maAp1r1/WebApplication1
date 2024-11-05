using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DealsFromDBsController : Controller
    {
        private readonly WebApplication1Context _context;

        public DealsFromDBsController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: DealsFromDBs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DealsFromDBs.ToListAsync());
        }

        // GET: DealsFromDBs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealsFromDBs = await _context.DealsFromDBs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dealsFromDBs == null)
            {
                return NotFound();
            }

            return View(dealsFromDBs);
        }

        // GET: DealsFromDBs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DealsFromDBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PizzaDescription,PizzaSize,PizzaBase,PizzaCrust,Price")] DealsFromDBs dealsFromDBs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dealsFromDBs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dealsFromDBs);
        }

        // GET: DealsFromDBs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealsFromDBs = await _context.DealsFromDBs.FindAsync(id);
            if (dealsFromDBs == null)
            {
                return NotFound();
            }
            return View(dealsFromDBs);
        }

        // POST: DealsFromDBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PizzaDescription,PizzaSize,PizzaBase,PizzaCrust,Price")] DealsFromDBs dealsFromDBs)
        {
            if (id != dealsFromDBs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dealsFromDBs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealsFromDBsExists(dealsFromDBs.Id))
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
            return View(dealsFromDBs);
        }

        // GET: DealsFromDBs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealsFromDBs = await _context.DealsFromDBs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dealsFromDBs == null)
            {
                return NotFound();
            }

            return View(dealsFromDBs);
        }

        // POST: DealsFromDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dealsFromDBs = await _context.DealsFromDBs.FindAsync(id);
            if (dealsFromDBs != null)
            {
                _context.DealsFromDBs.Remove(dealsFromDBs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DealsFromDBsExists(int id)
        {
            return _context.DealsFromDBs.Any(e => e.Id == id);
        }
    }
}
