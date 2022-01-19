using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GenshinImpactHelper.Data;
using GenshinImpactHelper.Models;

namespace GenshinImpactHelper.Controllers
{
    public class GiServersController : Controller
    {
        private readonly GenshinImpactHelperContext _context;

        public GiServersController(GenshinImpactHelperContext context)
        {
            _context = context;
        }

        // GET: GiServers
        public async Task<IActionResult> Index()
        {
            return View(await _context.GiServers.ToListAsync());
        }

        // GET: GiServers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giServer = await _context.GiServers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giServer == null)
            {
                return NotFound();
            }

            return View(giServer);
        }

        // GET: GiServers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GiServers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] GiServer giServer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giServer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giServer);
        }

        // GET: GiServers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giServer = await _context.GiServers.FindAsync(id);
            if (giServer == null)
            {
                return NotFound();
            }
            return View(giServer);
        }

        // POST: GiServers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title")] GiServer giServer)
        {
            if (id != giServer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giServer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiServerExists(giServer.Id))
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
            return View(giServer);
        }

        // GET: GiServers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giServer = await _context.GiServers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giServer == null)
            {
                return NotFound();
            }

            return View(giServer);
        }

        // POST: GiServers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var giServer = await _context.GiServers.FindAsync(id);
            _context.GiServers.Remove(giServer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiServerExists(long id)
        {
            return _context.GiServers.Any(e => e.Id == id);
        }
    }
}
