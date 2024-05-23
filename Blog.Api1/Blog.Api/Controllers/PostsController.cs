using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    public class PostsController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
