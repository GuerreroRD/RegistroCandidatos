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
              return View(await _db.Candidato.ToListAsync());
        }

		[HttpPost]
		public JsonResult Applicant()
		{
			int totalRecord = 0;
			int filterRecord = 0;
			var draw = Request.Form["draw"].FirstOrDefault();
			var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
			var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
			var searchValue = Request.Form["search[value]"].FirstOrDefault();
			int pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
			int skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
			var data = _db.Set<Candidato>()
				.Select(
				b => new
				{
					candidato_Id = b.ID_Candidato,
					nombres = b.Nombres,
					apellidos = b.Apellidos,
					cedula = Int64.Parse((b.Cedula.Replace("-", ""))).ToString("000-0000000-0"),
                    genero = b.Genero,
					fechaDeNacimiento = b.FechaDeNacimiento.ToString("dd/MM/yyyy"),
					trabajoActual = b.TrabajoActual,
					expectativaSalarial = b.ExpectativaSalarial


				}).AsEnumerable();
			//get total count of data in table
			totalRecord = data.Count();
			// search data when search value found
			if (!string.IsNullOrEmpty(searchValue))
			{
				data = data.Where(x =>
				x.nombres.ToLower().Contains(searchValue.ToLower())
				|| x.apellidos.ToLower().Contains(searchValue.ToLower())
				|| x.cedula.ToLower().Contains(searchValue.ToLower())
				|| x.genero.ToString().ToLower().Contains(searchValue.ToLower())
				|| x.trabajoActual.ToString().ToLower().Contains(searchValue.ToLower())
				|| x.expectativaSalarial.ToString().ToLower().Contains(searchValue.ToLower()));
			}
			// get total count of records after search
			filterRecord = data.Count();
			//sort data
			if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
			{
				//data = data.OrderBy(x => sortColumn + " " + sortColumnDirection);
				data = data.OrderBy(x => string.Join(" ", sortColumn, sortColumnDirection));







			}
			//pagination
			var ListaCandidatos = data.Skip(skip).Take(pageSize).ToList();
			var returnObj = new
			{
				draw = draw,
				recordsTotal = totalRecord,
				recordsFiltered = filterRecord,
				data = ListaCandidatos
			};

			return Json(returnObj);



		}

		// GET: Candidatos/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.Candidato == null)
            {
                return NotFound();
            }

            var candidato = await _db.Candidato
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
            

            
            return View();
        }

        // POST: Candidatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Candidato,Cedula,Nombres,Apellidos,FechaDeNacimiento,Genero,TrabajoActual,ExpectativaSalarial")] Candidato candidato)
        {


			if (CedulaExists(candidato.Cedula))
			{

				ModelState.AddModelError(String.Empty, "Esta cedula ya ha sido registrada");
				return View(candidato);

			}

			else if (ModelState.IsValid)
            {
				_db.Add(candidato);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(candidato);
        }

        // POST: Candidatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Candidato,Cedula,Nombres,Apellidos,FechaDeNacimiento,Genero,TrabajoActual,ExpectativaSalarial")] Candidato candidato)
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
