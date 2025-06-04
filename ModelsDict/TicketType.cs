using ISP2.Models.LoginScreen;
using ISP2.Models.ServiceScreen;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ISP2.ModelsDict
{
    [Table("TypZgloszenia", Schema = "dict")]
    public class TicketType
    {

        [Key]
        [Column("idTypZgloszenia")]
        public int IdTypZgloszeni { get; set; }

        [Column("typZgloszenia")]
        public string TypZgloszenia { get; set; }

        [JsonIgnore]
        public ICollection<Ticket> Zgloszenia { get; set; } = new List<Ticket>();
    }
}
