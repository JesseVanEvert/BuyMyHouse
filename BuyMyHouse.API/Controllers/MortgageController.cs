using BuyMyHouse.BLL.Interfaces;
using IronPdf;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BuyMyHouse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MortgageController
    {
        private readonly IMortgageService _mortgageService;

        public MortgageController(IMortgageService mortgageService)
        {
            _mortgageService = mortgageService;
        }

        [HttpGet("GetMortgagePdfDocument")]
        public async Task<IActionResult> GetMortgagePdfDocument(Guid mortgageID)
        {
            MemoryStream pdfStream = await _mortgageService.GeneratePDFFromMortgage(mortgageID);
            return new FileStreamResult(pdfStream, "application/pdf");
        }
    }
}
