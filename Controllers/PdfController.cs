using LearnAdmin.Dto.Pdf;
using LearnAdmin.Share;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnAdmin.Controllers
{
    [Authorize(Roles = nameof(Role.Administorator))]
    [ApiController]
    [Route("api/[controller]")]
    public class PdfController : BaseController
    {
        public readonly LearnAdminContext learnAdminContex;

        public PdfController(LearnAdminContext learnAdminContex)
        {
            this.learnAdminContex = learnAdminContex;
        }

        /// <summary>
        ///  ����Pdf
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreatePdps")]
        public async Task<MessageModel<CreatePdpsResponseDto>> CreatePdp([FromBody] CreatePdpsDto data)
        {
            var result = await this.learnAdminContex.Pdfs.AddAsync(new Pdf { Name = data.Name, Url = data.Url });
            await this.learnAdminContex.SaveChangesAsync();
            return this.Success(new CreatePdpsResponseDto { Id = result.Entity.Id });
        }

        /// <summary>
        ///  ��ѯ����Pdf
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryPdfAll")]
        public MessageModel<List<Pdf>> QueryPdfAll([FromQuery] QueryPdfDto queryPdfDto)
        {
            List<Pdf> result = this.learnAdminContex.Pdfs.Skip(queryPdfDto.PageNumber * queryPdfDto.PageSize).Take(queryPdfDto.PageSize).ToList();
            return this.Success(result);
        }
    }
}