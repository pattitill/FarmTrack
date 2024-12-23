﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmTrack.Data;
using FarmTrack.Models;
using FarmTrack.ViewModels;

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
            var crops = await _context.Crops
                .Where(c => !c.Harvested) // Only include unharvested crops
                .Select(c => new CropViewModel
                {
                    CropId = c.CropId,
                    CropName = c.CropName,
                    CropType = c.CropType,
                    PlantingDate = c.PlantingDate,
                    GrowthDurationInDays = c.GrowthDurationInDays,
                    ExpectedHarvestDate = c.ExpectedHarvestDate,
                    Harvested = c.Harvested,
                    SecondsUntilHarvest = c.ExpectedHarvestDate.HasValue 
                        ? (int)(c.ExpectedHarvestDate.Value - DateTime.Now).TotalSeconds 
                        : 0 // If there's no ExpectedHarvestDate, default to 0
                })
                .ToListAsync();

            return View(crops);
        }
        // GET: Crops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crop = await _context.Crops
                .FirstOrDefaultAsync(m => m.CropId == id);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CropId,CropName,CropType,PlantingDate,GrowthDurationInDays,ExpectedHarvestDate")] Crop crop)
        {
            if (ModelState.IsValid)
            {
                crop.Harvested = false;
                crop.CalculateHarvestDate();
                _context.Add(crop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crop);
        }

        // GET: Crops/Edit/()
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

        // POST: Crops/Edit/()
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CropId,CropName,CropType,PlantingDate,GrowthDurationInDays,ExpectedHarvestDate")] Crop crop)
        {
            if (id != crop.CropId)
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
                    if (!CropExists(crop.CropId))
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

        // GET: Crops/Delete/()
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crop = await _context.Crops
                .FirstOrDefaultAsync(m => m.CropId == id);
            if (crop == null)
            {
                return NotFound();
            }

            return View(crop);
        }

        // POST: Crops/Delete/()
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
            return _context.Crops.Any(e => e.CropId == id);
        }

        // Action to mark the crop as harvested and set the RealHarvestDate
        [HttpPost]
        public async Task<IActionResult> Harvest(int id)
        {
            var crop = await _context.Crops.FindAsync(id);
            if (crop == null)
            {
                return NotFound();
            }

            crop.Harvested = true;
            crop.HarvestDate = DateTime.Now;

            _context.Update(crop);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
