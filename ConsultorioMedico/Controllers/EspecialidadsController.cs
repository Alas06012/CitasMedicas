using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConsultorioMedico.Models;

namespace ConsultorioMedico.Controllers
{
    public class EspecialidadsController : Controller
    {
        private readonly ProExpFinalContext _context;

        public EspecialidadsController(ProExpFinalContext context)
        {
            _context = context;
        }

        // GET: Especialidads
        public async Task<IActionResult> Index()
        {
              return _context.Especialidads != null ? 
                          View(await _context.Especialidads.Where(e => e.Estado == 1).ToListAsync()) :
                          Problem("Entity set 'ProExpFinalContext.Especialidads'  is null.");
        }

        // GET: Especialidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Especialidads == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidads
                .FirstOrDefaultAsync(m => m.IdEspecialidad == id);
            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        // GET: Especialidads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especialidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodEspecialidad,Especialidad1,Estado")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }

        // GET: Especialidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Especialidads == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidads.FindAsync(id);
            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        // POST: Especialidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEspecialidad,CodEspecialidad,Especialidad1,Estado")] Especialidad especialidad)
        {
            if (id != especialidad.IdEspecialidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especialidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecialidadExists(especialidad.IdEspecialidad))
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
            return View(especialidad);
        }

        // GET: Especialidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Especialidads == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidads
                .FirstOrDefaultAsync(m => m.IdEspecialidad == id);
            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        // POST: Especialidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("IdEspecialidad,CodEspecialidad,Especialidad1,Estado")] Especialidad especialidad)
        {
            if (_context.Especialidads == null)
            {
                return Problem("Entity set 'ProExpFinalContext.Especialidads'  is null.");
            }
            if (especialidad != null)
            {
                especialidad.Estado = 0;
                _context.Update(especialidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecialidadExists(int id)
        {
          return (_context.Especialidads?.Any(e => e.IdEspecialidad == id)).GetValueOrDefault();
        }
    }
}
