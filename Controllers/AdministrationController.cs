using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.Rolename
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                    if(result.Succeeded)
                    {
                    return RedirectToAction("index", "home");
                    }
                    foreach(IdentityError error in result.Errors)
                    {
                    ModelState.AddModelError("", error.Description);
                    }
            }
            return View(model);
        }
    }
}
