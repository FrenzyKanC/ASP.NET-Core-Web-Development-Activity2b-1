using ASP.NET_Core_Web_Development_Activity2b_1.Models;
using ASP.NET_Core_Web_Development_Activity2b_1.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Web_Development_Activity2b_1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // added new function

        // benötigt item in () um weiterzuverarbeiten
        // UserModel ist der folder
        public IActionResult ProcessLogin(UserModel userModel)
        {
            // validating userName Pw
            SecurityService securityService = new SecurityService();
            // hierdurch wird zu der Seite "LoginSuccess" weitergeleitet
            // userModel sind die Daten die zu der Seite weitergeleitet werden
            // auto-gen add view
            if(securityService.IsValid(userModel))
            {
                return View("LoginSuccess", userModel);
            } else
            {
                return View("LoginFailure", userModel);
            }
            
        }
    }
}
