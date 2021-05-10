using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gerikullanim.Data;
using gerikullanim.Models;

namespace gerikullanim.Controllers
{
    public class Duyurular : Controller
    {
        private readonly gerikullanimContext _context;

        public Duyurular(gerikullanimContext context)
        {
            _context = context;
        }

        // GET: Duyurular
        public async Task<IActionResult> Index()
        {
            var gerikullanimContext = _context.Duyurular.Include(d => d.Kullanici);
            return View(await gerikullanimContext.ToListAsync());
        }

        // GET: Duyurular/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duyuru = await _context.Duyurular
                .Include(d => d.Kullanici)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duyuru == null)
            {
                return NotFound();
            }

            return View(duyuru);
        }

        // GET: Duyurular/Create
        public IActionResult Create()
        {
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "Id", "Id");
            return View();
        }

        // POST: Duyurular/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DuyuruAdi,DuyuruAciklama,KullaniciId")] Duyuru duyuru)
        {
            if (ModelState.IsValid)
            {
                _context.Add(duyuru);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "Id", "Id", duyuru.KullaniciId);
            return View(duyuru);
        }

        // GET: Duyurular/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duyuru = await _context.Duyurular.FindAsync(id);
            if (duyuru == null)
            {
                return NotFound();
            }
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "Id", "Id", duyuru.KullaniciId);
            return View(duyuru);
        }

        // POST: Duyurular/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DuyuruAdi,DuyuruAciklama,KullaniciId")] Duyuru duyuru)
        {
            if (id != duyuru.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duyuru);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuyuruExists(duyuru.Id))
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
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "Id", "Id", duyuru.KullaniciId);
            return View(duyuru);
        }

        // GET: Duyurular/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duyuru = await _context.Duyurular
                .Include(d => d.Kullanici)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duyuru == null)
            {
                return NotFound();
            }

            return View(duyuru);
        }

        // POST: Duyurular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var duyuru = await _context.Duyurular.FindAsync(id);
            _context.Duyurular.Remove(duyuru);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuyuruExists(int id)
        {
            return _context.Duyurular.Any(e => e.Id == id);
        }
    }
}
