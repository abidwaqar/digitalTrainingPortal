using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Digital_Training_Portal.Models;
using Digital_Training_Portal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Digital_Training_Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DigitalTrainingPortalContext _context;

        public HomeController(ILogger<HomeController> logger, DigitalTrainingPortalContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IQueryable<string> deliveryMethodQuery = from m in _context.Course
                                                     orderby m.DeliveryMethod
                                                     select m.DeliveryMethod;

            var courseDeliveryVM = new CourseDeliveryViewModel
            {
                DeliveryMethod = new SelectList(await deliveryMethodQuery.Distinct().ToListAsync()),
                Courses = await _context.Course.Take(4).ToListAsync()
            };

            return View(courseDeliveryVM);
        }

        public async Task<IActionResult> Catalogue(string CourseDMString, string searchString)
        {
            IQueryable<string> deliveryMethodQuery = from m in _context.Course
                                                     orderby m.DeliveryMethod
                                                     select m.DeliveryMethod;

            var courses = from m in _context.Course select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(CourseDMString))
            {
                courses = courses.Where(s => s.DeliveryMethod == CourseDMString);
            }

            var coursedeliveryVM = new CourseDeliveryViewModel
            {
                DeliveryMethod = new SelectList(await deliveryMethodQuery.Distinct().ToListAsync()),
                Courses = await courses.ToListAsync()
            };

            return View(coursedeliveryVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            var user = from u in _context.User where u.Login == login && u.Password == password select u;
            if (user.ToList().Count != 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(string username, string password)
        {
            if (username != null && password != null)
            {
                _context.User.Add(new User
                {
                    Login = username,
                    Password = password
                });
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Course(int Id)
        {
            return View(_context.Course.Find(Id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
