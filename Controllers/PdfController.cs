using learn_admin_backend.Database;
using learn_admin_backend.Dto.Pdf;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

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
        public async Task<IActionResult> CreatePdps([FromBody] CreatePdpsDto data)
        {
            this.learnAdminContex.Pdfs.Add(data);
            await this.learnAdminContex.SaveChangesAsync();
            return CreatedAtAction(nameof(CreatePdps), new { id = data.Id });
        }

        /// <summary>
        ///  查询所有Pdf
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryPdfAll")]
        public ActionResult<IEnumerable<Pdf>> QueryPdfAll([FromQuery] QueryPdfDto queryPdfDto)
        {
            var result = this.learnAdminContex.Pdfs.Skip(queryPdfDto.PageNumber * queryPdfDto.PageSize).Take(queryPdfDto.PageSize).ToList();
            return result;
        }
    }
}