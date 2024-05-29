using learn_admin_backend.Share;
using Microsoft.AspNetCore.Mvc;

namespace learn_admin_backend.Controllers
{
    public class BaseController : ControllerBase
    {
        [NonAction]
        public Response<T> Success<T>(T data, string msg = "成功")
        {
            return new Response<T>()
            {
                success = true,
                msg = msg,
                response = data,
            };
        }

    }
}
