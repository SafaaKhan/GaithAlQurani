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
        public async Task<IActionResult> Create(NewRegisteredStudent newRegisteredStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newRegisteredStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(StudentLogin));//after seccuss registration pop up message
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
        public async Task<IActionResult> Edit(int id, NewRegisteredStudent newRegisteredStudent)
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


        public IActionResult StudentLogin()
        {
            return View();
        }

        
        public IActionResult StudentEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newRegisteredStudent =  _context.NewRegisteredStudent.Find(id);
            if (newRegisteredStudent == null)
            {
                return NotFound();
            }
            return View(newRegisteredStudent);
        }

        
        public IActionResult StudentIndex(StudentLogin studentLogin)
        {
            //if (id == null) instead Model.is
            //{
            //    return NotFound();
            //}
            //while registration make sure the name does not exist
            var result = _context.NewRegisteredStudent.Where(x => x.Name == studentLogin.Name && x.Password == studentLogin.Password).Single();
            if (result != null)
            {
                return View("StudentIndex", result);
            }
            return RedirectToAction(nameof(StudentLogin));//fix
           // return View(await _context.NewRegisteredStudent.ToListAsync());
        }

        [HttpPost]
        public IActionResult StudentIndex_(NewRegisteredStudent newRegisteredStudent)
        {
            //if (id == null) instead Model.is
            //{
            //    return NotFound();
            //}
            //while registration make sure the name does not exist
            
            return RedirectToAction("StudentIndex", newRegisteredStudent);//fix
                                                          // return View(await _context.NewRegisteredStudent.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StudentEdit(int id, NewRegisteredStudent newRegisteredStudent)
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
                return RedirectToAction("StudentIndex_", newRegisteredStudent);
            }
            return View(newRegisteredStudent);
        }

        public async Task<IActionResult> ChooseFriend()
        {
            return View(await _context.NewRegisteredStudent.ToListAsync());
        }

    }
}
