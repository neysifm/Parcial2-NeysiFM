using Parcial2_NeysiFM.BLL;
using Parcial2_NeysiFM.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2_NeysiFM.UI.Registros
{
    public partial class RegistroIncripciones : MetroFramework.Forms.MetroForm, IFormularioRegistro<Inscripciones>
    {
        public List<InscripcionAsignaturaDetalle> listaDetalle { get; set; }
        public RegistroIncripciones()
        {
            InitializeComponent();
        }

        public void LimpiarCampos()
        {
            InscripcionIDnumericUpDown.Value = 0;
            EstudianteIDnumericUpDown.Value = 0;
            AsignaturaIDnumericUpDown.Value = 0;
            PrecionumericUpDown.Value = 0;
            NombremetroTextBox.Clear();
            FechametroDateTime.Value = DateTime.Now;
            DescripcionmetroTextBox.Clear();
            listaDetalle = null;
        }

        public void LlenaCampos(Inscripciones inscripciones, Estudiantes estudiantes, Asignaturas asignaturas)
        {
            if(inscripciones != null)
            {
                LlenarDataGrid(inscripciones.InscripcionDetalle);
                this.FechametroDateTime.Value = inscripciones.Fecha;
                this.PrecionumericUpDown.Value = Convert.ToDecimal(inscripciones);
            } 
            if(estudiantes != null)
            {
                this.EstudianteIDnumericUpDown.Value = estudiantes.EstudianteId;
                this.NombremetroTextBox.Text = estudiantes.Nombres;
            }

            if(asignaturas != null)
            {
                this.DescripcionmetroTextBox.Text = asignaturas.Descripcion;
            }
        }

        private void LlenarDataGrid(List<InscripcionAsignaturaDetalle> inscripcionDetalle)
        {
            this.AsignaturasdataGridView.DataSource = null;
            this.AsignaturasdataGridView.DataSource = inscripcionDetalle;
            this.AsignaturasdataGridView.Update();
        }

        public void LlenaCampos(Inscripciones inscripciones)
        {
            InscripcionIDnumericUpDown.Value = inscripciones.InscripcionId;
            EstudianteIDnumericUpDown.Value = inscripciones.EstudianteId;
            FechametroDateTime.Value = inscripciones.Fecha;
            PrecionumericUpDown.Value = Convert.ToDecimal(inscripciones.Monto);
        }

        public Inscripciones LlenaClase()
        {
            Inscripciones inscripciones = new Inscripciones()
            {
                InscripcionId = Convert.ToInt32(InscripcionIDnumericUpDown.Value),
                EstudianteId = Convert.ToInt32(EstudianteIDnumericUpDown.Value),
                Fecha = FechametroDateTime.Value,
                Monto = Convert.ToDouble(PrecionumericUpDown.Value)
            };
            return inscripciones;
        }

        public bool ValidarBuscar(String boton)
        {
            if(boton == "inscripcion")
            {
                if (InscripcionIDnumericUpDown.Value <= 0)
                {
                    return false;
                }
                if (new RepositorioBase<Inscripciones>().Buscar(Convert.ToInt32(InscripcionIDnumericUpDown.Value)) == null)
                {
                    return false;
                }
            } else if(boton == "estudiante")
            {
                if (EstudianteIDnumericUpDown.Value <= 0)
                {
                    return false;
                }
                if (new RepositorioBase<Estudiantes>().Buscar(Convert.ToInt32(EstudianteIDnumericUpDown.Value)) == null)
                {
                    return false;
                }
            } else if(boton == "asignatura")
            {
                if (AsignaturaIDnumericUpDown.Value <= 0)
                {
                    return false;
                }
                if (new RepositorioBase<Asignaturas>().Buscar(Convert.ToInt32(AsignaturaIDnumericUpDown.Value)) == null)
                {
                    return false;
                }
            }
           
            return true;
        }

        public bool ValidarBuscar() { return false; }

        public bool ValidarCampos()
        {
            bool validar = true;

            if (string.IsNullOrEmpty(NombremetroTextBox.Text))
            {
                errorProvider.SetError(NombremetroTextBox, "El nombre no puede estar vacio, Llenar Nombre");
                validar = false;
            }
            return validar;
        }

        public bool ValidarEliminar()
        {
            return ValidarBuscar();
        }

        public bool ValidarGuardar()
        {
            if (!ValidarCampos())
            {
                return false;
            }
            return true;
        }

        public bool ValidarModificar()
        {
            if (!ValidarBuscar() || !ValidarGuardar())
            {
                return false;
            }
            return true;
        }

        private void RegistroIncripciones_Load(object sender, EventArgs e)
        {
            FechametroDateTime.Value = DateTime.Now;
            this.FechametroDateTime.Enabled = false;
            NombremetroTextBox.Enabled = false;
            DescripcionmetroTextBox.Enabled = false;
            //lo puse deshabilitado porque no se va a editar solo a buscar
        }

        private void BuscarEstudiantemetroButton_Click(object sender, EventArgs e)
        {
            if(ValidarBuscar("estudiante"))
            {
                EstudianteIDnumericUpDown.Enabled = false;
                Estudiantes estudiante = new RepositorioBase<Estudiantes>().Buscar(Convert.ToInt32(EstudianteIDnumericUpDown.Value));
                LlenaCampos(null, estudiante, null);

            }
        }

        private void BuscarInscripcionmetroButton_Click(object sender, EventArgs e)
        {
            if(ValidarBuscar("inscripcion"))
            {
                InscripcionIDnumericUpDown.Enabled = false;
                this.EstudianteIDnumericUpDown.Enabled = false;
                Inscripciones inscripciones = new RepositorioBase<Inscripciones>().Buscar(Convert.ToInt32(InscripcionIDnumericUpDown.Value));
                this.listaDetalle = inscripciones.InscripcionDetalle;
                Estudiantes estudiante = new RepositorioBase<Estudiantes>().Buscar(inscripciones.EstudianteId);
                LlenaCampos(inscripciones, estudiante, null);
                LlenarDataGrid(inscripciones.InscripcionDetalle);
            }
            

        }

        private void BuscarAsignaturametroButton_Click(object sender, EventArgs e)
        {
            if(ValidarBuscar("asignatura"))
            {
                DescripcionmetroTextBox.Enabled = false;
                AsignaturaIDnumericUpDown.Enabled = false;
                Asignaturas asignatura = new RepositorioBase<Asignaturas>().Buscar(Convert.ToInt32(AsignaturaIDnumericUpDown.Value));
                LlenaCampos(null, null, asignatura);
            }
        }

        private void AgregarmetroButton_Click(object sender, EventArgs e)
        {
            Asignaturas asignatura = new RepositorioBase<Asignaturas>().Buscar(Convert.ToInt32(AsignaturaIDnumericUpDown.Value));
            if(asignatura != null)
            {
                this.listaDetalle.Add(new InscripcionAsignaturaDetalle());
            }
        }
    }
}
