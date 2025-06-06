namespace ISP2.Models.ConsultantScreen
{
    public class UserSearchRequest
    {
        public string Login { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int? Wiek { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string? NazwaUslugi { get; set; }
        public string? Rola { get; set; }
        public string Typ { get; set; }
        public string? Pesel { get; set; }
    }
}