﻿using System;
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
    public class PagosController : Controller
    {
        private readonly Context _context;

        public PagosController(Context context)
        {
            _context = context;
        }

        // GET: Pagos
        public async Task<IActionResult> Index(string buscar)
        {
            var pago = from pagos in _context.Pagos select pagos;
            if (!String.IsNullOrEmpty(buscar))
            {
                pago = pago.Where(s => s.NSocio!.Contains(buscar));

            }
            return View(await pago.ToListAsync());
        } 
       
            // GET: Pagos/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pagos == null)
            {
                return NotFound();
            }

            var pagos = await _context.Pagos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagos == null)
            {
                return NotFound();
            }

            return View(pagos);
        }

        // GET: Pagos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NSocio,ValorCuota,FechadePago,NroCuota")] Pagos pagos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagos);
        }

        // GET: Pagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pagos == null)
            {
                return NotFound();
            }

            var pagos = await _context.Pagos.FindAsync(id);
            if (pagos == null)
            {
                return NotFound();
            }
            return View(pagos);
        }

        // POST: Pagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NSocio,ValorCuota,FechadePago,NroCuota")] Pagos pagos)
        {
            if (id != pagos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagosExists(pagos.Id))
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
            return View(pagos);
        }

        // GET: Pagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pagos == null)
            {
                return NotFound();
            }

            var pagos = await _context.Pagos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagos == null)
            {
                return NotFound();
            }

            return View(pagos);
        }

        // POST: Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pagos == null)
            {
                return Problem("Entity set 'Context.Pagos'  is null.");
            }
            var pagos = await _context.Pagos.FindAsync(id);
            if (pagos != null)
            {
                _context.Pagos.Remove(pagos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagosExists(int id)
        {
          return (_context.Pagos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
