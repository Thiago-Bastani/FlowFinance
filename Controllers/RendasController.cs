using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowFinance.Data;
using FlowFinance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FlowFinance.Controllers
{
    public class RendasController : Controller
    {
        private readonly AppDbContext _context;

        public RendasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Rendas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rendas.ToListAsync());
        }

        // GET: Rendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renda = await _context.Rendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renda == null)
            {
                return NotFound();
            }

            return View(renda);
        }

        // GET: Rendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Valor,Data")] Renda renda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(renda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(renda);
        }

        // GET: Rendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renda = await _context.Rendas.FindAsync(id);
            if (renda == null)
            {
                return NotFound();
            }
            return View(renda);
        }

        // POST: Rendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Valor,Data")] Renda renda)
        {
            if (id != renda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RendaExists(renda.Id))
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
            return View(renda);
        }

        // GET: Rendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renda = await _context.Rendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renda == null)
            {
                return NotFound();
            }

            return View(renda);
        }

        // POST: Rendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var renda = await _context.Rendas.FindAsync(id);
            if (renda != null)
            {
                _context.Rendas.Remove(renda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RendaExists(int id)
        {
            return _context.Rendas.Any(e => e.Id == id);
        }
    }
}
