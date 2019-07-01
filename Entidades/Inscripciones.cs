using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_NeysiFM.Entidades
{
    public class Inscripciones
    {
        [Key]
        public int InscripcionId { get; set; }
        public int EstudianteId { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public double PrecioCredito { get; set; }
        public virtual List<InscripcionAsignaturaDetalle> InscripcionDetalle { get; set; }

        public Inscripciones(int inscripcionId, int estudianteId, DateTime fecha, double monto, double precioCredito, List<InscripcionAsignaturaDetalle> inscripcionDetalle)
        {
            InscripcionId = inscripcionId;
            EstudianteId = estudianteId;
            Fecha = fecha;
            Monto = monto;
            PrecioCredito = precioCredito;
            InscripcionDetalle = inscripcionDetalle;
        }

        public Inscripciones()
        {
            InscripcionId = 0;
            EstudianteId = 0;
            Fecha = DateTime.Now;
            Monto = 0;
            PrecioCredito = 0;
        }
    }
}
