using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_NeysiFM.Entidades
{
    public class Incripciones
    {
        public int IncripcionId { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }

        public Incripciones(int incripcionId, DateTime fecha, double monto)
        {
            IncripcionId = incripcionId;
            Fecha = fecha;
            Monto = monto;
        }

        public Incripciones()
        {
            IncripcionId = 0;
            Fecha = DateTime.Now;
            Monto = 0;
        }
    }
}
