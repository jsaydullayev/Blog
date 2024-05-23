using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    public class BlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
