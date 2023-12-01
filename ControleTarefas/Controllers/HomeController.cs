using ControleTarefas.Data;
using ControleTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ControleTarefas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ControleTarefasContext _context;
        public HomeController(ControleTarefasContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.TarefasModel != null ?
                        View(await _context.TarefasModel.ToListAsync()) :
                        Problem("Entity set 'ControleTarefasContext.TarefasModel'  is null.");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}