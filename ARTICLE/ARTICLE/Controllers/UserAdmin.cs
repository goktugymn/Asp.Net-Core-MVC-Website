using Microsoft.AspNetCore.Mvc;

namespace ARTICLE.Controllers
{
	public class UserAdmin : Controller
	{
        public string UserName { get; set; }
        public string Password { get; set; }

        public IActionResult Index()
		{
			return View();
		}
	}
}
