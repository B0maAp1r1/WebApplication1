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
    public class PizzaTypesFromDBsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PizzaTypesFromDBsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PizzaTypesFromDBs
        public async Task<IActionResult> Index()
        {
            return View(await _context.PizzaTypesFromDB.ToListAsync());
        }

        // GET: PizzaTypesFromDBs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaTypesFromDB = await _context.PizzaTypesFromDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pizzaTypesFromDB == null)
            {
                return NotFound();
            }

            return View(pizzaTypesFromDB);
        }

        // GET: PizzaTypesFromDBs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PizzaTypesFromDBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PizzaDescription,PizzaSize,PizzaPrice")] PizzaTypesFromDB pizzaTypesFromDB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pizzaTypesFromDB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pizzaTypesFromDB);
        }

        // GET: PizzaTypesFromDBs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaTypesFromDB = await _context.PizzaTypesFromDB.FindAsync(id);
            if (pizzaTypesFromDB == null)
            {
                return NotFound();
            }
            return View(pizzaTypesFromDB);
        }

        // POST: PizzaTypesFromDBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PizzaDescription,PizzaSize,PizzaPrice")] PizzaTypesFromDB pizzaTypesFromDB)
        {
            if (id != pizzaTypesFromDB.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pizzaTypesFromDB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaTypesFromDBExists(pizzaTypesFromDB.Id))
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
            return View(pizzaTypesFromDB);
        }

        // GET: PizzaTypesFromDBs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaTypesFromDB = await _context.PizzaTypesFromDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pizzaTypesFromDB == null)
            {
                return NotFound();
            }

            return View(pizzaTypesFromDB);
        }

        // POST: PizzaTypesFromDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pizzaTypesFromDB = await _context.PizzaTypesFromDB.FindAsync(id);
            if (pizzaTypesFromDB != null)
            {
                _context.PizzaTypesFromDB.Remove(pizzaTypesFromDB);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaTypesFromDBExists(int id)
        {
            return _context.PizzaTypesFromDB.Any(e => e.Id == id);
        }
    }
}
