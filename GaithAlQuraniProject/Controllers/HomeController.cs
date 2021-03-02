using GaithAlQuraniProject.Data;
using GaithAlQuraniProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GaithAlQuraniProject.Controllers
{
    public class HomeController : Controller
    {
        /* private readonly ILogger<HomeController> _logger;

         public HomeController(ILogger<HomeController> logger)
         {
             _logger = logger;
         }*/

        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext context)
        {
            _db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //IEnumerable<News> news = _db.News.ToList();
            ViewData["News"] = _db.News.ToList();
            ViewData["GaithGroups"] = _db.GaithGroups.ToList();
            ViewData["RegistrationForm"] = _db.RegistrationForms;
            ViewData["Hadeeth"] = _db.hadeethCarousels;
            return View();
        }

   [HttpGet]
        public IActionResult Create(int id)
        {
          
            RegistrationForm registrationForm = new RegistrationForm
            {
                GaithGroupId=id
            };

            return PartialView("_Registration", registrationForm);
        }

        [HttpPost]
        public IActionResult SaveRegistratonForm(RegistrationForm registrationForm)
        {
           /* if (!ModelState.IsValid)
            {
                var registrationFormWrong = new RegistrationForm
                {
                    GaithGroupId = registrationForm.GaithGroupId,
                    Name = registrationForm.Name,
                    phoneNumber = registrationForm.phoneNumber,
                    Country = registrationForm.Country,
                    MemorizedPart = registrationForm.MemorizedPart,
                    Rewayah = registrationForm.Rewayah
                };
               
            }*/

            RegistrationForm registrationFormTest = new RegistrationForm
            {
                GaithGroupId = registrationForm.GaithGroupId,
                Name=registrationForm.Name,
                phoneNumber=registrationForm.phoneNumber,
                Country=registrationForm.Country,
                MemorizedPart=registrationForm.MemorizedPart,
                Rewayah=registrationForm.Rewayah
            };
            _db.RegistrationForms.Add(registrationFormTest);
            _db.SaveChanges();
            ViewData["News"] = _db.News.ToList();
            ViewData["GaithGroups"] = _db.GaithGroups.ToList();
            ViewData["Hadeeth"] = _db.hadeethCarousels.ToList();
            return RedirectToAction("Index");//show a message it has been saved 
                                             // return View("Index");//show a message it has been saved 
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            ViewData["Admins"] = _db.Admins.ToList();
            return View();
        }

       
    }
}



