using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;
using LogicaAccesoDatos.RepositoriosEntity;

namespace MVC.Controllers
{
    public class EcosistemasController : Controller
    {
        private readonly ObligatorioContext _context;

        public EcosistemasController(ObligatorioContext context)
        {
            _context = context;
        }

        // GET: Ecosistemas
        public async Task<IActionResult> Index()
        {
            var obligatorioContext = _context.Ecosistemas.Include(e => e.EstadoConservacion);
            return View(await obligatorioContext.ToListAsync());
        }

        // GET: Ecosistemas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ecosistemas == null)
            {
                return NotFound();
            }

            var ecosistema = await _context.Ecosistemas
                .Include(e => e.EstadoConservacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ecosistema == null)
            {
                return NotFound();
            }

            return View(ecosistema);
        }

        // GET: Ecosistemas/Create
        public IActionResult Create()
        {
            ViewData["EstadoConservacionId"] = new SelectList(_context.EstadosConservacion, "Id", "Nombre");
            return View();
        }

        // POST: Ecosistemas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,AreaMetrosCuadrados,Descripcion,EstadoConservacionId")] Ecosistema ecosistema)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ecosistema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoConservacionId"] = new SelectList(_context.EstadosConservacion, "Id", "Nombre", ecosistema.EstadoConservacionId);
            return View(ecosistema);
        }

        // GET: Ecosistemas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ecosistemas == null)
            {
                return NotFound();
            }

            var ecosistema = await _context.Ecosistemas.FindAsync(id);
            if (ecosistema == null)
            {
                return NotFound();
            }
            ViewData["EstadoConservacionId"] = new SelectList(_context.EstadosConservacion, "Id", "Nombre", ecosistema.EstadoConservacionId);
            return View(ecosistema);
        }

        // POST: Ecosistemas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,AreaMetrosCuadrados,Descripcion,EstadoConservacionId")] Ecosistema ecosistema)
        {
            if (id != ecosistema.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ecosistema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EcosistemaExists(ecosistema.Id))
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
            ViewData["EstadoConservacionId"] = new SelectList(_context.EstadosConservacion, "Id", "Nombre", ecosistema.EstadoConservacionId);
            return View(ecosistema);
        }

        // GET: Ecosistemas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ecosistemas == null)
            {
                return NotFound();
            }

            var ecosistema = await _context.Ecosistemas
                .Include(e => e.EstadoConservacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ecosistema == null)
            {
                return NotFound();
            }

            return View(ecosistema);
        }

        // POST: Ecosistemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ecosistemas == null)
            {
                return Problem("Entity set 'ObligatorioContext.Ecosistemas'  is null.");
            }
            var ecosistema = await _context.Ecosistemas.FindAsync(id);
            if (ecosistema != null)
            {
                _context.Ecosistemas.Remove(ecosistema);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EcosistemaExists(int id)
        {
          return (_context.Ecosistemas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
