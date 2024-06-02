using batitap18asp.Models;
using Microsoft.AspNetCore.Mvc;

namespace batitap18asp.Controllers
{
    public class AcountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly SanPhamDBgContext _context;

        public AcountController(SanPhamDBgContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] UserLoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var user = _context.Users.SingleOrDefault(u => u.Username == loginModel.Username && u.Password == loginModel.Password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Sai username hoặc password";
            return View(loginModel);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
