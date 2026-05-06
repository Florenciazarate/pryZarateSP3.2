using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pryZarateSP3._2.Entidades
{
    [Table("Ordenes")]
    public class OrdenProduccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public int MaquinaId { get; set; }

        [ForeignKey("MaquinaId")]
        public virtual Maquina Maquina { get; set; }

        [Required]
        public int HorasTrabajo { get; set; }
    }
}
