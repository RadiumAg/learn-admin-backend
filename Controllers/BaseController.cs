using Microsoft.AspNetCore.Mvc;

namespace learn_admin_backend.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult Json<T>(T Data)
        {
            return new JsonResult(new
            {
                Code = 200,
                Data = Data as dynamic,
                Message = "",
            });

        }
    }
}
