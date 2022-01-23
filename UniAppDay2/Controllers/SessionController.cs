using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniAppDay2.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult setState()
        {
            string msg = "session saved ";
            HttpContext.Session.SetString("message", msg);//
            return Content("Hello from session controller");
        }


        public IActionResult getState()
        {
            string msg = HttpContext.Session.GetString("message");
            return Content($"session is retrived {msg}");
        }
    }
}
