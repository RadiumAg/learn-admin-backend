using LearnAdmin.Model.Models;
using LearnAdmin.Services;
using LearnAdmin.Share;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnAdmin.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PdfController : BaseController
    {
        private readonly PdfServices _pdfServices;

        public PdfController(PdfServices pdfServices)
        {
            this._pdfServices = pdfServices;
        }


        /// <summary>
        /// 获取所有Pdf
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<Pdf>>> GetAllPdf()
        {
            var result = await _pdfServices.GetListAsync((_) => true);
            return this.Success(result);
        }
    }
}