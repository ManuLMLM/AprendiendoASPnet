using AprendiendoASPnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprendiendoASPnet.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly EstudiandoAspnetContext _Contexto;
        public UsuarioController(EstudiandoAspnetContext contexto)
        {
            _Contexto= contexto;
        }
        public async Task<IActionResult> Index()//Consultas para una sola tabla
        {
            return View(await _Contexto.Usuarios.ToListAsync());
        }
    }
}
