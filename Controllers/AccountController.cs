using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
