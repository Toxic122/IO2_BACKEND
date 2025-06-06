using ISP2.Data;
using ISP2.Models.InvoiceScreen;
using ISP2.Models.LoginScreen;
using QuestPDF.Fluent;
using ISP2.Services.InvoiceScreen;

namespace ISP2.Services.InvoiceScreen
{
    public class FakturaService : IFakturaService
    {
        private readonly AppDbContext _context;
        private readonly string _outputDir;

        public FakturaService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _outputDir = Path.Combine(env.ContentRootPath, "GeneratedInvoices");
            Directory.CreateDirectory(_outputDir);
        }

        public async Task<byte[]> GenerujFaktureAsync(FakturaCreateRequest request)
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            var klient = _context.Clients.FirstOrDefault(c => c.Pesel == request.Pesel)
                         ?? throw new Exception("Nie znaleziono klienta o podanym PESEL.");

            var pracownik = _context.Employees.FirstOrDefault(p => p.Login == request.PracownikLogin)
                            ?? throw new Exception("Nie znaleziono pracownika o podanym loginie.");

            var wplata = new Wplata
            {
                WplataKwota = request.Kwota,
                IdKlient = klient.IdKlient
            };
            _context.Wplaty.Add(wplata);
            await _context.SaveChangesAsync();

            var dzisiaj = DateTime.Now.Date;
            int ileTegoDnia = _context.Faktury.Count(f => f.DataFaktury.Date == dzisiaj) + 1;
            string numerFaktury = $"FAK-{dzisiaj:yyyy-MM-dd}-{ileTegoDnia:000}";

            var faktura = new Faktura
            {
                DataFaktury = DateTime.Now,
                TerminPlatnosci = DateTime.Now.AddDays(7),
                IdKlient = klient.IdKlient,
                IdWplata = wplata.IdWplata,
                IdPracownik = pracownik.IdPracownik,
                NrFaktury = numerFaktury
            };

            _context.Faktury.Add(faktura);
            await _context.SaveChangesAsync();

            var dokument = new FakturaDocument(klient.Imie, klient.Nazwisko, klient.Pesel, request.Kwota, pracownik.Login);
            string finalPdfPath = Path.Combine(_outputDir, $"Faktura_{klient.Imie}_{klient.Nazwisko}_{DateTime.Now:yyyyMMddHHmmss}.pdf");
            dokument.GeneratePdf(finalPdfPath);

            byte[] pdfBytes = await File.ReadAllBytesAsync(finalPdfPath);
         

            faktura.PlikFaktury = pdfBytes;
            _context.Faktury.Update(faktura);
            await _context.SaveChangesAsync();

            return pdfBytes;
        }
    }
}
