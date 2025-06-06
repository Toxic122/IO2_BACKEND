namespace ISP2.Models.InvoiceScreen
{
    public class FakturaDto
    {
        public int IdFaktura { get; set; }
        public string NrFaktury { get; set; }
        public string ImieNazwiskoKlienta { get; set; }
        public DateTime DataFaktury { get; set; }
        public decimal? Kwota { get; set; } // przez Wplata

        public DateTime? TerminPlatnosci { get; set; }
    }

}
