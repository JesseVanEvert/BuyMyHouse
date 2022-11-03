using Azure.Storage.Blobs;
using BuyMyHouse.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.DAL.Repositories
{
    public class PdfRepository : IPdfRepository
    {
        private readonly BlobContainerClient _containerClient;

        public PdfRepository(string databaseName, string containerName)
        {
            _containerClient = new BlobContainerClient(databaseName, containerName);
        }

        public async Task UploadPdfToBlob(Guid applicationID, MemoryStream pdfStream)
        {
            var blob = _containerClient.GetBlobClient(applicationID.ToString());
            await blob.UploadAsync(pdfStream);
        }
    }
}
