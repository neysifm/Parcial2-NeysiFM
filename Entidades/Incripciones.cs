﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_NeysiFM.Entidades
{
    public class Incripciones
    {
        [Key]
        public int IncripcionId { get; set; }
        public int EstudianteId { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }

        public Incripciones(int incripcionId, int estudianteId, DateTime fecha, double monto)
        {
            IncripcionId = incripcionId;
            EstudianteId = estudianteId;
            Fecha = fecha;
            Monto = monto;
        }

        public Incripciones()
        {
            IncripcionId = 0;
            EstudianteId = 0;
            Fecha = DateTime.Now;
            Monto = 0;
        }
    }
}
