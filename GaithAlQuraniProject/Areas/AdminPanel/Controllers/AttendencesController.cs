using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GaithAlQuraniProject.Data;
using GaithAlQuraniProject.Models;

namespace GaithAlQuraniProject.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AttendencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminPanel/Attendences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Attendences.Include(a => a.NewRegisteredStudent);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AdminPanel/Attendences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendence = await _context.Attendences
                .Include(a => a.NewRegisteredStudent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendence == null)
            {
                return NotFound();
            }

            return View(attendence);
        }

        // GET: AdminPanel/Attendences/Create
        public IActionResult Create()
        {
            ViewData["NewRegisteredStudentId"] = new SelectList(_context.NewRegisteredStudent, "Id", "Id");
            return View();
        }

        // POST: AdminPanel/Attendences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Attendence attendence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NewRegisteredStudentId"] = new SelectList(_context.NewRegisteredStudent, "Id", "CallingProgram", attendence.NewRegisteredStudentId);
            return View(attendence);
        }

        // GET: AdminPanel/Attendences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendence = await _context.Attendences.FindAsync(id);
            if (attendence == null)
            {
                return NotFound();
            }
            ViewData["NewRegisteredStudentId"] = new SelectList(_context.NewRegisteredStudent, "Id", "CallingProgram", attendence.NewRegisteredStudentId);
            return View(attendence);
        }

        // POST: AdminPanel/Attendences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,date,attendenceState,Notes,NewRegisteredStudentId")] Attendence attendence)
        {
            if (id != attendence.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendenceExists(attendence.Id))
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
            ViewData["NewRegisteredStudentId"] = new SelectList(_context.NewRegisteredStudent, "Id", "CallingProgram", attendence.NewRegisteredStudentId);
            return View(attendence);
        }

        // GET: AdminPanel/Attendences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendence = await _context.Attendences
                .Include(a => a.NewRegisteredStudent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendence == null)
            {
                return NotFound();
            }

            return View(attendence);
        }

        // POST: AdminPanel/Attendences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendence = await _context.Attendences.FindAsync(id);
            _context.Attendences.Remove(attendence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendenceExists(int id)
        {
            return _context.Attendences.Any(e => e.Id == id);
        }
    }
}
