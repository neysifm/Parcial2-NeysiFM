using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_NeysiFM.Entidades
{
    public class Estudiantes
    {
        public int EstudianteId { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaIncreso { get; set; }
        public double Balance { get; set; }
        public Estudiantes(int estudianteId, string nombres, DateTime fechaIncreso, double balance)
        {
            EstudianteId = estudianteId;
            Nombres = nombres;
            FechaIncreso = fechaIncreso;
            Balance = balance;
        }

        public Estudiantes()
        {
            EstudianteId = 0;
            Nombres = string.Empty;
            FechaIncreso = DateTime.Now;
            Balance = 0;
        }
    }
}
