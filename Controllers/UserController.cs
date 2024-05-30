﻿using learn_admin_backend.Database;
using learn_admin_backend.Dto.Pdf;
using learn_admin_backend.Share;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learn_admin_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public readonly LearnAdminContext learnAdminContex;

        public UserController(LearnAdminContext learnAdminContex)
        {
            this.learnAdminContex = learnAdminContex;
        }


        /// <summary>
        ///  创建Pdf
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUserInfo")]
        public async Task<MessageModel<CreatePdpsResponseDto>> GetUserInfo([FromBody] CreatePdpsDto data)
        {
           
        }
    }
}
