using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Authentication logic here
                // You can access the form data through the model parameter
                // For example, you can get the username with model.Username

                // After successful authentication, redirect the user to the account page
                return RedirectToAction("Index", "Account");
            }

            // If the model state is not valid, return the user to the login page
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Registration logic here
                // You can access the form data through the model parameter
                // For example, you can get the username with model.Username

                // After successful registration, redirect the user to the login page
                return RedirectToAction("Login", "Account");
            }

            // If the model state is not valid, return the user to the registration page
            return View(model);
        }
        
    }
}
