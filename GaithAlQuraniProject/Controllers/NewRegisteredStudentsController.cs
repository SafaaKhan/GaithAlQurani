using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GaithAlQuraniProject.Data;
using GaithAlQuraniProject.Models;

namespace GaithAlQuraniProject.Controllers
{
    public class NewRegisteredStudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewRegisteredStudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NewRegisteredStudents
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewRegisteredStudent.ToListAsync());
        }

        // GET: NewRegisteredStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newRegisteredStudent = await _context.NewRegisteredStudent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newRegisteredStudent == null)
            {
                return NotFound();
            }

            return View(newRegisteredStudent);
        }

        // GET: NewRegisteredStudents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewRegisteredStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,phoneNumber,Rewayah,Country,MemorizedPart,CallingProgram,SuitableTime")] NewRegisteredStudent newRegisteredStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newRegisteredStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newRegisteredStudent);
        }

        // GET: NewRegisteredStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newRegisteredStudent = await _context.NewRegisteredStudent.FindAsync(id);
            if (newRegisteredStudent == null)
            {
                return NotFound();
            }
            return View(newRegisteredStudent);
        }

        // POST: NewRegisteredStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,phoneNumber,Rewayah,Country,MemorizedPart,CallingProgram,SuitableTime")] NewRegisteredStudent newRegisteredStudent)
        {
            if (id != newRegisteredStudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newRegisteredStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewRegisteredStudentExists(newRegisteredStudent.Id))
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
            return View(newRegisteredStudent);
        }

        // GET: NewRegisteredStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newRegisteredStudent = await _context.NewRegisteredStudent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newRegisteredStudent == null)
            {
                return NotFound();
            }

            return View(newRegisteredStudent);
        }

        // POST: NewRegisteredStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newRegisteredStudent = await _context.NewRegisteredStudent.FindAsync(id);
            _context.NewRegisteredStudent.Remove(newRegisteredStudent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewRegisteredStudentExists(int id)
        {
            return _context.NewRegisteredStudent.Any(e => e.Id == id);
        }
    }
}
