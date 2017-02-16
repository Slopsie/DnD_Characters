using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DnD.Data;
using DnD.Models;

namespace DnD.Controllers
{
    public class DnD_InfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DnD_InfoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: DnD_Info
        public async Task<IActionResult> Index()
        {
            return View(await _context.DnD_Info.ToListAsync());
        }
        
        // GET: DnD_Info/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dnD_Info = await _context.DnD_Info.SingleOrDefaultAsync(m => m.ID == id);
            if (dnD_Info == null)
            {
                return NotFound();
            }

            return View(dnD_Info);
        }

        // GET: DnD_Info/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DnD_Info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Class,Level,Gold")] DnD_Info dnD_Info)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dnD_Info);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dnD_Info);
        }

        // GET: DnD_Info/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dnD_Info = await _context.DnD_Info.SingleOrDefaultAsync(m => m.ID == id);
            if (dnD_Info == null)
            {
                return NotFound();
            }
            return View(dnD_Info);
        }

        // POST: DnD_Info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Class,Level,Gold")] DnD_Info dnD_Info)
        {
            if (id != dnD_Info.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dnD_Info);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DnD_InfoExists(dnD_Info.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(dnD_Info);
        }

        // GET: DnD_Info/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dnD_Info = await _context.DnD_Info.SingleOrDefaultAsync(m => m.ID == id);
            if (dnD_Info == null)
            {
                return NotFound();
            }

            return View(dnD_Info);
        }

        // POST: DnD_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dnD_Info = await _context.DnD_Info.SingleOrDefaultAsync(m => m.ID == id);
            _context.DnD_Info.Remove(dnD_Info);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DnD_InfoExists(int id)
        {
            return _context.DnD_Info.Any(e => e.ID == id);
        }
    }
}
