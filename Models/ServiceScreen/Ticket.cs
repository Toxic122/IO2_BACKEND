using ISP2.Models.LoginScreen;
using ISP2.ModelsDict;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISP2.Models.ServiceScreen
{
    [Table("Zgloszenie")]
    public class Ticket
    {
        [Key]
        [Column("idZgloszenie")]
        public int IdZgloszenia { get; set; }

        [Column("opisZgloszenia")]
        public string OpisZgloszenia { get; set; }

        [Column("idTypZgloszenia")]
        public int IdTypZgloszenia { get; set; }

        public TicketType TypZgloszenia { get; set; }

        [Column("idStatus")]
        public int IdStatus { get; set; }
        
        public TicketStatus Status { get; set; }

        [Column("idKlient")]
        public int IdKlient { get; set; }

        public Client ClientLogin { get; set; }

        [Column("idPracownik")]
        public int IdPracownik { get; set; }

        public Employee EmployeeLogin { get; set; }


    }
}
