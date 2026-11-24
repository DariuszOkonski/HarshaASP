using Microsoft.AspNetCore.Mvc;

namespace HarshaASP.Controllers
{
    //public class HomeController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}

    public class HomeController
    {
        [Route("sayhello")]
        public string method1()
        {
            return "Hello from method1";
        }
    }
}
