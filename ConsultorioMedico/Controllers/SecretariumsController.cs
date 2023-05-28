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
    public class SecretariumsController : Controller
    {
        private readonly ProExpFinalContext _context;

        public SecretariumsController(ProExpFinalContext context)
        {
            _context = context;
        }

        // GET: Secretariums
        public async Task<IActionResult> Index()
        {
            var proExpFinalContext = _context.Secretaria.Include(s => s.IdUsuarioNavigation).Where(e => e.Estado == 1);
            return View(await proExpFinalContext.ToListAsync());
        }

        // GET: Secretariums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Secretaria == null)
            {
                return NotFound();
            }

            var secretarium = await _context.Secretaria
                .Include(s => s.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdSecretaria == id);
            if (secretarium == null)
            {
                return NotFound();
            }

            return View(secretarium);
        }

        // GET: Secretariums/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Secretariums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSecretaria,CodSecre,DuiSecre,NomSecre,ApeSecre,DirSecre,TelSecre,Estado,IdUsuario")] Secretarium secretarium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(secretarium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", secretarium.IdUsuario);
            return View(secretarium);
        }

        // GET: Secretariums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Secretaria == null)
            {
                return NotFound();
            }

            var secretarium = await _context.Secretaria.FindAsync(id);
            if (secretarium == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", secretarium.IdUsuario);
            return View(secretarium);
        }

        // POST: Secretariums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSecretaria,CodSecre,DuiSecre,NomSecre,ApeSecre,DirSecre,TelSecre,Estado,IdUsuario")] Secretarium secretarium)
        {
            if (id != secretarium.IdSecretaria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(secretarium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SecretariumExists(secretarium.IdSecretaria))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", secretarium.IdUsuario);
            return View(secretarium);
        }

        // GET: Secretariums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Secretaria == null)
            {
                return NotFound();
            }

            var secretarium = await _context.Secretaria
                .Include(s => s.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdSecretaria == id);
            if (secretarium == null)
            {
                return NotFound();
            }

            return View(secretarium);
        }

        // POST: Secretariums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("IdSecretaria,CodSecre,DuiSecre,NomSecre,ApeSecre,DirSecre,TelSecre,Estado,IdUsuario")] Secretarium secretarium)
        {
            if (_context.Secretaria == null)
            {
                return Problem("Entity set 'ProExpFinalContext.Secretaria'  is null.");
            }
            if (secretarium != null)
            {
                secretarium.Estado = 0;
                _context.Update(secretarium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SecretariumExists(int id)
        {
          return (_context.Secretaria?.Any(e => e.IdSecretaria == id)).GetValueOrDefault();
        }
    }
}
