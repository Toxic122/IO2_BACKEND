namespace ISP2.Models.AdminScreen{
public class RegisterUserRequest
    {

    public string Login { get; set; }
    public string Email { get; set; }
    public string Pass { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Telefon { get; set; }
    public int? Wiek { get; set; }
    public int? IdUsluga { get; set; }
    public int? idRola { get; set; } 
    public string Pesel { get; set; }
}
}