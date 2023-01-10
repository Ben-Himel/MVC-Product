using Module4.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Module4.Models;

namespace Module4.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        //get method
        public IActionResult Login()
        {
            if(this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            ModelState.AddModelError("", "Failed to login");
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                Module4.Models.User newUser= new Module4.Models.User();
                newUser.Email = registerViewModel.Email;
                newUser.FirstName = registerViewModel.FirstName;
                newUser.LastName = registerViewModel.LastName;
                newUser.UserName = registerViewModel.UserName;
                newUser.PhoneNumber= registerViewModel.PhoneNumber;

                var result= await _userManager.CreateAsync(newUser, registerViewModel.Password);
                if(result.Succeeded)
                {
                    if(newUser.UserName=="Admin")
                    {
                        await _userManager.AddToRoleAsync(newUser, "Admin");
                        await _userManager.AddToRoleAsync(newUser, "Employee");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(newUser, "Employee");
                    }
                    return RedirectToAction("Login", "Account");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                
            }
            return View(registerViewModel);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
