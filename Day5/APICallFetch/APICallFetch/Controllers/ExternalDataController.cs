using Microsoft.AspNetCore.Mvc;

namespace APICallFetch.Controllers
{
    public class ExternalDataController : Controller
    {
        public IActionResult UserPost() 
        { 
            return View(); 
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
