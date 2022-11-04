﻿using BuyMyHouse.BLL.Extensions;
using BuyMyHouse.BLL.Interfaces;
using BuyMyHouse.DAL.Interfaces;
using BuyMyHouse.Model;
using BuyMyHouse.Model.Entities;
using Microsoft.Extensions.Caching.Distributed;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.BLL
{
    public class MortgageService : IMortgageService
    {
        private readonly IDistributedCache _cache;
        private readonly IApplicationRepository _applicationRepository;

        public MortgageService(IDistributedCache cache, IApplicationRepository applicationRepository)
        {
            _cache = cache;
            _applicationRepository = applicationRepository;
        }

        public async Task StoreMortgageOffersOfThisDay()
        {
            HashSet<Application> applications = _applicationRepository.GetApplicationsOfThisDay();

            foreach (Application application in applications)
            {
                Mortgage mortgage = CalculateMortgage(application);
                byte[] pdfStream = await GeneratePDFFromMortgage(mortgage);
                //await _pdfRepository.UploadPdfToBlob(application.ApplicationID, pdfStream);
                await _cache.SetRecordAsync($"mortgage_{application.ApplicationID}", pdfStream.ToArray());
            }
        }

        /*public async Task<MemoryStream> GeneratePDFFromMortgage(Mortgage mortgage)
        {
            var Renderer = new ChromePdfRenderer();
            //Mortgage mortgage = await _cache.GetRecordAsync<Mortgage>($"mortgage_{mortgageID}");
            PdfDocument pdf = await Renderer.RenderHtmlAsPdfAsync($"<p>maximum loan: {mortgage.MaximumLoan} <p>");

            return pdf.Stream;
        }*/

        public async Task<byte[]> GeneratePDFFromMortgage(Mortgage mortgage)
        {
            PdfDocument mortgageOffer = new();
            PdfPage page = mortgageOffer.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new("Verdana", 20, XFontStyle.Bold); 
            gfx.DrawString($"Maximum loan value: {mortgage.MaximumLoan}", font, XBrushes.Black,
            new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

            MemoryStream stream = new MemoryStream();
            mortgageOffer.Save(stream);
            mortgageOffer.Close();

            return stream.ToArray();
        }

        public async Task<byte[]> GetTemporaryPDFFromCache(Guid mortgageID)
        {
            return await _cache.GetRecordAsync<byte[]>($"mortgage_{mortgageID}");
        }

        public HashSet<Application> GetApplicationsOfThisDay()
        {
            return _applicationRepository.GetApplicationsOfThisDay();
        }

        private static Mortgage CalculateMortgage(Application application)
        {
            Mortgage mortgage = new();

            double maximumLoan = 0;

            foreach (Person applicant in application.Applicants)
                maximumLoan += applicant.YearlyIncomeInEuros * 2.5;

            double interestRate = 4.9;
            double monthlyRate = interestRate / 100 / 12;
            int monthsOfPayments = 360;
            double monthlyPayment = maximumLoan * (monthlyRate * Math.Pow(1 + monthlyRate, monthsOfPayments) / Math.Pow(1 + monthlyRate, monthsOfPayments) - 1);

            mortgage.Application = application;
            mortgage.InterestRate = interestRate;
            mortgage.MaximumLoan = maximumLoan;
            mortgage.MonthlyPayment = monthlyPayment;

            return mortgage;
        }
    }
}
