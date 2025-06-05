using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ISP2.ModelsDict
{
    [Table("Usluga")]
    public class Usluga
    {
        [Key]
        [Column("idUsluga")]
        public int idUsluga { get; set; }
        [Column("usluga")]
        public string NazwaUslugi { get; set; }
    }

}