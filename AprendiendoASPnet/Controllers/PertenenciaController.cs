using AprendiendoASPnet.Models;
using AprendiendoASPnet.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AprendiendoASPnet.Controllers
{
    public class PertenenciaController : Controller
    {
        private readonly EstudiandoAspnetContext _context;
        public PertenenciaController(EstudiandoAspnetContext context) 
        {
            _context= context;
        }
        public async Task<IActionResult> Index()//Consulta para varias tablas
        {
            var consulta = _context.Pertenencias.Include(b=>b.IdUsuarioNavigation) ;
            return View(await consulta.ToListAsync());
        }
        public IActionResult Crear()
        {
            ViewData["Usuarios"] = new SelectList(_context.Usuarios, "IdUsuario", "Email");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//Campo de seguridad
        public async Task<ActionResult> Crear(PertenenciaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var perte = new Pertenencia()
                {
                    Nombre=model.nombre,
                    Cantidad=model.cantidad,
                    Precio=model.precio,
                    IdUsuario= model.Id2
                };
                _context.AddAsync(perte);//Lennar datos para la consulta
                await _context.SaveChangesAsync();//guardar la consulta en la base de datos
                return RedirectToAction(nameof(Index));
            }
            ViewData["Usuarios"] = new SelectList(_context.Usuarios, "IdUsuario", "Email",model.Id2);
            return View(model);
        }
    }
}
