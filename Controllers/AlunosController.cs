using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciamentoDeAlunos.Models;
using Microsoft.AspNetCore.Authorization;

namespace GerenciadorDeAlunos.Controllers
{
	[Authorize]
	public class AlunosController : Controller
	{
		private readonly GerenciadorDeAlunosContext _context;

		public AlunosController(GerenciadorDeAlunosContext context)
		{
			_context = context;
		}

		// GET: Alunos
		public async Task<IActionResult> Index()
		{
			return _context.Aluno != null ?
						View(await _context.Aluno.
							Include(a => a.Estado)
						   .Include(a => a.Cidade)
						   .Include(a => a.InstituicaoEnsino).ToListAsync()) :
						Problem("Entity set 'GerenciadorDeAlunosContext.Aluno'  is null.");
		}

		// GET: Alunos/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Aluno == null)
			{
				return NotFound();
			}

			var aluno = await _context.Aluno
						   .Include(a => a.Estado)
						   .Include(a => a.Cidade)
						   .Include(a => a.InstituicaoEnsino)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (aluno == null)
			{
				return NotFound();
			}

			return View(aluno);
		}

		// GET: Alunos/Create
		public IActionResult Create()
		{
			ViewBag.Estados = _context.Estados.ToList();
			ViewBag.Cidades = _context.Cidades.ToList();
			ViewBag.InstituicoesEnsino = _context.InstituicoesEnsino.ToList();
			return View();
		}

		// POST: Alunos/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Endereco,NomeCurso,DataConclusao,EstadoId,CidadeId,InstituicaoEnsinoId")] Aluno aluno)
		{
			if (ModelState.IsValid)
			{
				_context.Add(aluno);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			// Se houver um erro de validação, recupere os dados necessários para preencher os dropdowns novamente
			ViewBag.Estados = _context.Estados.ToList();
			ViewBag.Cidades = _context.Cidades.ToList();
			ViewBag.InstituicoesEnsino = _context.InstituicoesEnsino.ToList();

			return View(aluno);
		}

		// GET: Alunos/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			ViewBag.Estados = _context.Estados.ToList();
			ViewBag.Cidades = _context.Cidades.ToList();
			ViewBag.InstituicoesEnsino = _context.InstituicoesEnsino.ToList();

			if (id == null || _context.Aluno == null)
			{
				return NotFound();
			}

			var aluno = await _context.Aluno.FindAsync(id);
			if (aluno == null)
			{
				return NotFound();
			}
			return View(aluno);
		}

		// POST: Alunos/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Endereco,NomeCurso,DataConclusao,EstadoId,CidadeId,InstituicaoEnsinoId")] Aluno aluno)
		{
			if (id != aluno.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(aluno);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!AlunoExists(aluno.Id))
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
			return View(aluno);
		}

		// GET: Alunos/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Aluno == null)
			{
				return NotFound();
			}

			var aluno = await _context.Aluno
				.FirstOrDefaultAsync(m => m.Id == id);
			if (aluno == null)
			{
				return NotFound();
			}

			return View(aluno);
		}

		// POST: Alunos/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Aluno == null)
			{
				return Problem("Entity set 'GerenciadorDeAlunosContext.Aluno'  is null.");
			}
			var aluno = await _context.Aluno.FindAsync(id);
			if (aluno != null)
			{
				_context.Aluno.Remove(aluno);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool AlunoExists(int id)
		{
			return (_context.Aluno?.Any(e => e.Id == id)).GetValueOrDefault();
		}

		[HttpGet]
		public JsonResult GetCidadesByEstado(int estadoId)
		{
			var cidades = _context.Cidades.Where(c => c.EstadoId == estadoId).ToList();
			return Json(cidades);
		}

        public IActionResult Report()
        {
            ViewBag.InstituicoesEnsino = _context.InstituicoesEnsino.ToList();
			var alunos = _context.Aluno.ToList();
			return View(alunos);
        }

        [HttpPost]
        public IActionResult Report(int instituicaoEnsinoId)
        {
            var alunos = _context.Aluno
                .Where(a => a.InstituicaoEnsinoId == instituicaoEnsinoId)
                .ToList();
            return PartialView("_AlunosRelatorio", alunos);
        }

    }
}
