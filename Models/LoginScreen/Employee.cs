using ISP2.ModelsDict;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISP2.Models.LoginScreen
{
    [Table("Pracownik")]
    public class Employee
    {
        [Key]
        [Column("idPracownik")]
        public int IdPracownik { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("pass")]
        public string Pass { get; set; }

        [Column("imię")]
        public string Imie { get; set; }

        [Column("nazwisko")]
        public string Nazwisko { get; set; }

        [Column("wiek")]
        public int? Wiek { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("telefon")]
        public string Telefon { get; set; }

        [Column("idrola")]
        public int? IdRola { get; set; }

        public UserRole? Rola { get; set; }
    }
}
