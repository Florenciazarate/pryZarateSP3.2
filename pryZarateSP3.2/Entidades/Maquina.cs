using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pryZarateSP3._2.Entidades
{
    [Table("Maquinas")]
    public class Maquina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }

        [Required]
        public int CapacidadInyeccion { get; set; }

        public virtual ICollection<OrdenProduccion> Ordenes { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
