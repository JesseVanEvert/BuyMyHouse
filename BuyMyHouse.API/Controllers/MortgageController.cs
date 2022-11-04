using BuyMyHouse.BLL.Interfaces;
using IronPdf;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BuyMyHouse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MortgageController : ControllerBase
    {
        private readonly IMortgageService _mortgageService;

        public MortgageController(IMortgageService mortgageService)
        {
            _mortgageService = mortgageService;
        }

        [HttpGet("GetMortgagePdfDocument")]
        public async Task<IActionResult> GetMortgagePdfDocument(Guid mortgageID)
        {
            byte[] pdfBytes = await _mortgageService.GetTemporaryPDFFromCache(mortgageID);
            return File(pdfBytes, "application/pdf");
        }
    }
}
