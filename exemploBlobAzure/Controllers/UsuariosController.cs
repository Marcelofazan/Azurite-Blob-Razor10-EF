using exemploBlobAzure.Data;
using exemploBlobAzure.Models;
using exemploBlobAzure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace exemploBlobAzure.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly MeuDbContext _context;
        private readonly BlobService _blobService;

        public UsuariosController(MeuDbContext context, BlobService blobService)
        {
            _context = context;
            _blobService = blobService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        public async Task<IActionResult> Details(int? usuarioid)
        {
            if (usuarioid == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioID == usuarioid);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario, IFormFile imageFile)
        {

            if (imageFile == null || imageFile.Length == 0)
            {
                ModelState.AddModelError("UsuarioImageUrl", "Please upload an image.");
                return View(usuario);
            }

            //Only attempt to add an image to blob when the field is full
            if (imageFile != null && imageFile.Length > 0)
            {
                string? imageUrl = await _blobService.Upload(imageFile);
                usuario.UsuarioImageUrl = imageUrl;
            }

            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        public async Task<IActionResult> Edit(int? usuarioid)
        {
            if (usuarioid == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(usuarioid);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? usuarioid, Usuario usuario, IFormFile? imageFile)
        {
            if (usuarioid != usuario.UsuarioID)
            {
                return NotFound();
            }

            if (imageFile == null || imageFile.Length == 0)
            {
                ModelState.AddModelError("UsuarioImageUrl", "Please upload an image.");
                return View(usuario);
            }

            //Only attempt to add an image to blob when the field is full
            if (imageFile != null && imageFile.Length > 0)
            {
                string? imageUrl = await _blobService.Upload(imageFile);
                usuario.UsuarioImageUrl = imageUrl;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.UsuarioID))
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
            return View(usuario);
        }

        public async Task<IActionResult> Delete(int? usuarioid)
        {
            if (usuarioid == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioID == usuarioid);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int usuarioid)
        {
            var usuario = await _context.Usuarios.FindAsync(usuarioid);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int usuarioid)
        {
            return _context.Usuarios.Any(e => e.UsuarioID == usuarioid);
        }
    }
}
