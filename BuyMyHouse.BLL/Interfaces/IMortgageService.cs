using BuyMyHouse.Model;
using BuyMyHouse.Model.Entities;
using IronPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.BLL.Interfaces
{
    public interface IMortgageService
    {
        Task SetApplicationAndMortgageOfferInCache();
        Task<MemoryStream> GeneratePDFFromMortgage(Guid mortgageID);
    }
}
