using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
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
                var checkUserName = _context.NewRegisteredStudent.Where(x => x.UserName == newRegisteredStudent.UserName).SingleOrDefault();
                if(checkUserName == null)
                {

                    newRegisteredStudent.Password = HashPassword(newRegisteredStudent.Password);//will assign the hash to the password field
                    _context.Add(newRegisteredStudent);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(StudentLogin));//after seccuss registration pop up message
                }
                return View(newRegisteredStudent); /*must an error be showed if the username exists*/
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

        [HttpPost]
        public IActionResult StudentIndex(StudentLogin studentLogin)
        {
            if (ModelState.IsValid)
            {
                    var result = _context.NewRegisteredStudent.Where(x => x.UserName == studentLogin.UserName).Single(); //if null ? or does not exist
                    if (VerifyPassword(result.Password, studentLogin.Password))
                    {
                        return View("StudentIndex", result);
                    }
                             
                return View("StudentLogin", studentLogin);
            }
            return View("StudentLogin", studentLogin);
            
            //while registration make sure the name does not exist


            //must do username 
            //check in the internet how to implement login
            //send the new password to verifyPass 
            //if true then check the username

            
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
                return View("StudentIndex", newRegisteredStudent);       
            }
            return View(newRegisteredStudent);
        }

        public async Task<IActionResult> ChooseFriend(string SearchBy, string search, int id)
        {

            ViewData["studentId"] = id;
            if (SearchBy == "Rewayah")
            {
                return View(await _context.NewRegisteredStudent.Where(x => x.Rewayah.StartsWith(search) || search == null).ToListAsync());
            }
            else if (SearchBy == "Country")
            {
                return View(await _context.NewRegisteredStudent.Where(x => x.Country.StartsWith(search) || search == null).ToListAsync());
            }
            else
            {
                return View(await _context.NewRegisteredStudent.Where(x => x.CallingProgram.StartsWith(search) || search == null).ToListAsync());

            }
            
        }

        public IActionResult addFriend(int id, int idF)
        {
            try
            {
                var student = _context.NewRegisteredStudent.Where(s => s.Id == id).SingleOrDefault();
                var friend = _context.NewRegisteredStudent.Where(s => s.Id == idF).SingleOrDefault();

                student.FriendName = friend.Name;//time
                _context.SaveChanges();
                return View("StudentIndex", student);
            }
            catch
            {
                var student = _context.NewRegisteredStudent.Where(s => s.Id == id).SingleOrDefault();
                return View("ChooseFriend", student);
            }

        }

        private string HashPassword(string password, byte[] salt = null, bool needsOnlyHash = false)
        {
            if (salt == null || salt.Length != 16)
            {
                // generate a 128-bit salt using a secure PRNG
                salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            if (needsOnlyHash) return hashed;
            // password will be concatenated with salt using ':'
            return $"{hashed}:{Convert.ToBase64String(salt)}";
        }

        private bool VerifyPassword(string hashedPasswordWithSalt, string passwordToCheck)
        {
            // retrieve both salt and password from 'hashedPasswordWithSalt'
            var passwordAndHash = hashedPasswordWithSalt.Split(':');
            if (passwordAndHash == null || passwordAndHash.Length != 2)
                return false;
            var salt = Convert.FromBase64String(passwordAndHash[1]);
            if (salt == null)
                return false;
            // hash the given password
            var hashOfpasswordToCheck = HashPassword(passwordToCheck, salt, true);
            // compare both hashes
            if (String.Compare(passwordAndHash[0], hashOfpasswordToCheck) == 0)
            {
                return true;
            }
            return false;
        }
    }
}
