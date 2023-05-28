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
    public class MedicosController : Controller
    {
        private readonly ProExpFinalContext _context;

        public MedicosController(ProExpFinalContext context)
        {
            _context = context;
        }

        // GET: Medicos
        public async Task<IActionResult> Index()
        {
            var proExpFinalContext = _context.Medicos.Where(e => e.Estado == 1).Include(m => m.IdEspecialidadNavigation).Include(m => m.IdUsuarioNavigation);
            return View(await proExpFinalContext.ToListAsync());
        }

        // GET: Medicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medicos == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos
                .Include(m => m.IdEspecialidadNavigation)
                .Include(m => m.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdMedico == id);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // GET: Medicos/Create
        public IActionResult Create()
        {
            ViewData["IdEspecialidad"] = new SelectList(_context.Especialidads, "IdEspecialidad", "IdEspecialidad");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodMedico,DuiMedico,NomMedico,ApeMedico,DirMedico,TelMedico,Estado,IdEspecialidad,IdUsuario")] Medico medico)
        {
  
                _context.Medicos.Add(medico);
                await _context.SaveChangesAsync();
                ViewData["IdEspecialidad"] = new SelectList(_context.Especialidads, "IdEspecialidad", "IdEspecialidad", medico.IdEspecialidad);
                ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", medico.IdUsuario);
                return RedirectToAction(nameof(Index));
            
          
        }

        // GET: Medicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medicos == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }
            ViewData["IdEspecialidad"] = new SelectList(_context.Especialidads, "IdEspecialidad", "IdEspecialidad", medico.IdEspecialidad);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", medico.IdUsuario);
            return View(medico);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedico,CodMedico,DuiMedico,NomMedico,ApeMedico,DirMedico,TelMedico,Estado,IdEspecialidad,IdUsuario")] Medico medico)
        {
            if (id != medico.IdMedico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicoExists(medico.IdMedico))
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
            ViewData["IdEspecialidad"] = new SelectList(_context.Especialidads, "IdEspecialidad", "IdEspecialidad", medico.IdEspecialidad);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", medico.IdUsuario);
            return View(medico);
        }

        // GET: Medicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medicos == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos
                .Include(m => m.IdEspecialidadNavigation)
                .Include(m => m.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdMedico == id);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medicos == null)
            {
                return Problem("Entity set 'ProExpFinalContext.Medicos'  is null.");
            }
            var medico = await _context.Medicos.FindAsync(id);
            if (medico != null)
            {
                medico.Estado = 0;
                _context.Medicos.Update(medico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicoExists(int id)
        {
          return (_context.Medicos?.Any(e => e.IdMedico == id)).GetValueOrDefault();
        }
    }
}
