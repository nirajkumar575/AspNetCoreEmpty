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
        
        public IActionResult Index()
        {

            //var user = new ApplicationUser()
            //{
            //    FirstName = _applicationUser.FirstName,
            //    LastName = _applicationUser.LastName,
            //    Email = _applicationUser.Email
            //};
            return View();

        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

    }
}
