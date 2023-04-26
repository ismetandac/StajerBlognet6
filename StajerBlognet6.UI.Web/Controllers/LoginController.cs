using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StajerBlognet6.Core.Data.DTO;
using StajerBlognet6.Core.Data.Entity;
using StajerBlognet6.Core.Data.Filter;
using StajerBlognet6.UI.Web.Helpers;

namespace StajerBlognet6.UI.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserLoginFilter filter)
        {
            var data = ApiHelper.Post<DTOBase<BlogUser>>("api/users", filter);
            if (data != null & data.IsSuccess)
            {
                var LoginUserData = JsonConvert.SerializeObject(data.Data);
                CookieHelper c = new CookieHelper(Request);
                c.SetCookie("IsLogin", true);
                c.SetCookie("LoginUserData", LoginUserData);
                return Redirect("/");
            }
            else
            {
                filter.Message = data.Message;
            }
            return View(filter);
        }
    }
}
