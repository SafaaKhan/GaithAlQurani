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
            TempData["message"] = null;
            ViewData["NewRegisteredStudentId"] = new SelectList(_context.NewRegisteredStudent, "Id", "Id");
            ViewData["NewRegisteredStudent"] =  _context.NewRegisteredStudent;//dropdown
            ViewData["Attendance"] =  _context.Attendences;//dropdown
            return View();
        }

        [HttpPost]
        public ActionResult SaveAttendance( string[] attendenceState,string[] Notes, DateTime date, int[] NewRegisteredStudentId, string groupName, string surahName)
        {
            for(int i=0; i< NewRegisteredStudentId.Count(); i++)
            {
                var attendance = new Attendence
                {
                    NewRegisteredStudentId = NewRegisteredStudentId[i],
                    attendenceState= attendenceState[i],
                    date= date.ToString(),
                    Notes=Notes[i],
                    groupName= groupName,
                    surahName= surahName,
                    
                };
                _context.Attendences.Add(attendance);
                _context.SaveChanges();
            }

            //StudentsAttendance sa = new StudentsAttendance();
            //Student s = new Student();
            //var chkDate = db.StudentsAttendances.Where(a => a.Date == attendanceDate).FirstOrDefault();
            //if (chkDate == null)
            //{
            //    foreach (var id in checkes)
            //    {
            //        sa.StudentId = id;
            //        sa.Date = attendanceDate;
            //        db.StudentsAttendances.Add(sa);
            //        db.SaveChanges();
            //        TempData["message"] = "Attendance has been marked";
            //    }
            //}
            //else
            //{
            //    TempData["message"] = "Attendance has already been marked ";
            //}

            //var students = db.Students.ToList();
            //ViewBag.students = students;
            ViewData["NewRegisteredStudentId"] = new SelectList(_context.NewRegisteredStudent, "Id", "Id");
            ViewData["NewRegisteredStudent"] = _context.NewRegisteredStudent;//dropdown
            ViewData["Attendance"] = _context.Attendences;//dropdown
            return View("Create");
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
            //ViewData["NewRegisteredStudentId"] = new SelectList(_context.NewRegisteredStudent, "Id", "Id", attendence.NewRegisteredStudentId);
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
            ViewData["NewRegisteredStudentId"] = new SelectList(_context.NewRegisteredStudent, "Id", "Id", attendence.NewRegisteredStudentId);
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


        public async Task<IActionResult> SpecifyStudentForAttendence(string group, string date, int id)
        {
            //var student = _context.NewRegisteredStudent.Where(s => s.Id == id).SingleOrDefault();
            //ViewData["student"] = student;
            //if (SearchBy == "Rewayah")
            //{
            //    return View(await _context.NewRegisteredStudent.Where(x => x.Rewayah.StartsWith(search) || search == null).ToListAsync());
            //}
            //else if (SearchBy == "Country")
            //{
            //    return View(await _context.NewRegisteredStudent.Where(x => x.Country.StartsWith(search) || search == null).ToListAsync());
            //}
            //else
            //{
            //    return View(await _context.NewRegisteredStudent.Where(x => x.CallingProgram.StartsWith(search) || search == null).ToListAsync());

            //}
            TempData["message"] = "Display the tabel";
            ViewData["NewRegisteredStudentId"] = new SelectList(_context.NewRegisteredStudent, "Id", "Id");
            ViewData["NewRegisteredStudent"] = await _context.NewRegisteredStudent.Where(x => x.GaithGroup == group).ToListAsync();//dropdown
            ViewData["Date"] = date;
            return View("Create");
        }
    }
}
