using LearnAdmin.Services;
using LearnAdmin.Share;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnAdmin.Controllers
{
    [Authorize(Roles = nameof(Role.Administrator))]
    [ApiController]
    [Route("api/[controller]")]
    public class PdfController : BaseController
    {
        private readonly PdfServices _pdfServices;

        public PdfController(PdfServices pdfServices)
        {
            this._pdfServices = pdfServices;
        }

    }
}