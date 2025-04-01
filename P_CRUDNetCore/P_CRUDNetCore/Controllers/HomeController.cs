using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P_CRUDNetCore.Data;
using P_CRUDNetCore.Models;
using System.Diagnostics;

namespace P_CRUDNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.m_Contacts.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear() 
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Contact contact)
        {
            if (ModelState.IsValid)
            { 
                //Agregar fecha y hora
                contact.FechaCreacion = DateTime.Now;

                _context.m_Contacts.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {

            if(id == null)
            {
                return NotFound();

            }

            var contacto = _context.m_Contacts.Find(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Contact contact)
        {
            if (ModelState.IsValid)
            {
               
                _context.Update(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Detalle(int? id)
        {

            if (id == null)
            {
                return NotFound();

            }

            var contacto = _context.m_Contacts.Find(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {

            if (id == null)
            {
                return NotFound();

            }

            var contacto = _context.m_Contacts.Find(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarContacto(int? id)
        {
            var contacto = await _context.m_Contacts.FindAsync(id);
            if(contacto == null)
            {
                return View();
            }

            _context.m_Contacts.Remove(contacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
