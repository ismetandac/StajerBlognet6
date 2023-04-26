using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StajerBlognet6.Core.Data;
using StajerBlognet6.Core.Data.DTO;
using StajerBlognet6.Core.Data.Entity;
using StajerBlognet6.Core.Data.Filter;

namespace StajerBlognet6.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost(Name = "UserLogin")]
        public DTOBase<BlogUser> OnPost(UserLoginFilter filter)
        {
            var rt = new DTOBase<BlogUser>();
            using (var db = new BlogDB())
            {
                var data = db.BlogUsers.FirstOrDefault(s => s.Email == filter.Email && s.Password == filter.Password);
                rt.IsSuccess = data != null;
                rt.Data = data;
                rt.Message = data != null ? null : "Kullancı Bulunamadı";
            }
            return rt;
        }
    }
}
