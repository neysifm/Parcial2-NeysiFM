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
    public partial class RegistroAsignatura : MetroFramework.Forms.MetroForm, IFormularioRegistro<Asignaturas>
    {
        public RegistroAsignatura()
        {
            InitializeComponent();
        }

        public void LimpiarCampos()
        {
            IDnumericUpDown.Value = 0;
            IDnumericUpDown.Enabled = true;
            DescripcionmetroTextBox.Clear();
            CreditosnumericUpDown.Value = 0;
        }

        public void LlenaCampos(Asignaturas asignaturas)
        {
            IDnumericUpDown.Value = asignaturas.AsignaturaId;
            DescripcionmetroTextBox.Text = asignaturas.Descripcion;
            CreditosnumericUpDown.Value = asignaturas.Creditos;
        }

        public Asignaturas LlenaClase()
        {
            Asignaturas asignaturas = new Asignaturas()
            {
                AsignaturaId = Convert.ToInt32(IDnumericUpDown.Value),
                Descripcion = DescripcionmetroTextBox.Text,
                Creditos = Convert.ToInt32(CreditosnumericUpDown.Value)
            };
            return asignaturas;
        }

        public bool ValidarBuscar()
        {
            if (IDnumericUpDown.Value <= 0)
            {
                return false;
            }
            if (new RepositorioBase<Asignaturas>().Buscar(Convert.ToInt32(IDnumericUpDown.Value)) == null)
            {
                return false;
            }
            return true;
        }

        public bool ValidarCampos()
        {
            bool validar = true;

            if (string.IsNullOrEmpty(DescripcionmetroTextBox.Text))
            {
                errorProvider.SetError(DescripcionmetroTextBox, "La Descripcion no puede estar vacia, Favor llenar Descripcion");
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

        private void RegistroAsignatura_Load(object sender, EventArgs e)
        {

        }

        private void BuscarmetroButton_Click(object sender, EventArgs e)
        {
            if (ValidarBuscar())
            {
                Asignaturas asignaturas = new RepositorioBase<Asignaturas>().Buscar(Convert.ToInt32(IDnumericUpDown.Value));
                LlenaCampos(asignaturas);
                IDnumericUpDown.Enabled = false;
            }
            else
            {
                MessageBox.Show("El Registro no se encontro!!");
            }
        }

        private void NuevometroButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void GuardarmetroButton_Click(object sender, EventArgs e)
        {
            if (ValidarModificar())
            {
                new RepositorioBase<Asignaturas>().Modificar(LlenaClase());
                LimpiarCampos();
                MessageBox.Show("El Registro se Actualizo Correctamente!");
            }
            else
            {
                 if(ValidarGuardar())
                {
                    new RepositorioBase<Asignaturas>().Guardar(LlenaClase());
                    LimpiarCampos();
                    MessageBox.Show("El Registro se Guardo Correctamente!");
                } else
                {
                    MessageBox.Show("Debe Llenar todos los campos Correctamente!");
                }
                
            }
            
        }

        private void EliminarmetroButton_Click(object sender, EventArgs e)
        {
            if (ValidarEliminar())
            {
                new RepositorioBase<Asignaturas>().Eliminar(Convert.ToInt32(IDnumericUpDown.Value));
                LimpiarCampos();
                MessageBox.Show("El Registro se Elimino Correctamente!");
            }
            else
            {
                MessageBox.Show("No se Pudo Eliminar el registro");
            }
        }
    }
}
