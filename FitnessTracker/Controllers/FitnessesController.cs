using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessTracker.Data;
using FitnessTracker.Models;

namespace FitnessTracker.Controllers
{
    public class FitnessesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FitnessesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fitnesses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fitness.ToListAsync());
        }

        // GET: Fitnesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitness = await _context.Fitness
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fitness == null)
            {
                return NotFound();
            }

            return View(fitness);
        }

        // GET: Fitnesses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fitnesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,age,Weight,Height")] Fitness fitness)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fitness);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fitness);
        }

        // GET: Fitnesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitness = await _context.Fitness.FindAsync(id);
            if (fitness == null)
            {
                return NotFound();
            }
            return View(fitness);
        }

        // POST: Fitnesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,age,Weight,Height")] Fitness fitness)
        {
            if (id != fitness.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fitness);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FitnessExists(fitness.Id))
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
            return View(fitness);
        }

        // GET: Fitnesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitness = await _context.Fitness
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fitness == null)
            {
                return NotFound();
            }

            return View(fitness);
        }

        // POST: Fitnesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fitness = await _context.Fitness.FindAsync(id);
            if (fitness != null)
            {
                _context.Fitness.Remove(fitness);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FitnessExists(int id)
        {
            return _context.Fitness.Any(e => e.Id == id);
        }
    }
}
