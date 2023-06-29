using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial29_6.Data;
using Parcial29_6.Models;

namespace Parcial29_6.Controllers
{
    public class SociosController : Controller
    {
        private readonly Context _context;

        public SociosController(Context context)
        {
            _context = context;
        }

        // GET: Socios
        public async Task<IActionResult> Index()
        {
              return _context.Socios != null ? 
                          View(await _context.Socios.ToListAsync()) :
                          Problem("Entity set 'Context.Socios'  is null.");
        }
        // GET: Indexconbarra
        public async Task<IActionResult> Indexconbarra()
        {
            return RedirectToAction("Index", "Pagos");
        }
        // GET: Socios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Socios == null)
            {
                return NotFound();
            }

            var socios = await _context.Socios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socios == null)
            {
                return NotFound();
            }

            return View(socios);
        }

        // GET: Socios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Socios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Categoria,Actividad,NSocio")] Socios socios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socios);
        }

        // GET: Socios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Socios == null)
            {
                return NotFound();
            }

            var socios = await _context.Socios.FindAsync(id);
            if (socios == null)
            {
                return NotFound();
            }
            return View(socios);
        }

        // POST: Socios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Categoria,Actividad,NSocio")] Socios socios)
        {
            if (id != socios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SociosExists(socios.Id))
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
            return View(socios);
        }

        // GET: Socios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Socios == null)
            {
                return NotFound();
            }

            var socios = await _context.Socios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socios == null)
            {
                return NotFound();
            }

            return View(socios);
        }

        // POST: Socios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Socios == null)
            {
                return Problem("Entity set 'Context.Socios'  is null.");
            }
            var socios = await _context.Socios.FindAsync(id);
            if (socios != null)
            {
                _context.Socios.Remove(socios);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SociosExists(int id)
        {
          return (_context.Socios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
