using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registro.Data;
using Registro.Models;

namespace Registro.Controllers
{
    public class RegistroController : Controller
    {
        private readonly AppDBContext _appDbContext;
        public RegistroController(AppDBContext appBbContext)
        {
            _appDbContext = appBbContext;
        }

        [HttpGet]
        public async Task<IActionResult> ListaPersonas()
        {
            List<Persona> ListaPersonas = await _appDbContext.Personas.ToListAsync();
            return View(ListaPersonas);
        }
        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Nuevo(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return View(persona);
            }
            else
            {
                await _appDbContext.Personas.AddAsync(persona);
                await _appDbContext.SaveChangesAsync(); 
                return RedirectToAction(nameof(ListaPersonas));
            }
        }
    }
}
