using ISP2.Data;
using ISP2.Models.InvoiceScreen;
using ISP2.Services.InvoiceScreen;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISP2.Controllers.InvoiceScreen
{
    [ApiController]
    [Route("api/[controller]")]
    public class FakturaController : ControllerBase
    {
        private readonly IFakturaService _service;
        private readonly AppDbContext _context;
        public FakturaController(IFakturaService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> Generate([FromBody] FakturaCreateRequest request)
        {
            var pdf = await _service.GenerujFaktureAsync(request);
            return File(pdf, "application/pdf", "faktura.pdf");
        }

        [HttpGet("get-Invoice/{id}")]
        public async Task<IActionResult> GetFakturaPdf(int id)
        {
            var faktura = await _context.Faktury.FindAsync(id);
            if (faktura == null || faktura.PlikFaktury == null)
            {
                return NotFound("Faktura nie istnieje lub nie zawiera pliku.");
            }

            return File(faktura.PlikFaktury, "application/pdf", $"Faktura_{id}.pdf");
        }


        [HttpGet("Invoiceslist")]
        public IActionResult GetFakturyList()
        {
            var faktury = _context.Faktury
                .Include(f => f.Klient)
                .Include(f => f.Wplata)
                .Select(f => new FakturaDto
                {
                    IdFaktura = f.IdFaktura,
                    NrFaktury = f.NrFaktury,
                    ImieNazwiskoKlienta = f.Klient.Imie + " " + f.Klient.Nazwisko,
                    DataFaktury = f.DataFaktury,
                    TerminPlatnosci = f.TerminPlatnosci,
                    Kwota = f.Wplata.WplataKwota
                })
                .ToList();

            return Ok(faktury);
        }



    }
}
