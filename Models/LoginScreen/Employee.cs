using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISP2.Models.LoginScreen
{
    [Table("Pracownik")]
    public class Employee
    {
        [Key]
        [Column("idPracownik")]
        public int idPracownik { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("pass")]
        public string Pass { get; set; }

        [Column("imię")]
        public string Imie { get; set; }

        [Column("nazwisko")]
        public string Nazwisko { get; set; }


        [Column("rola")]
        public string Rola { get; set; }
    }
}
