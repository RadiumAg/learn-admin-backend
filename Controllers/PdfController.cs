using learn_admin_backend.Database;
using learn_admin_backend.Dto.Pdf;
using learn_admin_backend.Share;
using Microsoft.AspNetCore.Mvc;

namespace learn_admin_backend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PdfController : ControllerBase
    {
        public readonly LearnAdminContext learnAdminContex;

        public PdfController(LearnAdminContext learnAdminContex)
        {
            this.learnAdminContex = learnAdminContex;
        }

        /// <summary>
        ///  创建Pdf
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreatePdps")]
        public async Task<Response<CreatePdpsResponseDto>> CreatePdps([FromBody] CreatePdpsDto data)
        {
            var result = await this.learnAdminContex.Pdfs.AddAsync(new Pdf { Name = data.Name, Url = data.Url });
            await this.learnAdminContex.SaveChangesAsync();
            return new Response<CreatePdpsResponseDto>
            {
                Data = new CreatePdpsResponseDto
                {
                    Id = result.CurrentValues.GetValue<int>("Id")
                }
            };
        }

        /// <summary>
        ///  查询所有Pdf
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryPdfAll")]
        public Response<List<Pdf>> QueryPdfAll([FromQuery] QueryPdfDto queryPdfDto)
        {
            List<Pdf> result = this.learnAdminContex.Pdfs.Skip(queryPdfDto.PageNumber * queryPdfDto.PageSize).Take(queryPdfDto.PageSize).ToList();
            return new Response<List<Pdf>>
            {
                Data = result
            };
        }
    }
}