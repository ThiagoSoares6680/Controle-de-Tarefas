using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleTarefas.Data;
using ControleTarefas.Models;

namespace ControleTarefas.Controllers
{
    public class TarefasModelsController : Controller
    {
        private readonly ControleTarefasContext _context;

        public TarefasModelsController(ControleTarefasContext context)
        {
            _context = context;
        }

        // GET: TarefasModels
        public async Task<IActionResult> Index()
        {
              return _context.TarefasModel != null ? 
                          View(await _context.TarefasModel.ToListAsync()) :
                          Problem("Entity set 'ControleTarefasContext.TarefasModel'  is null.");
        }

        // POST: TarefasModels
        [HttpPost]
        public async Task<IActionResult> Index(int id, [Bind("StatusTarefa")] TarefasModel tarefasModel)
        {
            if (id == null || _context.TarefasModel == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var tarefas = await _context.TarefasModel.FindAsync(id);
                    tarefas.StatusTarefa = 1;
                    _context.Update(tarefas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefasModelExists(tarefasModel.ID))
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
            return View(tarefasModel);

        }

        // GET: TarefasModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TarefasModel == null)
            {
                return NotFound();
            }

            var tarefasModel = await _context.TarefasModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tarefasModel == null)
            {
                return NotFound();
            }

            return View(tarefasModel);
        }

        // GET: TarefasModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TarefasModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Tarefa")] TarefasModel tarefasModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarefasModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefasModel);
        }

        // GET: TarefasModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TarefasModel == null)
            {
                return NotFound();
            }

            var tarefasModel = await _context.TarefasModel.FindAsync(id);
            if (tarefasModel == null)
            {
                return NotFound();
            }
            return View(tarefasModel);
        }

        // POST: TarefasModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Tarefa")] TarefasModel tarefasModel)
        {
            if (id != tarefasModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarefasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefasModelExists(tarefasModel.ID))
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
            return View(tarefasModel);
        }

        // GET: TarefasModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TarefasModel == null)
            {
                return NotFound();
            }

            var tarefasModel = await _context.TarefasModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tarefasModel == null)
            {
                return NotFound();
            }

            return View(tarefasModel);
        }

        // POST: TarefasModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TarefasModel == null)
            {
                return Problem("Entity set 'ControleTarefasContext.TarefasModel'  is null.");
            }
            var tarefasModel = await _context.TarefasModel.FindAsync(id);
            if (tarefasModel != null)
            {
                _context.TarefasModel.Remove(tarefasModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarefasModelExists(int id)
        {
          return (_context.TarefasModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
