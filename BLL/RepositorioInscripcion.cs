using Parcial2_NeysiFM.DAL;
using Parcial2_NeysiFM.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_NeysiFM.BLL
{
    public class RepositorioInscripcion : RepositorioBase<Inscripciones>
    {
        public override bool Guardar(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto contexto = new Contexto(); 

            try
            {
                RepositorioBase<Estudiantes> contextoEstudiante = new RepositorioBase<Estudiantes>();

                if (contexto.Inscripcion.Add(inscripcion) != null)
                {
                    var estudiante = contextoEstudiante.Buscar(inscripcion.EstudianteId);
                    estudiante.Balance += inscripcion.Monto;
                    paso = contexto.SaveChanges() > 0;
                    contextoEstudiante.Modificar(estudiante);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public override bool Modificar(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto contexto = new Contexto(); 
            RepositorioBase<Estudiantes> contextoEstudiante = new RepositorioBase<Estudiantes>();
            try
            {
                var estudiante = contextoEstudiante.Buscar(inscripcion.EstudianteId);
                var anterior = new RepositorioBase<Inscripciones>().Buscar(inscripcion.InscripcionId);
                estudiante.Balance -= anterior.Monto;

                foreach (var item in anterior.InscripcionDetalle)
                {
                    if (!inscripcion.InscripcionDetalle.Any(A => A.InscripcionAsignaturaDetalleId == item.InscripcionAsignaturaDetalleId))
                    {
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in inscripcion.InscripcionDetalle)
                {
                    if (item.InscripcionAsignaturaDetalleId == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                    }
                    else
                    {
                        contexto.Entry(item).State = EntityState.Modified;
                    }
                }
                estudiante.Balance += inscripcion.Monto;
                contextoEstudiante.Modificar(estudiante);
                contexto.Entry(inscripcion).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var eliminar = contexto.Inscripcion.Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public bool RestarBalance(int id, double monto)
        {
            bool paso = false;
            RepositorioBase<Estudiantes> contexto = new RepositorioBase<Estudiantes>();
            try
            {
                var estudiante = contexto.Buscar(id);
                estudiante.Balance -= monto;
                contexto.Modificar(estudiante);
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
    }
}
