using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.DAL.Interfaces
{
    public interface IPdfRepository
    {
        Task UploadPdfToBlob(Guid applicationID, MemoryStream pdfStream);
    }
}
