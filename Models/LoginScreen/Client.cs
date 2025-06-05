using ISP2.ModelsDict;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISP2.Models.LoginScreen
{
    [Table("Klient")]
    public class Client
    {
        [Key]
        [Column("IdKlient")]
        public int IdKlient { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("pass")]
        public string Pass { get; set; }

        [Column("idrola")]
        public int? IdRola { get; set; }

        public UserRole? Rola { get; set; }

        [Column("imie")]
        public string Imie { get; set; }

        [Column("Nazwisko")]
        public string Nazwisko { get; set; }

        [Column("Wiek")]
        public int? Wiek { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Telefon")]
        public string Telefon { get; set; }

        [Column("idUsluga")]
        public int? idUsluga { get; set; }
        public Usluga? Usluga { get; set; }
    }
}
