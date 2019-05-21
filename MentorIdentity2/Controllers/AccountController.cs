using Microsoft.AspNetCore.Mvc;


namespace MentorIdentity2.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
