using HarshaASP.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace HarshaASP.Controllers
{

    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public ContentResult Index()
        {
            //return new ContentResult()
            //{
            //    Content = "Hello from Index",
            //    ContentType = "text/plain"
            //};

            //return Content("Hello from Index", "text/plain");

            return Content("<h1>Welcome</h1><h2>Hello from Index</h2>", "text/html");
        }

        [Route("about")]
        public ContentResult About()
        {
            return Content("Hello from about", "text/plain");
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "James",
                LastName = "Smith",
                Age = 25
            };

            //return new JsonResult(peson);
            return Json(person);
        }

        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            return new VirtualFileResult("/Sample.pdf", "application/pdf");
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "Hello from Contact";
        }
    }
}
