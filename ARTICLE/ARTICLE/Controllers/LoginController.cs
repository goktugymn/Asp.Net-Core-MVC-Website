using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ARTICLE.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace ARTICLE.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(UserAdmin p) { 
        var datavalue = c.UserAdmins.FirstOrDefault(x => x.UserName == p.UserName &&
        x.Password == p.Password);
            if (datavalue != null)
            {
                var claims = new List<Claim>
         {
             new Claim(ClaimTypes.Name,p.UserName)
         };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Category");
            }
            return View();
        //public IActionResult Index(UserAdmin p)
        //{

           
        //    var adminuserinfo = c.UserAdmins.FirstOrDefault
        //        (x => x.UserName == p.UserName && x.Password == p.Password);
        //    if (adminuserinfo != null)
        //    {
        //        return RedirectToAction("Index", "UserAdmin");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        }
    }
}
