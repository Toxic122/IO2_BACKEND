using ISP2.Models.LoginScreen;
using ISP2.Models.ServiceScreen;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ISP2.ModelsDict
{
    [Table("RolaKlient", Schema ="dict")]
    public class UserRole
    {
        [Key]
        [Column("idRola")]
        public int IdRola { get; set; }

        [Column("Rola")]
        public string Rola { get; set; }

        [JsonIgnore]
        public ICollection<Client> Klienci { get; set; } = new List<Client>();

        [JsonIgnore]
        public ICollection<Employee> Pracownicy { get; set; } = new List<Employee>();
    }
}
