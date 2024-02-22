using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalApp.Data;
using HospitalApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace HospitalApp.Controllers
{
    public class PatientInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientInfoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PatientInfo.Include(p => p.Doctor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PatientInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientInfo = await _context.PatientInfo
                .Include(p => p.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientInfo == null)
            {
                return NotFound();
            }

            return View(patientInfo);
        }

        // GET: PatientInfoes/Create
        [Authorize(Roles = "Administrators")]
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Name");
            return View();
        }

        // POST: PatientInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,Age,Symptoms,Notes,DoctorId")] PatientInfo patientInfo)
        {
           // if (ModelState.IsValid)
           // {
                _context.Add(patientInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           // }
           // ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Name", patientInfo.DoctorId);
           // return View(patientInfo);
        }

        // GET: PatientInfoes/Edit/5
        [Authorize(Roles = "Administrators, Owners")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientInfo = await _context.PatientInfo.FindAsync(id);
            if (patientInfo == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Name", patientInfo.DoctorId);
            return View(patientInfo);
        }

        // POST: PatientInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators, Owners")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,Age,Symptoms,Notes,DoctorId")] PatientInfo patientInfo)
        {
            if (id != patientInfo.Id)
            {
                return NotFound();
            }

           // if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(patientInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientInfoExists(patientInfo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
           // }
           // ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Name", patientInfo.DoctorId);
           // return View(patientInfo);
        }

        // GET: PatientInfoes/Delete/5
         [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientInfo = await _context.PatientInfo
                .Include(p => p.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientInfo == null)
            {
                return NotFound();
            }

            return View(patientInfo);
        }

        // POST: PatientInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientInfo = await _context.PatientInfo.FindAsync(id);
            if (patientInfo != null)
            {
                _context.PatientInfo.Remove(patientInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientInfoExists(int id)
        {
            return _context.PatientInfo.Any(e => e.Id == id);
        }
    }
}
