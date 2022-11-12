using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistroCandidatos.Data;
using RegistroCandidatos.Models;

namespace RegistroCandidatos.Controllers
{
    public class CandidatosController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CandidatosController(ApplicationDbContext context)
        {
            _db = context;
        }

        // GET: Candidatos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _db.Candidato.Include(c => c.Genero);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Candidatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.Candidato == null)
            {
                return NotFound();
            }

            var candidato = await _db.Candidato
                .Include(c => c.Genero)
                .FirstOrDefaultAsync(m => m.ID_Candidato == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // GET: Candidatos/Create
        public IActionResult Create()
        {

            ViewData["ID_Genero"] = new SelectList(_db.Genero, "ID_Genero", "Nombre");
            return View();
        }

        // POST: Candidatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Candidato,Cedula,Nombres,Apellidos,FechaDeNacimiento,ID_Genero,TrabajoActual,ExpectativaSalarial")] Candidato candidato)
        {


            if (ModelState.IsValid)
            {
                _db.Add(candidato);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Genero"] = new SelectList(_db.Genero, "ID_Genero", "Nombre", candidato.ID_Genero);
            return View(candidato);
        }

        // GET: Candidatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.Candidato == null)
            {
                return NotFound();
            }

            var candidato = await _db.Candidato.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }
            ViewData["ID_Genero"] = new SelectList(_db.Genero, "ID_Genero", "Nombre", candidato.ID_Genero);
            return View(candidato);
        }

        // POST: Candidatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Candidato,Cedula,Nombres,Apellidos,FechaDeNacimiento,ID_Genero,TrabajoActual,ExpectativaSalarial")] Candidato candidato)
        {
            if (id != candidato.ID_Candidato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(candidato);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatoExists(candidato.ID_Candidato))
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
            ViewData["ID_Genero"] = new SelectList(_db.Genero, "ID_Genero", "Nombre", candidato.ID_Genero);
            return View(candidato);
        }

        // GET: Candidatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.Candidato == null)
            {
                return NotFound();
            }

            var candidato = await _db.Candidato
                .Include(c => c.Genero)
                .FirstOrDefaultAsync(m => m.ID_Candidato == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_db.Candidato == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Candidato'  is null.");
            }
            var candidato = await _db.Candidato.FindAsync(id);
            if (candidato != null)
            {
                _db.Candidato.Remove(candidato);
            }
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatoExists(int id)
        {
          return _db.Candidato.Any(e => e.ID_Candidato == id);
        }

        private bool CedulaExists(string cedula)
        {

            return _db.Candidato.Any(c => c.Cedula == cedula);


        }
    }
}
