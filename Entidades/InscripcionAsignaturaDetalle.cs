using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_NeysiFM.Entidades
{
    public class InscripcionAsignaturaDetalle
    {
        public int InscripcionId { get; set; }
        public int AsignaturaId { get; set; }
        public int EstudianteId { get; set; }
        public double Monto { get; set; }

    }
}
