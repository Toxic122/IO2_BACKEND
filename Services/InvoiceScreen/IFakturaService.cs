using ISP2.Models.InvoiceScreen;

namespace ISP2.Services.InvoiceScreen
{
    public interface IFakturaService
    {
        Task<byte[]> GenerujFaktureAsync(FakturaCreateRequest request);
    }
}
