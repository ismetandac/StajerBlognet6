using Microsoft.EntityFrameworkCore;

namespace StajerBlognet6.UI.Web.Helpers
{
    public class CookieHelper
    {
        HttpRequest _context;
        public CookieHelper(HttpRequest controllerContext = null)
        {
            _context = controllerContext;
        }
        public string GetCookie(string key)
        {
            if (_context.HttpContext.Request.Cookies[key] == null)
            {
                return null;
            }
            return _context.HttpContext.Request.Cookies[key];
        }

        public void SetCookie(string key, object value, int? expireTime = 1440)
        {
            if (value != null)
            {
                CookieOptions option = new CookieOptions();
                option.SameSite = SameSiteMode.None;
                option.Secure = true;
                option.HttpOnly = true;
                if (expireTime.HasValue)
                    option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
                else
                    option.Expires = DateTime.Now.AddMilliseconds(10);
                _context.HttpContext.Response.Cookies.Append(key, value.ToString(), option);
            }

        }
    }
}
