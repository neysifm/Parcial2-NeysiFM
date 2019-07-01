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
        public List<InscripcionAsignaturaDetalle> listaDetalle = new List<InscripcionAsignaturaDetalle>();
        public RegistroIncripciones()
        {
            InitializeComponent();
            listaDetalle = new List<InscripcionAsignaturaDetalle>();
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
                this.PrecionumericUpDown.Value = Convert.ToDecimal(inscripciones.PrecioCredito);
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
            Estudiantes estudiante = new RepositorioBase<Estudiantes>().Buscar(Convert.ToInt32(EstudianteIDnumericUpDown.Value));
            if(asignatura != null && estudiante != null)
            {
                this.listaDetalle.Add(new InscripcionAsignaturaDetalle(0, Convert.ToInt32(this.InscripcionIDnumericUpDown.Value), asignatura, estudiante, Convert.ToInt32(PrecionumericUpDown.Value) * asignatura.Creditos));
            }

            TotalmetroTextBox.Text = this.CalcularMonto().ToString();
            LlenarDataGrid(this.listaDetalle);
            this.AsignaturaIDnumericUpDown.Enabled = true;
        }

        private double CalcularMonto()
        {
            double monto = 0;
            foreach (InscripcionAsignaturaDetalle obj in this.listaDetalle)
            {
                monto += obj.Monto;
            }

            return monto;
        }

        private void EliminarFilametroButton_Click(object sender, EventArgs e)
        {
            this.AsignaturasdataGridView.Rows.RemoveAt(this.AsignaturasdataGridView.CurrentCellAddress.Y);
        }

        private double Total()
        {
            double total = 0;
            foreach (var item in listaDetalle)
            {
                total += item.Monto;
            }
            return total;
        }

        private void NuevometroButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void GuardarmetroButton_Click(object sender, EventArgs e)
        {
            if (!ValidarGuardar())
            return;

            RepositorioInscripcion contexto = new RepositorioInscripcion();
            Inscripciones inscripcion = LlenaClase();

            try
            {
                if (InscripcionIDnumericUpDown.Value == 0)
                {
                    if (contexto.Guardar(inscripcion))
                    {
                        LimpiarCampos();
                        MessageBox.Show("Guardado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Error al intentar guardar");
                    }
                }
                else
                {
                    if (contexto.Modificar(inscripcion))
                    {
                        LimpiarCampos();
                        MessageBox.Show("Se Modifico correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void EliminarmetroButton_Click(object sender, EventArgs e)
        {
            RepositorioInscripcion contexto = new RepositorioInscripcion();
            try
            {
                if (InscripcionIDnumericUpDown.Value > 0)
                {
                    if (contexto.Eliminar((int)InscripcionIDnumericUpDown.Value))
                    {
                        contexto.RestarBalance((int)EstudianteIDnumericUpDown.Value, Total());
                        LimpiarCampos();
                        MessageBox.Show("Eliminado correctamente");
                    }
                }
                else
                {
                    errorProvider.SetError(InscripcionIDnumericUpDown, "Debe ser Diferente de 0");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se puedo eliminar");
            }
        }
    }
}
