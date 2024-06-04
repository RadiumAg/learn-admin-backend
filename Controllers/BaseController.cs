using learn_admin_backend.Share;
using Microsoft.AspNetCore.Mvc;

namespace learn_admin_backend.Controllers
{
    public class BaseController : ControllerBase
    {
        [NonAction]
        public MessageModel<T> Success<T>(T data, string msg = "成功")
        {
            return new MessageModel<T>()
            {
                Success = true,
                Msg = msg,
                Data = data,
            };
        }


        [NonAction]
        public MessageModel<T> Fail<T>(T data, string msg = "失败")
        {
            return new MessageModel<T>()
            {
                Success = false,
                Msg = msg,
                Data = data,
            };
        }


        [NonAction]
        public MessageModel Success(string msg = "成功")
        {
            return new MessageModel()
            {
                Success = true,
                Msg = msg,
                Data = null,
            };

        }

        [NonAction]
        public MessageModel Fail(string msg = "失败")
        {
            return new MessageModel()
            {
                Success = true,
                Msg = msg,
                Data = null,
            };
        }

    }
}
