namespace ISP2.Models.InvoiceScreen
{
    public class FakturaCreateRequest
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public decimal Kwota { get; set; }
        public string PracownikLogin { get; set; }
    }
}
