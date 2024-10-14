﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmTrack.Data;
using FarmTrack.Models;

namespace FarmTrack.Controllers
{
    public class CropsController : Controller
    {
        private readonly FarmTrackContext _context;

        public CropsController(FarmTrackContext context)
        {
            _context = context;
        }

        // GET: Crops
        public async Task<IActionResult> Index()
        {
            return View(await _context.Crops.ToListAsync());
        }

        // GET: Crops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crop = await _context.Crops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crop == null)
            {
                return NotFound();
            }

            return View(crop);
        }

        // GET: Crops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type")] Crop crop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crop);
        }

        // GET: Crops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crop = await _context.Crops.FindAsync(id);
            if (crop == null)
            {
                return NotFound();
            }
            return View(crop);
        }

        // POST: Crops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type")] Crop crop)
        {
            if (id != crop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CropExists(crop.Id))
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
            return View(crop);
        }

        // GET: Crops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crop = await _context.Crops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crop == null)
            {
                return NotFound();
            }

            return View(crop);
        }

        // POST: Crops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crop = await _context.Crops.FindAsync(id);
            if (crop != null)
            {
                _context.Crops.Remove(crop);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CropExists(int id)
        {
            return _context.Crops.Any(e => e.Id == id);
        }
    }
}
