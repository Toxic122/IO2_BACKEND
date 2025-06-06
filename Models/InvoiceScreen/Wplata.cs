using ISP2.Models.LoginScreen;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISP2.Models.InvoiceScreen
{
    public class Wplata
    {
        [Key]
        [Column("idWplata")]
        public int IdWplata { get; set; }
        [Column("Wplata")]
        public decimal WplataKwota { get; set; }
        [Column("idKlient")]
        public int IdKlient { get; set; }
        public Client Klient { get; set; }


    }
}
