using ISP2.Models.LoginScreen;
using ISP2.Models.ServiceScreen;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ISP2.ModelsDict
{
    [Table("StatusZgloszenia", Schema = "dict")]
    public class TicketStatus
    {

        [Key]
        [Column("idStatus")]
        public int IdStatus { get; set; }

        [Column("Status")]
        public string Status { get; set; }

        [JsonIgnore]
        public ICollection<Ticket> Zgloszenia { get; set; } = new List<Ticket>();
    }
}
