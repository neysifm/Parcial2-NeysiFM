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
        public Asignaturas Asignatura { get; set; }
        public Estudiantes Estudiante { get; set; }
        public double Monto { get; set; }

        public InscripcionAsignaturaDetalle()
        {
        }

        public InscripcionAsignaturaDetalle(int inscripcionId, Asignaturas asignatura, Estudiantes estudiante, double monto)
        {
            InscripcionId = inscripcionId;
            Asignatura = asignatura;
            Estudiante = estudiante;
            Monto = monto;
        }
    }
}
