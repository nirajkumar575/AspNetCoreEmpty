using AspNetCoreEmpty.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreEmpty.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationUser _applicationUser;
        public HomeController(ApplicationUser applicationUser)
        {
            _applicationUser = applicationUser;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Index(ApplicationUser applicationUser)
        {
            var user = new ApplicationUser()
            {
                FirstName = _applicationUser.FirstName,
                LastName = _applicationUser.LastName,
                Email = _applicationUser.Email
            };
            return View(user);

        }

    }
}
