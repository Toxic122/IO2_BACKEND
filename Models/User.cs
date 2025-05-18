using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISP2.Models
{
    [Table("Klient")]
    public class User
    {
        [Key]
        [Column("IdKlient")]
        public int IdKlient { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("pass")]
        public string Pass { get; set; }

        [Column("rola")]
        public string Rola { get; set; }

        [Column("imie")]
        public string Imie { get; set; }
    }
}
