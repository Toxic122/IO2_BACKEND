using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Drawing;
using QuestPDF.Elements;

public class FakturaDocument : IDocument
{
    private readonly string _imie;
    private readonly string _nazwisko;
    private readonly string _pesel;
    private readonly decimal _kwota;
    private readonly string _pracownik;

    public FakturaDocument(string imie, string nazwisko, string pesel, decimal kwota, string pracownik)
    {
        _imie = imie;
        _nazwisko = nazwisko;
        _pesel = pesel;
        _kwota = kwota;
        _pracownik = pracownik;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(30);
            page.Header()
    .Element(e => e
        .AlignCenter()
        .Text("FAKTURA")
        .FontSize(24)
        .Bold()
    );

            page.Content().Column(col =>
            {
                col.Item().Text($"Data: {DateTime.Now:yyyy-MM-dd}");
                col.Item().Text($"Imię i nazwisko klienta: {_imie} {_nazwisko}");
                col.Item().Text($"PESEL: {_pesel}");
                col.Item().Text($"Kwota: {_kwota} PLN");
                col.Item().Text($"Pracownik: {_pracownik}");
            });
            page.Footer().AlignCenter().Text("Dziękujemy za skorzystanie z naszych usług!");
        });
    }
}
