using Parcial2_NeysiFM.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_NeysiFM.DAL
{
    public class Contexto: DbContext
    {
        public DbSet<Asignaturas> Asignatura { get; set; }
        public DbSet<Estudiantes> Estudiante { get; set; }
        public DbSet<Inscripciones> Inscripcion { get; set; }
        public Contexto() : base("Constr")
        {
        }     
    }
}
