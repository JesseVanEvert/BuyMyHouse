﻿using BuyMyHouse.Model;
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
        Task StoreMortgageOffersOfThisDay();
        Task<MemoryStream> GeneratePDFFromMortgage(Mortgage mortgage);
        Task<byte[]> GetTemporaryPDFFromCache(Guid mortgageID);
        HashSet<Application> GetApplicationsOfThisDay();
    }
}
