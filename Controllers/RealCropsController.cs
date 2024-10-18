using System;
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
    public class RealCropsController : Controller
    {
        private readonly FarmTrackContext _context;

        public RealCropsController(FarmTrackContext context)
        {
            _context = context;
        }

        // GET: RealCrops
        public async Task<IActionResult> Index()
        {
            var farmTrackContext = _context.RealCrops.Include(r => r.Crop);
            return View(await farmTrackContext.ToListAsync());
        }

        // GET: RealCrops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realCrop = await _context.RealCrops
                .Include(r => r.Crop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realCrop == null)
            {
                return NotFound();
            }

            return View(realCrop);
        }

        // GET: RealCrops/Create
        public IActionResult Create()
        {
            // Populate the dropdown with available crops
            ViewData["CropId"] = new SelectList(_context.Crops, "Id", "Name");
            return View();
        }

        // POST: RealCrops/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CropId,Planting,ExpectedHarvestDate,ActualHarvestDate,Amount")] RealCrop realCrop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(realCrop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Re-populate the dropdown in case the model state is invalid
            ViewData["CropId"] = new SelectList(_context.Crops, "Id", "Name", realCrop.CropId);
            return View(realCrop);
        }

        // GET: RealCrops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realCrop = await _context.RealCrops.FindAsync(id);
            if (realCrop == null)
            {
                return NotFound();
            }
            // Populate the dropdown for editing
            ViewData["CropId"] = new SelectList(_context.Crops, "Id", "Name", realCrop.CropId);
            return View(realCrop);
        }

        // POST: RealCrops/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CropId,Planting,ExpectedHarvestDate,ActualHarvestDate,Amount")] RealCrop realCrop)
        {
            if (id != realCrop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(realCrop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RealCropExists(realCrop.Id))
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
            // Re-populate the dropdown in case the model state is invalid
            ViewData["CropId"] = new SelectList(_context.Crops, "Id", "Name", realCrop.CropId);
            return View(realCrop);
        }

        // GET: RealCrops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realCrop = await _context.RealCrops
                .Include(r => r.Crop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realCrop == null)
            {
                return NotFound();
            }

            return View(realCrop);
        }

        // POST: RealCrops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var realCrop = await _context.RealCrops.FindAsync(id);
            if (realCrop != null)
            {
                _context.RealCrops.Remove(realCrop);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RealCropExists(int id)
        {
            return _context.RealCrops.Any(e => e.Id == id);
        }
    }
}
