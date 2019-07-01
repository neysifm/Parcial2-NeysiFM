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
    public partial class RegistroEstudiantes : MetroFramework.Forms.MetroForm, IFormularioRegistro<Estudiantes>
    {
        public RegistroEstudiantes()
        {
            InitializeComponent();
        }

        public void LimpiarCampos()
        {
            IDnumericUpDown.Value = 0;
            NombremetroTextBox.Clear();
            FechametroDateTime.Value = DateTime.Now;
            BalancemetroTextBox.Text = "0";
        }

        public void LlenaCampos(Estudiantes estudiante)
        {
            IDnumericUpDown.Value = estudiante.EstudianteId;
            NombremetroTextBox.Text = estudiante.Nombres;
            FechametroDateTime.Value = estudiante.FechaIncreso;
            BalancemetroTextBox.Text = estudiante.Balance.ToString();
        }
       
        public Estudiantes LlenaClase()
        {
            Estudiantes estudiante = new Estudiantes()
            {
                EstudianteId = Convert.ToInt32(IDnumericUpDown.Value),
                Nombres = NombremetroTextBox.Text,
                FechaIncreso = FechametroDateTime.Value,
                Balance = Convert.ToDouble(BalancemetroTextBox.Text),
                
            };
            return estudiante;
        }

        public bool ValidarBuscar()
        {
            if (IDnumericUpDown.Value <= 0)
            {
                return false;
            }
            if (new RepositorioBase<Estudiantes>().Buscar(Convert.ToInt32(IDnumericUpDown.Value)) == null)
            {
                return false;
            }
            return true;
        }

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

        private void RegistroEstudiantes_Load(object sender, EventArgs e)
        {
            BalancemetroTextBox.Text = "0";
            FechametroDateTime.Value = DateTime.Now;
        }

        private void GuardarmetroButton_Click(object sender, EventArgs e)
        {
            if (ValidarModificar())
            {
                new RepositorioBase<Estudiantes>().Modificar(LlenaClase());
                LimpiarCampos();
                MessageBox.Show("El Registro Se Modifico Correctamente!");
            }
            else
            {
               if (ValidarGuardar())
                {
                    new RepositorioBase<Estudiantes>().Guardar(LlenaClase());
                    LimpiarCampos();
                    MessageBox.Show("El Registro Se Guardo Correctamente!");
                }
                else
                {
                    MessageBox.Show("Debe llenar todos los campos Correctamente");
                }
            }
        }

        private void NuevometroButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void EliminarmetroButton_Click(object sender, EventArgs e)
        {
            if (ValidarEliminar())
            {
                new RepositorioBase<Estudiantes>().Eliminar(Convert.ToInt32(IDnumericUpDown.Value));
                LimpiarCampos();
                MessageBox.Show("El Registro se Elimino Correctamente!");
            }
            else
            {
                MessageBox.Show("No se Pudo Eliminar el registro");
            }
        }

        private void BuscarmetroButton_Click(object sender, EventArgs e)
        {
            if (ValidarBuscar())
            {
                Estudiantes estudiante = new RepositorioBase<Estudiantes>().Buscar(Convert.ToInt32(IDnumericUpDown.Value));
                LlenaCampos(estudiante);
            }
            else
            {
                MessageBox.Show("El Registro no se encontro!!");
            }
        }
    }
}
