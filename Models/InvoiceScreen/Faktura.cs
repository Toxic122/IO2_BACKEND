using ISP2.Models.LoginScreen;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISP2.Models.InvoiceScreen
{
    public class Faktura
    {
        [Key]
        [Column("idFaktura")]
        public int IdFaktura { get; set; }
        [Column("nrFaktury")]
        public string NrFaktury { get; set; }
        [Column("dataFaktury")]
        public DateTime DataFaktury { get; set; }
        [Column("terminPlatnosci")]
        public DateTime? TerminPlatnosci { get; set; }
        [Column("idKlient")]
        public int? IdKlient { get; set; }
        public Client Klient { get; set; }
        [Column("idPracownik")]
        public int? IdPracownik { get; set; }
        public Employee Pracownik { get; set; }
        [Column("idWplata")]
        public int? IdWplata { get; set; }
         public Wplata Wplata { get; set; }

        [Column("PlikFaktury")]
        public byte[]? PlikFaktury { get; set; }
    }
}
